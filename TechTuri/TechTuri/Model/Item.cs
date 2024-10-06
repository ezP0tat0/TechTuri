namespace TechTuri.Model
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public bool sold { get; set; }
        public DateTime date { get; set; }
        //pics?
        //location?
    }
}
