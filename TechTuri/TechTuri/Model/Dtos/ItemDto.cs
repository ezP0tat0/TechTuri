namespace TechTuri.Model.Dtos
{
    public class ItemDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string category { get; set; }
        public string condition { get; set; }
        public string location { get; set; }
        //public DateTime date { get; set; }
        public int userId { get; set; }
        public List<PictureDto> pictures { get; set; }
    }

    public class ItemSmallDto
    {
        public string name { get; set; }
        public int price { get; set; }
        public bool sold { get; set; }
        public string location { get; set; }
    }
    public class PictureDto
    {
        public IFormFile picture { get; set; }

    }
}
