using Garages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garages.Repositories
{
   public interface IGarageRepo
    {
        Task AddGarageAsync(Garage garage);
        Task<List<Garage>> GetAllGaragesAsync();

    }
}
