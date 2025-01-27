using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using CMS.Models.CuraHub.PharmacySection;


namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/pharmacyDeliveryRepresentative")]
    public class PharmacyDeliveryRepresentativeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyDeliveryRepresentativeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var pharmacyDeliveryRepresentative = _unitOfWork.PharmacyDeliveryRepresentativeRepository.Retrive().ToList();
            var pharmacyDeliveryRepresentativeVM = _mapper.Map<List<PharmacyDeliveryRepresentativeVM>>(pharmacyDeliveryRepresentative);
            return View(pharmacyDeliveryRepresentativeVM);
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
        public IActionResult Create(PharmacyDeliveryRepresentativeVM pharmacyDeliveryRepresentativeVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacyDeliveryRepresentative = _mapper.Map<PharmacyDeliveryRepresentative>(pharmacyDeliveryRepresentativeVM);
                _unitOfWork.PharmacyDeliveryRepresentativeRepository.Create(pharmacyDeliveryRepresentative);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacyDeliveryRepresentativeVM);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var pharmacyDeliveryRepresentative = _unitOfWork.PharmacyDeliveryRepresentativeRepository.RetriveItem(p => p.Id == id);
            if (pharmacyDeliveryRepresentative == null) return NotFound();

            var pharmacyDeliveryRepresentativeVM = _mapper.Map<PharmacyDeliveryRepresentativeVM>(pharmacyDeliveryRepresentative);
            return View(pharmacyDeliveryRepresentativeVM);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PharmacyDeliveryRepresentativeVM pharmacyDeliveryRepresentativeVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacyDeliveryRepresentative = _mapper.Map<PharmacyDeliveryRepresentative>(pharmacyDeliveryRepresentativeVM);
                _unitOfWork.PharmacyDeliveryRepresentativeRepository.Update(pharmacyDeliveryRepresentative);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacyDeliveryRepresentativeVM);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            var pharmacyDeliveryRepresentative = _unitOfWork.PharmacyDeliveryRepresentativeRepository.RetriveItem(d => d.Id == id, [d => d.PharmacyOrders]);
            if (pharmacyDeliveryRepresentative == null) return NotFound();

            var pharmacyDeliveryRepresentativeVM = _mapper.Map<PharmacyDeliveryRepresentativeVM>(pharmacyDeliveryRepresentative);
            return View(pharmacyDeliveryRepresentativeVM);
        }

        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var person = _unitOfWork.PharmacyDeliveryRepresentativeRepository.RetriveItem(p => p.Id == id);
            if (person == null) return NotFound();

            _unitOfWork.PharmacyDeliveryRepresentativeRepository.Delete(person);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
