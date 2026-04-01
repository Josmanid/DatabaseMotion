using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseMotion.Pages.Hotels
{
    public class GetHotelsModel : PageModel
    {

        public IEnumerable<Hotel> Hotels { get; set; }
        public Hotel? FoundHotel { get; set; }
        private IHotelService _hotelService;

        public GetHotelsModel(IHotelService service) {
            _hotelService = service;

        }
        //Razorpage må også binde når formularen binder på get
        [BindProperty(SupportsGet = true)]
        public int? InputId { get; set; }


        public void OnGet() {
            if (_hotelService != null)
            {
                Hotels = _hotelService.GetHotels();

                if (InputId.HasValue)
                {
                    try
                    {
                        FoundHotel = _hotelService.GetHotelById(InputId.Value);
                    }
                    catch (KeyNotFoundException)
                    {
                        // Hotel ikke fundet — FundnetHotel forbliver null
                    }
                }
            }
        }
    }
      
}
