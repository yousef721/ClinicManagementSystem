﻿using CMS.Models.CuraHub.PersonalDetails.EmployeeSection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.CuraHub.PersonalDetails.EmployeeSection.ReceptionistSection
{
    [NotMapped]
    public abstract class RequestReceptionist : Employee
    {
        public double ExpectedSalary { get; set; }
        public string Details { get; set; } = null!;
    }
}
