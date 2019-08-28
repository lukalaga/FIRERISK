using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Item
    {
        [Key]
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}