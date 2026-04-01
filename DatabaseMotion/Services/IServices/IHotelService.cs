using DatabaseMotion.Models;

namespace DatabaseMotion.Services.IServices
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetHotels();

        Hotel? GetHotelById(int id);


    }
}
