using ZarenTravelProject.Models;

namespace ZarenTravelProject.Services
{
    public class TravelService
    {
        private readonly HttpClient _httpClient;

        public TravelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ListedItemsResponseOperationResult?> GetHotelLocations(LocationSearchRequestVM locationSearchRequestVm)
        {
            var response = await _httpClient.PostAsJsonAsync("hotel/location", locationSearchRequestVm);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<ListedItemsResponseOperationResult>();
            return responseBody;
        }
        public async Task<HotelSearchResponseVMOperationResult> GetHotelLocations(HotelSearchRequestVM hotelSearchRequestVm)
        {
            var response = await _httpClient.PostAsJsonAsync("hotel/search", hotelSearchRequestVm);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseBody = await response.Content.ReadFromJsonAsync<HotelSearchResponseVMOperationResult>();
            return responseBody;
        }



    }
}
