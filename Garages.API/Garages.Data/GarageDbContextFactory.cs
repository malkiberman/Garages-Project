using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Garages.Data
{
    public class GarageDbContextFactory : IDesignTimeDbContextFactory<GarageDbContext>
    {
        public GarageDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GarageDbContext>();

            optionsBuilder.UseNpgsql("User Id=postgres.rncjxqpqzhtsbqafeaww;Password=1234;Server=aws-1-ap-southeast-2.pooler.supabase.com;Port=5432;Database=postgres;SSL Mode=Require;Trust Server Certificate=true");

            return new GarageDbContext(optionsBuilder.Options); 
        }
    }
}
