using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CMS.Models.CuraHub.PharmacySection.PharmacySectionVM;

public class PharmacyCustomerVM 
{
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Street { get; set; } = null!;   
        [RegularExpression("^(A+|A-|B+|B-|AB+|AB-|O+|O-)$", ErrorMessage = "Blood Type must be 'A+','A-','B+','B-','AB+','AB-','O+','O-'")]
        public string? BloodType { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public string Gender { get; set; } = null!;
        public string ProfilePicture { get; set; } = null!;
        [Required(ErrorMessage = "Please upload a file.")]
        [DataType(DataType.Upload)]
        public IFormFile FileProfile { get; set; }
        public string PersonalNationalIDNumber { get; set; } = null!;
        public string PersonalNationalIDCard { get; set; } = null!; 
        [Required(ErrorMessage = "Please upload a file.")]
        [DataType(DataType.Upload)]
        public IFormFile FileNationalIDCard { get; set; }
        public List<PharmacyOrderVM>? PharmacyOrders { get; set; }
}
