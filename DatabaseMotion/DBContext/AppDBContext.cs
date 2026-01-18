using DatabaseMotion.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMotion.DBContext
{
    public class AppDBContext : DbContext // vi arver fra DbContext klassen som kan agere mellemled til vores db
    {


        /// <summary>
        /// Konstruktøren modtager en DbContextOptions<T>, og sender den videre til basisklassen DbContext.
        /// så vi kan benytte DbContext smarte metoder
        /// </summary>
        /// <param name="options"></param>
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Primær nøgler
            modelBuilder.Entity<Hotel>().HasKey(h => h.HotelNo);
            modelBuilder.Entity<Room>().HasKey(r => r.RoomNo);

            //Fremmed nøgle: relation: 1 Hotel : mange rooms
            modelBuilder.Entity<Room>()
            .HasOne(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(r => r.HotelNo);



            //Seed data code-first
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { HotelNo = 1, Name = "Grand Hotel" },
                new Hotel { HotelNo = 2, Name = "Seaside inn" }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room { RoomNo = 1, HotelNo = 1, Type = "Single", Price = 500 },
                new Room { RoomNo = 2, HotelNo = 1, Type = "Double", Price = 700 },
                new Room { RoomNo = 3, HotelNo = 2, Type = "Suite", Price = 1200 }
                );

            base.OnModelCreating(modelBuilder);
        }
        // DbSet<T> er din dør ind til EF Core, som gør det muligt at læse og ændre data i databasen.
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();
    }
}
