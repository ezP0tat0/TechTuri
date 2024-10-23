using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model
{
    public class ProfilexItem
    {
        public int id { get; set; }
        [ForeignKey("ProfileId")]
        public int ProfileID { get; set; }
        [ForeignKey("ItemId")]
        public int ItemID { get; set; }
    }
}
