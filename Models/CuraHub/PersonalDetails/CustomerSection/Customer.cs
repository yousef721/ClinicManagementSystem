using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.PersonalDetails.CustomerSection
{
    [NotMapped]

    public abstract class Customer : PersonalDetails
    {
        public string Gender { get; set; } = null!;
        public string ProfilePicture { get; set; } = null!;
        public string PersonalNationalIDNumber { get; set; } = null!;
        public string PersonalNationalIDCard { get; set; } = null!;
        public string? BloodType { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
