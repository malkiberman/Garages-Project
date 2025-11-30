using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garages.Data;

namespace Garages.Data
{
    public class GarageDbContext : DbContext 
    {

        public GarageDbContext(DbContextOptions<GarageDbContext> options)
            : base(options)
        {
        }

        public DbSet<Garage> Garages { get; set; }

        
    }
}
