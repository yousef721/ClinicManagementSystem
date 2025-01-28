using System;

namespace CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;

public class MedicineCreateVM
{
    public List<PharmacyCategory> pharmacyCategories{ get; set; } = new List<PharmacyCategory>();
    public List<MedicineManufactory> medicineManufactories { get; set; } = new List<MedicineManufactory>();
    public MedicineVM MedicineVM { get; set; } = new MedicineVM();
}
