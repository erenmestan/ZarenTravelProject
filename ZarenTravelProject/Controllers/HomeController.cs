using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZarenTravelProject.Models;
using ZarenTravelProject.Services;

namespace ZarenTravelProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly TravelService _travelService;

        public HomeController(TravelService travelService)
        {
            _travelService = travelService;
        }
        public async Task<IActionResult> Index()
        {
            return View();

        }


        public async Task<IActionResult> SearchLocation(LocationSearchRequestVM locationSearchRequestVm)
        {
            var response = await _travelService.GetHotelLocations(locationSearchRequestVm);
            return PartialView("SearchLocation",response);

        }

        public async Task<IActionResult> SearchHotelWithLocation(string id)
        {
            HotelSearchRequestVM hotelSearchRequestVm = new HotelSearchRequestVM();
            hotelSearchRequestVm.locationId = id;
            hotelSearchRequestVm.checkIn = DateTime.Now.AddDays(1);
            hotelSearchRequestVm.checkOut = DateTime.Now.AddDays(5);
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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}