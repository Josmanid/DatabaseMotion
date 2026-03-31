using DatabaseMotion.DBContext;
using DatabaseMotion.DBContext.Repository;
using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMotion.Services.EFServices
{
    /// <summary>
    /// Provides hotel-related operations using a hotel repository.
    /// </summary>
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;

        public HotelService(IHotelRepository repository) {
            _repository = repository;
        }

        public IEnumerable<Hotel> GetHotels() {
            if (_repository != null)
            {
                return _repository.GetAll();
            }
            return Enumerable.Empty<Hotel>();
            
        }

     
    }
}
