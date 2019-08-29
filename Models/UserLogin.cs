using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class UserLogin
    {
        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username Required!")]
        [Display(Name ="Username")]
        public string AuditorName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}