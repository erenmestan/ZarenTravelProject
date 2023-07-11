namespace ZarenTravelProject.Models
{
    public class HotelResult
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public HotelPrice minPrice { get; set; }
        public HotelPrice maxPrice { get; set; }
    }
}