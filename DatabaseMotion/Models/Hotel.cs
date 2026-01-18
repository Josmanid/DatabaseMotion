using System.ComponentModel.DataAnnotations;

namespace DatabaseMotion.Models
{
    public class Hotel
    {
        
        public int HotelNo { get; set; }
        public string Name { get; set; } = null!; 

        public List<Room> Rooms { get; set; } = new();// 1:M relation, initialiseret for at undgå null reference


    }
}
