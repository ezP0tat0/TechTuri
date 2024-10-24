using System.ComponentModel.DataAnnotations.Schema;

namespace TechTuri.Model.Data
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public string condition { get; set; }
        public DateTime date { get; set; }
        public string location { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
