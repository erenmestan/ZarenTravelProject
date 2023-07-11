namespace ZarenTravelProject.Models
{
    public class HotelSearchResponse
    {
        public List<HotelResult> results { get; set; }
        public int provider { get; set; }
        public DateTime expiresOn { get; set; }
        public string searchId { get; set; }
        public string cacheKey { get; set; }
   
    }
}
