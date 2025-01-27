using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using System.Linq;
using CMS.Models.CuraHub.PharmacySection;

namespace CMS.Presentation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area("Admin")]
    [Route("Admin/CuraHub/Pharmacy/PharmacyOrder")]
    public class PharmacyOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyOrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var pharmacyOrders = _unitOfWork.PharmacyOrderRepository.Retrive().ToList();
            var pharmacyOrderVMs = _mapper.Map<List<PharmacyOrderVM>>(pharmacyOrders);
            return View(pharmacyOrderVMs);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PharmacyOrderVM pharmacyOrderVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacyOrder = _mapper.Map<PharmacyOrder>(pharmacyOrderVM);
                _unitOfWork.PharmacyOrderRepository.Create(pharmacyOrder);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacyOrderVM);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var pharmacyOrder = _unitOfWork.PharmacyOrderRepository.RetriveItem(o => o.Id == id);
            if (pharmacyOrder == null) return NotFound();

            var pharmacyOrderVM = _mapper.Map<PharmacyOrderVM>(pharmacyOrder);
            return View(pharmacyOrderVM);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PharmacyOrderVM pharmacyOrderVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacyOrder = _mapper.Map<PharmacyOrder>(pharmacyOrderVM);
                _unitOfWork.PharmacyOrderRepository.Update(pharmacyOrder);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacyOrderVM);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            var pharmacyOrder = _unitOfWork.PharmacyOrderRepository.RetriveItem(o => o.Id == id);
            if (pharmacyOrder == null) return NotFound();

            var pharmacyOrderVM = _mapper.Map<PharmacyOrderVM>(pharmacyOrder);
            return View(pharmacyOrderVM);
        }
        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var pharmacyOrder = _unitOfWork.PharmacyOrderRepository.RetriveItem(o => o.Id == id);
            if (pharmacyOrder == null) return NotFound();

            _unitOfWork.PharmacyOrderRepository.Delete(pharmacyOrder);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}

