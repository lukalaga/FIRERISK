using System.ComponentModel.DataAnnotations;

namespace FIRERISK.Models
{
    public class Comment
    {
        #region Class Properties
        [Key]
        public string CID { get; set; }
        public string Comments { get; set; }
        #endregion

        #region Linked To Item Class
        public string ItemID { get; set; }
        public string RateID { get; set; }
        #endregion
        public virtual Item Item { get; set; }
        public virtual Rate Rate { get; set; }
    }
}