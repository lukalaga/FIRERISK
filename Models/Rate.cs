using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Rate
    {
        [Key]
        public string RateID { get; set; }
        public string RateValue { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}