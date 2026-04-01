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
        public Hotel? GetHotelById(int id) {
            Hotel? hotel = _repository.GetHotelById(id);

            if (hotel == null)
            {
                throw new KeyNotFoundException($"Hotel with the {id} dosen't exist");
            }
            return hotel;
        }



    }
}
