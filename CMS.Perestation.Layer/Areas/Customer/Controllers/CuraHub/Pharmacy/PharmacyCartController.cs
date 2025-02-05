using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.BillingPortal;
using Stripe.Checkout;
using AutoMapper;


namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Pharmacy/PharmacyCart")]
    public class PharmacyCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public PharmacyCartController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager )
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [Route("Index")]
        public ActionResult Index()
        {   
            var userId = userManager.GetUserId(User);
            var medicineInCart = _unitOfWork.PharmacyCartRepository.Retrive(e => e.ApplicationUserId == userId, [e => e.Medicine]).ToList();
            
            return View(medicineInCart);
        }

        [HttpPost]
        [Route("PlusToCart")]
        public JsonResult PlusToCart(int medicineId)
        {
            var userId = userManager.GetUserId(User);
            var medicine = _unitOfWork.PharmacyCartRepository.RetriveItem(e => e.MedicineId == medicineId);

            if (userId != null)
            {
                if (medicine != null)
                {
                    medicine.count += 1;
                }
                else
                {
                    medicine = new PharmacyCart
                    {
                        MedicineId = medicineId,
                        count = 1,
                        ApplicationUserId = userId
                    };
                    _unitOfWork.PharmacyCartRepository.Create(medicine);
                }
                _unitOfWork.Commit();
            }
            return Json(medicine);
        }

        [HttpPost]
        [Route("MinusFromCart")]
        public JsonResult MinusFromCart(int medicineId)
        {
            var userId = userManager.GetUserId(User);
            var medicine = _unitOfWork.PharmacyCartRepository.RetriveItem(e => e.MedicineId == medicineId);

            if (medicine != null && medicine.count > 1)
            {
                medicine.count -= 1;
                _unitOfWork.Commit();
            }
            return Json(medicine);
        }

        [HttpPost]
        [Route("DeleteFromCart")]
        public JsonResult DeleteFromCart(int medicineId)
        {
            var userId = userManager.GetUserId(User);
            var medicine = _unitOfWork.PharmacyCartRepository.RetriveItem(e => e.MedicineId == medicineId);

            if (medicine != null)
            {
                _unitOfWork.PharmacyCartRepository.Delete(medicine);
                _unitOfWork.Commit();
            }
            return Json(new { success = true });
        }

        [HttpGet]
        [Route("GetCartCount")]
        public JsonResult GetCartCount()
        {
            var userId = userManager.GetUserId(User);
            var medicinesInCart = _unitOfWork.PharmacyCartRepository.Retrive(e => e.ApplicationUserId == userId).ToList();
            int totalItems = medicinesInCart.Sum(item => item.count); 
            return Json(new { count = totalItems });
        }


        // [HttpGet]
        // [Route("SummaryOrder")]
        // public IActionResult SummaryOrder()
        // {           
        //     return PartialView("_SummaryOrder");
        // }
        // [HttpPost]
        // [Route("SummaryOrder")]
        // public async Task<IActionResult> SummaryOrder(PharmacyCustomerVM pharmacyCustomerVM)
        // {
        //     ModelState.Remove("Email");
        //     if (ModelState.IsValid)
        //     {
        //         var appUser = await userManager.GetUserAsync(User);
        //         if (appUser != null)
        //         {
        //             pharmacyCustomerVM.Email = appUser.Email;
        //         }
        //         var customer = mapper.Map<PharmacyCustomer>(pharmacyCustomerVM);
        //         _unitOfWork.PharmacyCustomerRepository.Create(customer);
        //         _unitOfWork.Commit();
        //     }
        //     return RedirectToAction("Pay");
        // }

        [Route("Pay")]
        public IActionResult Pay()
        {
            var userId = userManager.GetUserId(User);
            var medicinesInCart = _unitOfWork.PharmacyCartRepository.Retrive(e => e.ApplicationUserId == userId, [e => e.Medicine]);
            
            if (!medicinesInCart.Any())
            {
                return RedirectToAction("Index");
            }
            
            _unitOfWork.Commit();

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>(),
           
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/checkout/success",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/checkout/cancel",
            };

            foreach (var medicine in medicinesInCart)
            {
                options.LineItems.Add(new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "egp",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = medicine.Medicine.Name,
                        },
                        UnitAmount = (long)medicine.Medicine.Price  * 100,
                    },
                    Quantity = medicine.count,
                });
            }

            var service = new Stripe.Checkout.SessionService();
            var session = service.Create(options);
            return Redirect(session.Url);
        }
    }
}
