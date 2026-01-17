namespace DatabaseMotion.Models
{
    public class Hotel
    {
        public int HotelNo { get; set; }
        public string HotelName { get; set; } = null!; // must have a name

        public List<Room> Rooms { get; set; } = new();// 1:M relation
            

    }
}
