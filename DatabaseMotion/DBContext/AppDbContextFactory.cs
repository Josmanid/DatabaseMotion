using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace DatabaseMotion.DBContext
{
    /// <summary>
    /// Formålet med IDesignTimeDbContextFactory:
    ///Når du kører Add-Migration eller Update-Database i PMC(Package Manager Console), skal EF Core instantiere DbContext for at forstå modellerne.
    ///Men: EF Core kender ikke dependency injection fra Program.cs.
    ///Derfor laves en factory, som fortæller EF Core præcis, hvordan den skal lave en DbContext design-time.
    ///Kort sagt: Factory = opskrift på “hvordan man laver en DbContext uden runtime DI”
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args) {
            // 1. Læs konfiguration fra appsettings.json
            var configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").
                Build();
            // 2. Byg DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            // 3. Returner en ny AppDBContext med options
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
