using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;


namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/Pharmacist")]
    public class PharmacistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacistController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var pharmacists = _unitOfWork.PharmacistRepository.Retrive().ToList();
            var pharmacistsVM = _mapper.Map<List<PharmacistVM>>(pharmacists);
            return View(pharmacistsVM);
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
        public IActionResult Create(PharmacistVM pharmacistVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacist = _mapper.Map<Pharmacist>(pharmacistVM);
                _unitOfWork.PharmacistRepository.Create(pharmacist);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacistVM);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var pharmacist = _unitOfWork.PharmacistRepository.RetriveItem(p => p.Id == id);
            if (pharmacist == null) return NotFound();

            var pharmacistVM = _mapper.Map<PharmacistVM>(pharmacist);
            return View(pharmacistVM);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PharmacistVM pharmacistVM)
        {
            if (ModelState.IsValid)
            {
                var pharmacist = _mapper.Map<Pharmacist>(pharmacistVM);
                _unitOfWork.PharmacistRepository.Update(pharmacist);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacistVM);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            var pharmacist = _unitOfWork.PharmacistRepository.RetriveItem(p => p.Id == id);
            if (pharmacist == null) return NotFound();

            var pharmacistVM = _mapper.Map<PharmacistVM>(pharmacist);
            return View(pharmacistVM);
        }

        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var person = _unitOfWork.PharmacistRepository.RetriveItem(p => p.Id == id);
            if (person == null) return NotFound();

            _unitOfWork.PharmacistRepository.Delete(person);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
