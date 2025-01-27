using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/Medicine")]
    
    public class MedicineController : Controller
    {
        private readonly IUnitOfWork _uintOfWork;
        private readonly IMapper _mapper;

        public MedicineController(IUnitOfWork uintOfWork, IMapper mapper)
        {
            this._uintOfWork = uintOfWork;
            this._mapper = mapper;
        }
        [Route("Index")]
        public ActionResult Index()
        {
            var medicine = _uintOfWork.MedicineRepository.Retrive(includeProps: [e => e.MedicineManufactory, e => e.PharmacyCategory]).ToList();
            var viewModel = _mapper.Map<List<MedicineVM>>(medicine);
            return View(viewModel);
        }
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            var pharmacyCategories = _uintOfWork.PharmacyCategoryRepository.Retrive().ToList();
            var manufactories = _uintOfWork.MedicineManufactoryRepository.Retrive().ToList();
            List<PharmacyCategoryVM> tempPharmacy = new List<PharmacyCategoryVM>();
            List<MedicineManufactoryVM> tempManufactory = new List<MedicineManufactoryVM>();
            foreach (var pharmacy in pharmacyCategories)
            {
                tempPharmacy.Add(_mapper.Map<PharmacyCategoryVM>(pharmacy));
            }
            foreach (var manufactory in manufactories)
            {
                tempManufactory.Add(_mapper.Map<MedicineManufactoryVM>(manufactory));
            }
            ViewData["PharmacyCategory"] = tempPharmacy;
            ViewData["MedicineManufactory"] = tempManufactory;
            return View();
        }
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicineVM medicineVM)
        {
            ModelState.Remove("Img");
            ModelState.Remove("PharmacyCategory.Name");
            ModelState.Remove("MedicineManufactory.Name");
            if (ModelState.IsValid)
            {
                if (medicineVM.File != null && medicineVM.File.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(medicineVM.File.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        medicineVM.File.CopyTo(stream);
                    }
                    // Save in db
                    medicineVM.Img = fileName;
                }
                var medicine = _mapper.Map<Medicine>(medicineVM);
                _uintOfWork.MedicineRepository.Create(medicine);
                _uintOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            var pharmacyCategories = _uintOfWork.PharmacyCategoryRepository.Retrive().ToList();
            var manufactories = _uintOfWork.MedicineManufactoryRepository.Retrive().ToList();
            ViewData["PharmacyCategory"] = _mapper.Map<List<PharmacyCategoryVM>>(pharmacyCategories);
            ViewData["MedicineManufactory"] = _mapper.Map<List<MedicineManufactoryVM>>(manufactories);
            return View(medicineVM);
        }
        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(int id) 
        {
            var medicine = _uintOfWork.MedicineRepository.RetriveItem(e => e.Id == id);
            var medicineVM = _mapper.Map<MedicineVM>(medicine);
            ViewData["MedicineManufactory"] = _uintOfWork.MedicineManufactoryRepository.Retrive().ToList();
            ViewData["MedicineCategory"] = _uintOfWork.PharmacyCategoryRepository.Retrive().ToList();
            return View(medicineVM);
        }
        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicineVM medicineVM) 
        {
            ModelState.Remove("Img");
            ModelState.Remove("PharmacyCategory");
            ModelState.Remove("Manufactories");
            var oldMedicine = _uintOfWork.MedicineRepository.RetriveItem(e => e.Id == medicineVM.Id);
            if (ModelState.IsValid)
            {
                if (medicineVM.File != null && medicineVM.File.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(medicineVM.File.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        medicineVM.File.CopyTo(stream);
                    }

                    // Delete old img
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldMedicine.Img);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    // Save new img
                    medicineVM.Img = fileName;
                }
                var medicine = _mapper.Map<Medicine>(medicineVM);
                _uintOfWork.MedicineRepository.Update(medicine);
                _uintOfWork.Commit();
                return RedirectToAction("Index");
            }
            var pharmacyCategories = _uintOfWork.PharmacyCategoryRepository.Retrive().ToList();
            var manufactories = _uintOfWork.MedicineManufactoryRepository.Retrive().ToList();
            ViewData["PharmacyCategory"] = _mapper.Map<List<PharmacyCategoryVM>>(pharmacyCategories);
            ViewData["MedicineManufactory"] = _mapper.Map<List<MedicineManufactoryVM>>(manufactories);
            return View(medicineVM);
        }
        [Route(nameof(Details))]
        public ActionResult Details(int id)
        {
            var medicine =  _uintOfWork.MedicineRepository.RetriveItem(e => e.Id == id);
            if(medicine != null)
            {
                var medicineVM = _mapper.Map<MedicineVM>(medicine);
                return View(medicineVM);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            var medicine = _uintOfWork.MedicineRepository.RetriveItem(e => e.Id == id);
            if (System.IO.File.Exists(medicine.Img))
            {
                System.IO.File.Delete(medicine.Img);
            }
            _uintOfWork.MedicineRepository.Delete(medicine);
            _uintOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
