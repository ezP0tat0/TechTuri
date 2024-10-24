using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class ProfilexReview
    {
        public int id { get; set; }
        [ForeignKey("UserId")]
        public int UserID { get; set; }
        [ForeignKey("ReviewId")]
        public int ReviewID { get; set; }
    }
}
