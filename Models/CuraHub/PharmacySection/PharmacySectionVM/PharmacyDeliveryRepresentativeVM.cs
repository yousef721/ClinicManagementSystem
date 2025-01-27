using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;

public class PharmacyDeliveryRepresentativeVM 
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public List<PharmacyOrderVM> PharmacyOrders { get; set; } = new List<PharmacyOrderVM>();
}
