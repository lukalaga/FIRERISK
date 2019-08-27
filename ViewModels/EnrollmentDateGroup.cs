using System;
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        public int OrganizationCount { get; set; }
    }
}