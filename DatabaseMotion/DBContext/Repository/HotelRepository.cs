using DatabaseMotion.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMotion.DBContext.Repository
{
    /// <summary>
    /// Concrete implementation of IHotelRepository.
    /// Handles direct database communication via Entity Framework.
    /// The interface abstraction allows the service layer to be tested with Moq.
    /// </summary>
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

        public Hotel NewHotel(Hotel newHotel) {
            _context.Hotels.Add(newHotel);
            _context.SaveChanges();
            return newHotel;
        }
    }
}
