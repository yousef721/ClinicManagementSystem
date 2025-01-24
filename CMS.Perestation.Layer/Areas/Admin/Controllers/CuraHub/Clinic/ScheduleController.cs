using AutoMapper;
using CMS.Data.Access.Layer.Repository.IRepository;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM;
using CMS.Models.CuraHub.IdentitySection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Perestation.Layer.Areas.Admin.Controllers.CuraHub.Clinic
{
    [Area(nameof(Admin))]
    //[Authorize(Roles = ($"{Role.AdminRole}"))]
    [Route("Admin/CuraHub/Clinic/Schedule")]
    public class ScheduleController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ScheduleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }



        [Route("Index")]
        public IActionResult Index(int? doctorId = null , int PageNumber = 1)
        {
            var Schedules = this._unitOfWork.ScheduleRepository.Retrive(includeProps: [e => e.Doctor]);

            SchedulesVM schedulesVM = new SchedulesVM();
            if (doctorId != null)
            {
                Schedules = Schedules.Where(e => e.DoctorId == doctorId);
            }
            if( PageNumber<1) { PageNumber =1; }
            schedulesVM.currentPageNumber = PageNumber;
            schedulesVM.TotalSchedulesCount = Schedules.Count();
            schedulesVM.Schedules = Schedules.ToList();
            schedulesVM.Doctors = this._unitOfWork.DoctorRepository.Retrive().ToList();
            return View(schedulesVM);
        }


        [Route("LockAvailable")]
        public IActionResult LockAvailable(int ScheduleId)
        {
            var schedule = this._unitOfWork.ScheduleRepository.RetriveItem(filter: e => e.Id == ScheduleId);
            if (schedule != null)
            {
                schedule.Available = false;
                this._unitOfWork.ScheduleRepository.Update(schedule);
                this._unitOfWork.Commit();
            }
            return RedirectToAction("Index", "Schedule", new { area = "Admin" });
        }
        [Route("UnLockAvailable")]
        public IActionResult UnLockAvailable(int ScheduleId)
        {
            var schedule = this._unitOfWork.ScheduleRepository.RetriveItem(filter: e => e.Id == ScheduleId);
            if (schedule != null)
            {
                schedule.Available = true;
                this._unitOfWork.ScheduleRepository.Update(schedule);
                this._unitOfWork.Commit();
            }
            return RedirectToAction("Index", "Schedule", new { area = "Admin" });
        }


    }
}
