using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.CuraHub.PersonalDetails.CustomerSection;

namespace CMS.Models.CuraHub.PharmacySection
{
    public class PharmacyCustomer : Customer
    {
        public List<PharmacyOrder>? PharmacyOrders { get; set; }
    }
}
