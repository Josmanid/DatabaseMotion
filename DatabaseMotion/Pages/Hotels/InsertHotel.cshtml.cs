using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseMotion.Pages.Hotels
{
    public class InsertHotelModel : PageModel
    {
        public IInsertHotelService _insertHotelService { get; set; }

        public InsertHotelModel(IInsertHotelService service) {
            _insertHotelService = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] 
        public Hotel Hotel { get; set; }
        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _insertHotelService.NewHotel(Hotel);

            return RedirectToPage("GetHotels");
        }

    }
}
