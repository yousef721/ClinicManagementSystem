using AutoMapper;
using CMS.Models.CuraHub.IdentitySection.IdentitySectionVM;
using CMS.Models.CuraHub.IdentitySection;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM;
using CMS.Models.CuraHub.ClinicSection;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.ClinicReceptionistVM;

namespace CMS.Perestation.Layer.Areas.Admin.AdminMappingProfiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserVM>().ReverseMap();
            CreateMap<ApplicationUser, ProfileVM>().ReverseMap();
            CreateMap<Doctor, DoctorVM>().ReverseMap();
            CreateMap<Doctor, DoctorCreateEditVM>().ReverseMap();
            CreateMap<Doctor, DoctorDetailsVM>().ReverseMap();

            CreateMap<ClinicReceptionist, ClinicReceptionistCreateEditVM>().ReverseMap();

            CreateMap<ClinicReceptionist, ClinicReceptionistDetailsVM>().ReverseMap();

            
            CreateMap<Qualification, QualificationCreateEditVM>().ReverseMap();

            CreateMap<Specialization, SpecializationVM>().ReverseMap();

        }
    }
}
