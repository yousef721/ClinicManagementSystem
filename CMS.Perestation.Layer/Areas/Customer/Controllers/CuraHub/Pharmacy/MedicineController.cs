using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Pharmacy/Medicine")]
    public class MedicineController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;

        public MedicineController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager )
        {
            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [Route("Index")]
        public IActionResult Index(int categoryId = 0, int pageNumber = 0)
        {
            var medicine = _unitOfWork.MedicineRepository.Retrive();
            if (categoryId != 0)
            {
                medicine = _unitOfWork.MedicineRepository.Retrive(e => e.PharmacyCategory.Id == categoryId);
            } 
            ViewData["MedicineInCart"] = _unitOfWork.PharmacyCartRepository.Retrive().ToList();
            // ViewData["countMedicine"] = medicine.Count();

            medicine = medicine.Skip(pageNumber * 8).Take(8);
   

            return View(medicine.ToList());
        }

       [Route("Details")]
        public IActionResult Details(int medicineId)
        {
            var medicine = _unitOfWork.MedicineRepository.RetriveItem(e => e.Id == medicineId, [e => e.MedicineManufactory]);
            var medicineInCartCount = _unitOfWork.PharmacyCartRepository.RetriveItem(e => e.MedicineId == medicine.Id);
            var userId = userManager.GetUserId(User);
   
            MedicineDetailsVM medicineDetailsVM = new MedicineDetailsVM
            {
                Medicine = medicine,
                PharmacyCart = medicineInCartCount,
                UserId = userId
            };

            return View(medicineDetailsVM);
        }
        [HttpGet]
        [Route("SearchMedicine")]
        public IActionResult SearchMedicine(string searchText, int pageNumber)
        {
            var medicine = _unitOfWork.MedicineRepository.Retrive(e => e.Name.ToLower().Contains(searchText.ToLower()) || e.Description.ToLower().Contains(searchText.ToLower()));
            ViewData["MedicineInCart"] = _unitOfWork.PharmacyCartRepository.Retrive().ToList();

            medicine = medicine.Skip(pageNumber * 8).Take(8);

            
            return PartialView("_SearchMedicine",medicine.ToList());
        }

    }
}
