using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using CMS.Data.Access.Layer.Repository.IRepository;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/CuraHub/Pharmacy/MedicineManufactory")]
    public class MedicineManufactoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicineManufactoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]

        public IActionResult Index()
        {
            var manufactory= _unitOfWork.MedicineManufactoryRepository.Retrive().ToList();
            var manufactoryVM = _mapper.Map<List<MedicineManufactoryVM>>(manufactory);
            return View(manufactoryVM);
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
        public IActionResult Create(MedicineManufactoryVM manufactoryVM)
        {
            if (ModelState.IsValid)
            {
                var manufactory = _mapper.Map<MedicineManufactory>(manufactoryVM);
                _unitOfWork.MedicineManufactoryRepository.Create(manufactory);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(manufactoryVM);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var manufactory = _unitOfWork.MedicineManufactoryRepository.RetriveItem(m => m.Id == id);
            if (manufactory == null)
            {
                return NotFound();
            }
            var manufactoryVM = _mapper.Map<MedicineManufactoryVM>(manufactory);
            return View(manufactoryVM);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MedicineManufactoryVM manufactoryVM)
        {
            if (ModelState.IsValid)
            {
                var manufactory = _mapper.Map<MedicineManufactory>(manufactoryVM);
                _unitOfWork.MedicineManufactoryRepository.Update(manufactory);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(manufactoryVM);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            var manufactory = _unitOfWork.MedicineManufactoryRepository.RetriveItem(m => m.Id == id);
            if (manufactory == null)
            {
                return NotFound();
            }
            var manufactoryVM = _mapper.Map<MedicineManufactoryVM>(manufactory);
            return View(manufactoryVM);
        }

        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var manufactory = _unitOfWork.MedicineManufactoryRepository.RetriveItem(m => m.Id == id);
            if (manufactory != null)
            {
                _unitOfWork.MedicineManufactoryRepository.Delete(manufactory);
                _unitOfWork.Commit();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

