using DatabaseMotion.Models;

namespace DatabaseMotion.DBContext.Repository
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();

        Hotel? GetHotelById(int id);

        Hotel NewHotel(Hotel newHotel);

        
    }
}
