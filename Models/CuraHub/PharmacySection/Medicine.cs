using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.Enums;

namespace CMS.Models.CuraHub.PharmacySection
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null!;
        public string Status { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Img { get; set; }
        public int PharmacyCategoryId { get; set; }
        public PharmacyCategory PharmacyCategory { get; set; } = new PharmacyCategory();
        public List<MedicineOrder>? MedicineOrders { get; set; }
        public int MedicineManufactoryId { get; set; }
        public MedicineManufactory MedicineManufactory { get; set; } = null!;
    }
}
