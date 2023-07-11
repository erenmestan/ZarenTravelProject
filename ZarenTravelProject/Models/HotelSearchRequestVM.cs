namespace ZarenTravelProject.Models
{
    public class HotelSearchRequestVM
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public string LocationId { get; set; }
        public string Currency { get; set; }
        public string Culture { get; set; }
        public string Nationality { get; set; }
        public int SortBy { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public List<OccupantsVM> Occupants { get; set; }
    }
}
