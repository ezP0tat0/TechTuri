using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class Picture
    {
        public int id { get;set; }
        public byte[] bytes { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string fileExtension { get; set; }
        public decimal size { get; set; }
        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
    }
}
