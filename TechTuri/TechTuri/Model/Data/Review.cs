using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class Review
    {
        public int id { get; set; }
        public int stars { get; set; }
        public string comment { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
