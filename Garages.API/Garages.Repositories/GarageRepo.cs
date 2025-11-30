using Garages.Data;
using Microsoft.EntityFrameworkCore;

namespace Garages.Repositories
{
    public class GarageRepo : IGarageRepo
    {
        private readonly GarageDbContext _context;

        public GarageRepo(GarageDbContext context)
        {
            _context = context;
        }

        public async Task AddGarageAsync(Garage garage) 
        {
            await _context.Garages.AddAsync(garage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Garage>> GetAllGaragesAsync() 
        {
            return await _context.Garages.ToListAsync();
        }
    }
}
