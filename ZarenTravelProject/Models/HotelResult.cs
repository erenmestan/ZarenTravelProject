namespace ZarenTravelProject.Models
{
    public class HotelResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HotelPrice MinPrice { get; set; }
        public HotelPrice MaxPrice { get; set; }
    }
}