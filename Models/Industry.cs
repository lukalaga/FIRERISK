using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIRERISK.Models
{
  
    public class Industry
    {
        [Key]
        public int IndutryID { get; set; } 
        public string IndustryType { get; set; }

        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}