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
        public IActionResult Index(int pageNumber)
        {
            var pharmacists = _unitOfWork.PharmacistRepository.Retrive();
            pharmacists = pharmacists.Skip(pageNumber * 8).Take(8);
            pharmacists.ToList();
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
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            ModelState.Remove("BloodType");
            if (ModelState.IsValid)
            {
                if (pharmacistVM.FileProfile != null && pharmacistVM.FileProfile.Length > 0)
                {
                    // Generate name
                    var fileProfile = Guid.NewGuid().ToString() + Path.GetExtension(pharmacistVM.FileProfile.FileName);

                    // Save in wwwroot
                    var filePathProfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileProfile);

                    using (var stream = System.IO.File.Create(filePathProfile))
                    {
                        pharmacistVM.FileProfile.CopyTo(stream);
                    }
                    // Save in db
                    pharmacistVM.ProfilePicture = fileProfile;
                }
                if (pharmacistVM.FileNationalIDCard != null && pharmacistVM.FileNationalIDCard.Length > 0)
                {
                    // Generate name
                    var fileCard = Guid.NewGuid().ToString() + Path.GetExtension(pharmacistVM.FileNationalIDCard.FileName);

                    // Save in wwwroot
                    var filePathCard = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileCard);

                    using (var stream = System.IO.File.Create(filePathCard))
                    {
                        pharmacistVM.FileNationalIDCard.CopyTo(stream);
                    }
                    // Save in db
                    pharmacistVM.PersonalNationalIDCard = fileCard;
                }
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
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            ModelState.Remove("BloodType");
            ModelState.Remove("FileProfile");
            ModelState.Remove("FileNationalIDCard");
            var oldPharmacistPhoto = _unitOfWork.PharmacistRepository.RetriveItem(e => e.Id == pharmacistVM.Id, trancked: false);
            if (ModelState.IsValid)
            {
                if (pharmacistVM.FileProfile != null && pharmacistVM.FileProfile.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(pharmacistVM.FileProfile.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        pharmacistVM.FileProfile.CopyTo(stream);
                    }

                    // Delete old img
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldPharmacistPhoto.ProfilePicture);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    // Save new img
                    pharmacistVM.ProfilePicture = fileName;
                } else
                {
                    pharmacistVM.ProfilePicture = oldPharmacistPhoto.ProfilePicture;
                }

                if (pharmacistVM.FileNationalIDCard != null && pharmacistVM.FileNationalIDCard.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(pharmacistVM.FileNationalIDCard.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        pharmacistVM.FileNationalIDCard.CopyTo(stream);
                    }

                    // Delete old img
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldPharmacistPhoto.PersonalNationalIDCard);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    // Save new img
                    pharmacistVM.PersonalNationalIDCard = fileName;
                } else
                {
                    pharmacistVM.PersonalNationalIDCard = oldPharmacistPhoto.PersonalNationalIDCard;
                }
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
            var pharmacist = _unitOfWork.PharmacistRepository.RetriveItem(p => p.Id == id);
            if (pharmacist == null) return NotFound();
            if (System.IO.File.Exists(pharmacist.ProfilePicture))
            {
                System.IO.File.Delete(pharmacist.ProfilePicture);
            }
            if (System.IO.File.Exists(pharmacist.PersonalNationalIDCard))
            {
                System.IO.File.Delete(pharmacist.PersonalNationalIDCard);
            }
            _unitOfWork.PharmacistRepository.Delete(pharmacist);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
