using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garages.Data
{
    public class GarageDbContextFactory : IDesignTimeDbContextFactory<GarageDbContext>
    {
        public GarageDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GarageDbContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Database=Garages;Username=postgres;");

            return new GarageDbContext(optionsBuilder.Options); // Fix for CS1729 and CS1061
        }
    }
}
