using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class Picture
    {
        public int id { get; set; }
        public string filePath { get; set; }

        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
    }
}
