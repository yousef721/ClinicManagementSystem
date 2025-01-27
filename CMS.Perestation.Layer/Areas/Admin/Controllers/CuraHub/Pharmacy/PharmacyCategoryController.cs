using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/PharmacyCategory")]
    public class PharmacyCategoryController : Controller
    {
       private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Index")]
        public  IActionResult Index()
        {
            var categories = _unitOfWork.PharmacyCategoryRepository.Retrive().ToList();
            var viewModel = _mapper.Map<List<PharmacyCategoryVM>>(categories);
            return View(viewModel);
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
        public  IActionResult Create(PharmacyCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<PharmacyCategory>(model);
                _unitOfWork.PharmacyCategoryRepository.Create(category);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpGet]
        [Route("Edit")]
        public  IActionResult Edit(int id)
        {
            var category = _unitOfWork.PharmacyCategoryRepository.RetriveItem(e => e.Id == id);
            if (category == null)
                return NotFound();

            var viewModel = _mapper.Map<PharmacyCategoryVM>(category);
            return View(viewModel);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PharmacyCategoryVM model)
        {
            if (id != model.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<PharmacyCategory>(model);
                _unitOfWork.PharmacyCategoryRepository.Update(category);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        [HttpGet]
        [Route(nameof(Details))]
        public IActionResult Details(int id)
        {
            var category =  _unitOfWork.PharmacyCategoryRepository.RetriveItem(e => e.Id == id);
            if (category == null)
                return NotFound();

            var viewModel = _mapper.Map<PharmacyCategoryVM>(category);
            return View(viewModel);
        }
        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.PharmacyCategoryRepository.RetriveItem(e => e.Id == id);
            if (category == null)
                return NotFound();
            _unitOfWork.PharmacyCategoryRepository.Delete(category);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
