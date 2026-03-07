using DatabaseMotion.Models;

namespace DatabaseMotion.DBContext.Repository
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();

    }
}
