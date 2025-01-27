using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;

public class PharmacyCategoryVM
{
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
}
