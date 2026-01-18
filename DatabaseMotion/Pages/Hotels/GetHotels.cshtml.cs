using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseMotion.Pages.Hotels
{
    public class GetHotelsModel : PageModel
    {

        public IEnumerable<Hotel> Hotels { get; set; }

        IHotelService _hotelService;

        public GetHotelsModel(IHotelService service) {
            _hotelService = service;
            
        }



        public void OnGet()
        {
            if (_hotelService != null)
            {
              Hotels =  _hotelService.GetHotels();
            }
        }
    }
}
