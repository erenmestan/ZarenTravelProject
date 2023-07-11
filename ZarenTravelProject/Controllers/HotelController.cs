using Microsoft.AspNetCore.Mvc;
using ZarenTravelProject.Models;
using ZarenTravelProject.Services;

namespace ZarenTravelProject.Controllers
{
    public class HotelController : Controller
    {
        private readonly TravelService _travelService;

        public HotelController(TravelService travelService)
        {
            _travelService = travelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SearchHotel(HotelSearchRequestVM hotelSearchRequestVm)
        {
            hotelSearchRequestVm.query="string";
            hotelSearchRequestVm.currency = "EUR";
            hotelSearchRequestVm.culture = "tr-TR";
            hotelSearchRequestVm.nationality = "TR";
            hotelSearchRequestVm.page = 1;
            hotelSearchRequestVm.pageSize = 100;
            OccupantsVM occupants = new OccupantsVM();
            occupants.adults = 1;

            hotelSearchRequestVm.occupants = new List<OccupantsVM>();
            hotelSearchRequestVm.occupants.Add(occupants);
            var response = await _travelService.GetHotelLocations(hotelSearchRequestVm);
  
            return PartialView("SearchHotel", response);

        }
        
    }
}
