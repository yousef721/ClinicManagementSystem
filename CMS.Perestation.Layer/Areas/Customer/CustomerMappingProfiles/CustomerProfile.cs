using AutoMapper;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.ClinicReceptionistVM;
using CMS.Models.CuraHub.ClinicSection;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.RequestDoctorSectionVM;
using CMS.Models.CuraHub.ClinicSection.ClinicSectionVM.RequestClinicReceptionistSectionVM;

namespace CMS.Perestation.Layer.Areas.Customer.CustomerMappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<RequestDoctor, Cust_RequestDoctorCreateVM>().ReverseMap();

            CreateMap<RequestClinicReceptionist, Cust_RequestClinicReceptionistCreateVM>().ReverseMap();


        }
    }
}
