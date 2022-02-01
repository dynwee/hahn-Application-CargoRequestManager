using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Repositories
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        private readonly CargoRequestManagerDbContext _cargoRequestManagerDbContext;

        public VehicleTypeRepository(CargoRequestManagerDbContext cargoRequestManagerDbContext) : base(cargoRequestManagerDbContext)
        {
            _cargoRequestManagerDbContext = cargoRequestManagerDbContext;
        }
    }
}
