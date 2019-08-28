using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Rule
    {
        #region Class Properties

        [Key]
        public string RuleID { get; set; }

        public string Details { get; set; }

        #endregion Class Properties

        public virtual ICollection<Observation> Observations { get; set; }
    }
}