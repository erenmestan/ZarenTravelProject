namespace ZarenTravelProject.Models
{
    public class HotelSearchResponse
    {
        public List<HotelResult> Results { get; set; }
        public int Provider { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string SearchId { get; set; }
        public string CacheKey { get; set; }
   
    }
}
