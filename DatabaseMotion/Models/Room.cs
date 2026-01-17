namespace DatabaseMotion.Models
{
    public class Room
    {
        public int RoomNo { get; set; }
        public int HotelNo { get; set; }
        public string RoomType { get; set; } = null!; // must have a room type and better name
        public decimal RoomPrice { get; set; } // and better name

        public Hotel? Hotel { get; set; } // navigation prop
    }
}
