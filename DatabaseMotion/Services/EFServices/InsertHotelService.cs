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
        /// <summary>
        /// Creates a new hotel entry in the repository.
        /// </summary>
        /// <param name="hotel">The hotel entity to be added.</param>
        /// <returns>The newly created hotel entity.</returns>
        public Hotel NewHotel(Hotel hotel) {
            return _repository.NewHotel(hotel);
            
        }
    }
}
