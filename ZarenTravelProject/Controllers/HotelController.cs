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
            hotelSearchRequestVm.Query="string";
            hotelSearchRequestVm.Currency = "EUR";
            hotelSearchRequestVm.Culture = "tr-TR";
            hotelSearchRequestVm.Nationality = "TR";
            hotelSearchRequestVm.Page = 1;
            hotelSearchRequestVm.PageSize = 100;
            var occupants = new OccupantsVM
            {
                Adults = 1
            };

            hotelSearchRequestVm.Occupants = new List<OccupantsVM> {occupants};
            var response = await _travelService.GetHotelLocations(hotelSearchRequestVm);

            return PartialView("SearchHotel", response);
        }
    }
}
