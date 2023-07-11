namespace ZarenTravelProject.Models
{
    public class HotelSearchRequestVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public string query { get; set; }
        public string locationId { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
        public string nationality { get; set; }
        public int sortBy { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public List<OccupantsVM> occupants { get; set; }
    }
}
