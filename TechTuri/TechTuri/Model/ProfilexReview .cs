using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model
{
    public class ProfilexReview
    {
        public int id { get; set; }
        [ForeignKey("ProfileId")]
        public int ProfileID { get; set; }
        [ForeignKey("ReviewId")]
        public int ReviewID { get; set; }
    }
}
