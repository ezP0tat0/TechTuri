using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class Picture
    {
        public int id { get; set; }
        public byte[] imgData { get; set; }

        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
    }
}
