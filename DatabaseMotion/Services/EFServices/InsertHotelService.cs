using DatabaseMotion.DBContext.Repository;
using DatabaseMotion.Models;
using DatabaseMotion.Services.IServices;

namespace DatabaseMotion.Services.EFServices
{
    public class InsertHotelService : IInsertHotelService
    {
        private readonly IHotelRepository _repository;

        public InsertHotelService(IHotelRepository repository) {
            _repository = repository;
        }
        public Hotel NewHotel(Hotel hotel) {
            return _repository.NewHotel(hotel);
            
        }
    }
}
