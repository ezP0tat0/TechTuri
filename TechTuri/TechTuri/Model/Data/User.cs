namespace TechTuri.Model.Data
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public DateTime joinDate { get; set; }
        public byte[] pwHash { get; set; }
        public byte[] pwSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
