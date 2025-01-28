using CMS.Models.CuraHub.PersonalDetails.CustomerSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.MedicalAnalysisLabSection
{
    public class MedicalAnalysisLabCustomer : Customer
    {
        
        public List<MedicalAnalysisTestCustomer>? MedicalAnalysisTestCustomers { get; set; }
        public List<MedicalAnalysisTestResult>? MedicalAnalysisTestResults { get; set; }

        public List<MedicalAnalysisLabAppointment>? MedicalAnalysisLabAppointments { get; set; }
    }
}
