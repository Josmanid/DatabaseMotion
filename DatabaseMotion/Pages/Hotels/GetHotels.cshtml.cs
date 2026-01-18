using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseMotion.Pages.Hotels
{
    public class GetHotelsModel : PageModel
    {

        public IEnumerable<Hotel> Hotels { get; set; }

        IHotelService hotelService;

        public GetHotelsModel(IHotelService service) {
            hotelService = service;
            
        }



        public void OnGet()
        {
            if (hotelService != null)
            {
                hotelService.GetHotels();
            }
        }
    }
}
