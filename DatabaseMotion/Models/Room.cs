using System.ComponentModel.DataAnnotations;

namespace DatabaseMotion.Models
{
    public class Room
    {
        
        public int RoomNo { get; set; }
        public int HotelNo { get; set; } // Fremmednøgle
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }

        public Hotel? Hotel { get; set; } // navigation property to Hotel
    }
}
