using CMS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.PharmacySection
{
    public class PharmacyOrder
    {
        public int Id { get; set; }
        public int Quentity { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }

        public int PharmacyCustomerId { get; set; }
        public PharmacyCustomer PharmacyCustomer { get; set; } = null!;
        public int PharmacyDeliveryRepresentativeId { get; set; }
        public PharmacyDeliveryRepresentative? PharmacyDeliveryRepresentative { get; set; }

        public List<MedicineOrder>? MedicineOrders { get; set; } 
    }
}
