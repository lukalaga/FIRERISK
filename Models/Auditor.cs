
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Auditor
    {
        [Key]
        public string RegistrationNo { get; set; }
        public string AuditorName { get; set; }
        public string Organization { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}