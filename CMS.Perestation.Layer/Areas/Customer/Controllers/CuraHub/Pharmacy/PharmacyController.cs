using CMS.Data.Access.Layer.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMS.Perestation.Layer.Areas.Customer.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Customer))]
    [Route("Customer/CuraHub/Pharmacy")]
    public class PharmacyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PharmacyController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var medicineCategories = _unitOfWork.PharmacyCategoryRepository.Retrive().ToList();
            return View(medicineCategories);
        }

        [HttpGet]
        [Route("SearchMedicines")]
        public IActionResult SearchMedicines(string searchText)
        {
            var medicines = _unitOfWork.MedicineRepository.Retrive(m => m.Name.Contains(searchText)).ToList();

            return PartialView("_SearchMedicineList", medicines);
        }
    }
}
