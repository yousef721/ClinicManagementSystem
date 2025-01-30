using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;
using CMS.Models.CuraHub.PharmacySection;


namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Pharmacy
{
    [Area(nameof(Admin))]
    [Route("Admin/CuraHub/Pharmacy/pharmacyCustomer")]
    public class PharmacyCustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PharmacyCustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var pharmacyCustomer = _unitOfWork.PharmacyCustomerRepository.Retrive().ToList();
            var pharmacyCustomerVM = _mapper.Map<List<PharmacyCustomerVM>>(pharmacyCustomer);
            return View(pharmacyCustomerVM);
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
        public IActionResult Create(PharmacyCustomerVM pharmacyCustomerVM)
        {
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            if (ModelState.IsValid)
            {
                //if (pharmacyCustomerVM.FileProfile != null && pharmacyCustomerVM.FileProfile.Length > 0)
                //{
                //    // Generate name
                //    var fileProfile = Guid.NewGuid().ToString() + Path.GetExtension(pharmacyCustomerVM.FileProfile.FileName);

                //    // Save in wwwroot
                //    var filePathProfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileProfile);

                //    using (var stream = System.IO.File.Create(filePathProfile))
                //    {
                //        pharmacyCustomerVM.FileProfile.CopyTo(stream);
                //    }
                //    // Save in db
                //    pharmacyCustomerVM.ProfilePicture = fileProfile;
                //}
                //if (pharmacyCustomerVM.FileNationalIDCard != null && pharmacyCustomerVM.FileNationalIDCard.Length > 0)
                //{
                //    // Generate name
                //    var fileCard = Guid.NewGuid().ToString() + Path.GetExtension(pharmacyCustomerVM.FileNationalIDCard.FileName);

                //    // Save in wwwroot
                //    var filePathCard = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileCard);

                //    using (var stream = System.IO.File.Create(filePathCard))
                //    {
                //        pharmacyCustomerVM.FileNationalIDCard.CopyTo(stream);
                //    }
                //    // Save in db
                //    pharmacyCustomerVM.PersonalNationalIDCard = fileCard;
                //}
               
                
                var pharmacyCustomer = _mapper.Map<PharmacyCustomer>(pharmacyCustomerVM);
                _unitOfWork.PharmacyCustomerRepository.Create(pharmacyCustomer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacyCustomerVM);
        }


        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var pharmacyCustomer = _unitOfWork.PharmacyCustomerRepository.RetriveItem(p => p.Id == id);
            if (pharmacyCustomer == null) return NotFound();

            var pharmacyCustomerVM = _mapper.Map<PharmacyCustomerVM>(pharmacyCustomer);
            return View(pharmacyCustomerVM);
        }

        [HttpPost]
        [Route("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PharmacyCustomerVM pharmacyCustomerVM)
        {
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            ModelState.Remove("FileProfile");
            ModelState.Remove("FileNationalIDCard");
            var oldCustomerPhoto = _unitOfWork.PharmacyCustomerRepository.RetriveItem(e => e.Id == pharmacyCustomerVM.Id, trancked: false);
            if (ModelState.IsValid)
            {
                #region

                //if (pharmacyCustomerVM.FileProfile != null && pharmacyCustomerVM.FileProfile.Length > 0)
                //{
                //    // Generate name
                //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(pharmacyCustomerVM.FileProfile.FileName);

                //    // Save in wwwroot
                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                //    using (var stream = System.IO.File.Create(filePath))
                //    {
                //        pharmacyCustomerVM.FileProfile.CopyTo(stream);
                //    }

                //    // Delete old img
                //    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Images", oldCustomerPhoto.ProfilePicture);
                //    if (System.IO.File.Exists(oldPath))
                //    {
                //        System.IO.File.Delete(oldPath);
                //    }
                //    // Save new img
                //    pharmacyCustomerVM.ProfilePicture = fileName;
                //} else
                //{
                //    pharmacyCustomerVM.ProfilePicture = oldCustomerPhoto.ProfilePicture;

                //}
                //if (pharmacyCustomerVM.FileNationalIDCard != null && pharmacyCustomerVM.FileNationalIDCard.Length > 0)
                //{
                //    // Generate name
                //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(pharmacyCustomerVM.FileNationalIDCard.FileName);

                //    // Save in wwwroot
                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                //    using (var stream = System.IO.File.Create(filePath))
                //    {
                //        pharmacyCustomerVM.FileNationalIDCard.CopyTo(stream);
                //    }

                //    // Delete old img
                //    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldCustomerPhoto.PersonalNationalIDCard);
                //    if (System.IO.File.Exists(oldPath))
                //    {
                //        System.IO.File.Delete(oldPath);
                //    }
                //    // Save new img
                //    pharmacyCustomerVM.PersonalNationalIDCard = fileName;
                //} else 
                //{
                //    pharmacyCustomerVM.PersonalNationalIDCard = oldCustomerPhoto.PersonalNationalIDCard;
                //}
                #endregion
                var pharmacyCustomer = _mapper.Map<PharmacyCustomer>(pharmacyCustomerVM);
                _unitOfWork.PharmacyCustomerRepository.Update(pharmacyCustomer);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(pharmacyCustomerVM);
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            var pharmacyCustomer = _unitOfWork.PharmacyCustomerRepository.RetriveItem(d => d.Id == id, [d => d.PharmacyOrders]);
            if (pharmacyCustomer == null) return NotFound();

            var pharmacyCustomerVM = _mapper.Map<PharmacyCustomerVM>(pharmacyCustomer);
            return View(pharmacyCustomerVM);
        }

        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var pharmacyCustomer = _unitOfWork.PharmacyCustomerRepository.RetriveItem(p => p.Id == id);
            if (pharmacyCustomer == null) return NotFound();
            //if (System.IO.File.Exists(pharmacyCustomer.ProfilePicture))
            //{
            //    System.IO.File.Delete(pharmacyCustomer.ProfilePicture);
            //}
            //if (System.IO.File.Exists(pharmacyCustomer.PersonalNationalIDCard))
            //{
            //    System.IO.File.Delete(pharmacyCustomer.PersonalNationalIDCard);
            //}

            _unitOfWork.PharmacyCustomerRepository.Delete(pharmacyCustomer);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
