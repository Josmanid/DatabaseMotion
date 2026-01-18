using DatabaseMotion.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMotion.DBContext
{
    public class AppDBContext : DbContext // vi arver fra DbContext klassen som kan agere mellemled til vores db
    {
        /// <summary>
        /// denne konstruktør giver også en instans vi kan benytte, f.eks. gør base(options) at vi kan bruge 
        /// DbContext smarte metoder
        /// </summary>
        /// <param name="options"></param>
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }

        // Virtuel gør at vi kan override hvilket er godt fordi..
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();
    }
}
