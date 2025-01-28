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
        public IActionResult Create(PharmacyDeliveryRepresentativeVM PharmacyDeliveryVM)
        {
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            if (ModelState.IsValid)
            {
                if (PharmacyDeliveryVM.FileProfile != null && PharmacyDeliveryVM.FileProfile.Length > 0)
                {
                    // Generate name
                    var fileProfile = Guid.NewGuid().ToString() + Path.GetExtension(PharmacyDeliveryVM.FileProfile.FileName);

                    // Save in wwwroot
                    var filePathProfile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileProfile);

                    using (var stream = System.IO.File.Create(filePathProfile))
                    {
                        PharmacyDeliveryVM.FileProfile.CopyTo(stream);
                    }
                    // Save in db
                    PharmacyDeliveryVM.ProfilePicture = fileProfile;
                }
                if (PharmacyDeliveryVM.FileNationalIDCard != null && PharmacyDeliveryVM.FileNationalIDCard.Length > 0)
                {
                    // Generate name
                    var fileCard = Guid.NewGuid().ToString() + Path.GetExtension(PharmacyDeliveryVM.FileNationalIDCard.FileName);

                    // Save in wwwroot
                    var filePathCard = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileCard);

                    using (var stream = System.IO.File.Create(filePathCard))
                    {
                        PharmacyDeliveryVM.FileNationalIDCard.CopyTo(stream);
                    }
                    // Save in db
                    PharmacyDeliveryVM.PersonalNationalIDCard = fileCard;
                }
                var PharmacyDelivery = _mapper.Map<PharmacyDeliveryRepresentative>(PharmacyDeliveryVM);
                _unitOfWork.PharmacyDeliveryRepresentativeRepository.Create(PharmacyDelivery);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(PharmacyDeliveryVM);
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
        public IActionResult Edit(PharmacyDeliveryRepresentativeVM PharmacyDeliveryVM)
        {
            ModelState.Remove("ProfilePicture");
            ModelState.Remove("PersonalNationalIDCard");
            ModelState.Remove("FileProfile");
            ModelState.Remove("FileNationalIDCard");
            var oldDeliveryPhoto = _unitOfWork.PharmacyDeliveryRepresentativeRepository.RetriveItem(e => e.Id == PharmacyDeliveryVM.Id, trancked: false);
            if (ModelState.IsValid)
            {
                if (PharmacyDeliveryVM.FileProfile != null && PharmacyDeliveryVM.FileProfile.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(PharmacyDeliveryVM.FileProfile.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        PharmacyDeliveryVM.FileProfile.CopyTo(stream);
                    }

                    // Delete old img
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldDeliveryPhoto.ProfilePicture);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    // Save new img
                    PharmacyDeliveryVM.ProfilePicture = fileName;
                } else
                {
                    PharmacyDeliveryVM.ProfilePicture = oldDeliveryPhoto.ProfilePicture;

                }
                if (PharmacyDeliveryVM.FileNationalIDCard != null && PharmacyDeliveryVM.FileNationalIDCard.Length > 0)
                {
                    // Generate name
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(PharmacyDeliveryVM.FileNationalIDCard.FileName);

                    // Save in wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", fileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        PharmacyDeliveryVM.FileNationalIDCard.CopyTo(stream);
                    }

                    // Delete old img
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "images", oldDeliveryPhoto.PersonalNationalIDCard);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    // Save new img
                    PharmacyDeliveryVM.PersonalNationalIDCard = fileName;
                } else
                {
                    PharmacyDeliveryVM.PersonalNationalIDCard = oldDeliveryPhoto.PersonalNationalIDCard;

                }
                var pharmacyDeliveryRepresentative = _mapper.Map<PharmacyDeliveryRepresentative>(PharmacyDeliveryVM);
                _unitOfWork.PharmacyDeliveryRepresentativeRepository.Update(pharmacyDeliveryRepresentative);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }

            return View(PharmacyDeliveryVM);
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
            var delivery = _unitOfWork.PharmacyDeliveryRepresentativeRepository.RetriveItem(p => p.Id == id);
            if (delivery == null) return NotFound();
            if (System.IO.File.Exists(delivery.ProfilePicture))
            {
                System.IO.File.Delete(delivery.ProfilePicture);
            }
            if (System.IO.File.Exists(delivery.PersonalNationalIDCard))
            {
                System.IO.File.Delete(delivery.PersonalNationalIDCard);
            }

            _unitOfWork.PharmacyDeliveryRepresentativeRepository.Delete(delivery);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
