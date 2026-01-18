using DatabaseMotion.DBContext;
using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;

namespace DatabaseMotion.Services.EFServices
{
    public class HotelService : IHotelService
    {
        private readonly AppDBContext _context;

        public HotelService(AppDBContext service) {
            _context = service;
        }

        public IEnumerable<Hotel> GetHotels() {
            return _context.Hotels;
        }
    }
}
