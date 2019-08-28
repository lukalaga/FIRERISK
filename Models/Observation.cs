using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Observation
    {
        #region Class Properties

        [Key]
        public string ObID { get; set; }

        public string Statement { get; set; }

        #endregion Class Properties

        #region Related to Class

        public string RuleID { get; set; }
        public virtual Rule Rules { get; set; }

        #endregion Related to Class
    }
}