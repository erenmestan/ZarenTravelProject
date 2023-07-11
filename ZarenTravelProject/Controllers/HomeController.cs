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
        public IActionResult Index()
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
            var hotelSearchRequestVm = new HotelSearchRequestVM
            {
                LocationId = id,
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(5),
                Query="string",
                Currency = "EUR",
                Culture = "tr-TR",
                Nationality = "TR",
                Page = 1,
                PageSize = 100
            };
            var occupants = new OccupantsVM
            {
                Adults = 1
            };

            hotelSearchRequestVm.Occupants = new List<OccupantsVM> {occupants};
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