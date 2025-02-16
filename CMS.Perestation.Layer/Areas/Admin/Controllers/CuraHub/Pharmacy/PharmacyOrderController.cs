using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using CMS.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/PharmacyOrder")]
    public class PharmacyOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private const int PageSize = 8;

        public PharmacyOrderController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        private DeliveryAndCustomerVM PopulateViewModel(PharmacyOrderVM? PharmacyOrderVM = null)
        {
            var deliveryRepresentatives = _unitOfWork.PharmacyDeliveryRepresentativeRepository.Retrive().ToList();
            var pharmacyCustomers = _unitOfWork.PharmacyCustomerRepository.Retrive().ToList();
            DeliveryAndCustomerVM model = new DeliveryAndCustomerVM(){
                PharmacyCustomer = pharmacyCustomers,
                PharmacyDeliveryRepresentative = deliveryRepresentatives,
                PharmacyOrderVM = PharmacyOrderVM
            };
            return model;
        }

        private void SetPaginationData(int pageNumber, int totalItems)
        {
            ViewBag.currentPage = pageNumber;
            ViewBag.lastPage = (int)Math.Ceiling((double)totalItems / PageSize) - 1;
        }

        [Route("Index")]
        public ActionResult Index(int pageNumber = 0)
        {
            var orders = _unitOfWork.PharmacyOrderRepository
                .Retrive(includeProps: [e => e.PharmacyCustomer])
                .Skip(pageNumber * PageSize)
                .Take(PageSize)
                .ToList();

            int totalItems = _unitOfWork.PharmacyOrderRepository.Retrive().Count();
            SetPaginationData(pageNumber, totalItems);

            var orderVM = _mapper.Map<List<PharmacyOrderVM>>(orders);
            return View(orderVM);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create(int pageNumber = 0)
        {
            ViewBag.currentPage = pageNumber;
            return View(PopulateViewModel());
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeliveryAndCustomerVM modelVM)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<PharmacyOrder>(modelVM);
                _unitOfWork.PharmacyOrderRepository.Create(order);
                _unitOfWork.Commit();

                int totalItems = _unitOfWork.PharmacyOrderRepository.Retrive().Count();
                SetPaginationData(0, totalItems);
                return RedirectToAction(nameof(Index), new { pageNumber = ViewBag.lastPage });
            }
            return View(PopulateViewModel(modelVM.PharmacyOrderVM));
        }

        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(int id, int pageNumber)
        {
            var order = _unitOfWork.PharmacyOrderRepository.RetriveItem(e => e.Id == id);
            if (order == null) return NotFound();

            var orderVM = _mapper.Map<PharmacyOrderVM>(order);
            ViewBag.currentPage = pageNumber;
            return View(PopulateViewModel(orderVM));
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeliveryAndCustomerVM modelVM, int pageNumber = 0)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<PharmacyOrder>(modelVM);
                _unitOfWork.PharmacyOrderRepository.Update(order);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index), new { pageNumber });
            }
            ViewBag.currentPage = pageNumber;
            return View(PopulateViewModel(modelVM.PharmacyOrderVM));
        }

        [Route("Details")]
        public ActionResult Details(int id, int pageNumber = 0)
        {
            var medicineOrder = _unitOfWork.MedicineOrderRepository.Retrive(
                e => e.PharmacyOrderId == id, 
                includeProps: [
                    e => e.Medicine, 
                    e => e.PharmacyOrder, 
                    e => e.PharmacyOrder.PharmacyCustomer, 
                    e => e.PharmacyOrder.PharmacyDeliveryRepresentative
                ]).ToList();
            
            if (medicineOrder == null) return NotFound();

            ViewBag.currentPage = pageNumber;

            var medicineOrderVM = _mapper.Map<List<MedicineOrderVM>>(medicineOrder);
            return View(medicineOrderVM);
        }

        [HttpGet]
        [Route("CancelOrder")]
        public ActionResult CancelOrder(int id, int pageNumber = 0)
        {
            var order = _unitOfWork.PharmacyOrderRepository.RetriveItem(e => e.Id == id);
            if (order == null) return NotFound();

            // Ensure order is eligible for cancellation
            if (order.ShipmentStatus == ShipmentStatus.Delivered)
            {
                TempData["Error"] = "Delivered orders cannot be canceled.";
                return RedirectToAction("Index", new { pageNumber });
            }

            // Process refund if a valid transaction ID exists
            if (!string.IsNullOrEmpty(order.TransactionId))
            {
                bool refundSuccess = ProcessStripeRefund(order.TransactionId, order.TotalPrice);
                if (!refundSuccess)
                {
                    TempData["Error"] = "Refund processing failed.";
                    return RedirectToAction("Index", new { pageNumber });
                }
            }

            // Mark order as canceled
            order.ShipmentStatus = ShipmentStatus.Cancelled;
            _unitOfWork.PharmacyOrderRepository.Update(order);
            _unitOfWork.Commit();

            TempData["Success"] = "Order has been canceled and refunded successfully.";
            return RedirectToAction("Index", new { pageNumber });
        }

        private bool ProcessStripeRefund(string transactionId, double amount)
        {
            try
            {
                StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"]; // Store this securely

                var options = new RefundCreateOptions
                {
                    Charge = transactionId,
                    Amount = (long)(amount * 100), // Convert to cents
                };
                var refundService = new RefundService();
                Refund refund = refundService.Create(options);

                return refund.Status == "succeeded";
            }
            catch (StripeException ex)
            {
                Console.WriteLine($"Stripe Refund Error: {ex.Message}");
                return false;
            }
        }

        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(int id, int pageNumber = 0)
        {
            var order = _unitOfWork.PharmacyOrderRepository.RetriveItem(e => e.Id == id);
            if (order == null) return NotFound();

            _unitOfWork.PharmacyOrderRepository.Delete(order);
            _unitOfWork.Commit();
            return RedirectToAction("Index", new { pageNumber });
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string searchText, int pageNumber = 0)
        {
            var orders = _unitOfWork.PharmacyOrderRepository
                .Retrive(e => e.PharmacyCustomer.FirstName.ToLower().Contains(searchText.ToLower()) 
                || e.PharmacyCustomer.LastName.ToLower().Contains(searchText.ToLower())
                || e.PharmacyDeliveryRepresentative.FirstName.ToLower().Contains(searchText.ToLower())
                || e.PharmacyDeliveryRepresentative.LastName.ToLower().Contains(searchText.ToLower()) 
                || e.Id.Equals(Int32.Parse(searchText)), includeProps: [e => e.PharmacyCustomer])
                .Skip(pageNumber * PageSize)
                .Take(PageSize)
                .ToList();
            var orderVM = _mapper.Map<List<PharmacyOrderVM>>(orders);
            return PartialView("_Search", orderVM);
        }
        // [HttpPost]
        // [Route("SearchStatus")]
        // public IActionResult SearchStatus(ShipmentStatus status, int pageNumber = 0)
        // {
        //     var orders = _unitOfWork.PharmacyOrderRepository.Retrive(e => e.ShipmentStatus == status, [e => e.PharmacyCustomer])                
        //     .Skip(pageNumber * PageSize)
        //     .Take(PageSize)
        //     .ToList();
        //     return PartialView("_SearchStatus", orders);
        // }
    }
}