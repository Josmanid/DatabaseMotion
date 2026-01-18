using DatabaseMotion.Models;

namespace DatabaseMotion.Services.IServices
{
    public interface IHotelService
    {
        public IEnumerable<Hotel> GetHotels();

    }
}
