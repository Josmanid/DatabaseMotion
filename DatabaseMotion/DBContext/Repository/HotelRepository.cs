using DatabaseMotion.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMotion.DBContext.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDBContext _context;

        public HotelRepository(AppDBContext service) {
            _context = service; 
        }

        public IEnumerable<Hotel> GetAll() {
            List<Hotel> hotelsList = _context.Hotels.AsNoTracking().ToList();
            return hotelsList;
        }
    }
}
