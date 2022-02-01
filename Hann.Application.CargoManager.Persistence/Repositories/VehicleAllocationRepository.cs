using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Repositories
{
    public class VehicleAllocationRepository : GenericRepository<VehicleAllocation>, IVehicleAllocationRespository
    {
        private readonly CargoRequestManagerDbContext cargoRequestManagerDbContext;

        public VehicleAllocationRepository(CargoRequestManagerDbContext cargoRequestManagerDbContext) : base(cargoRequestManagerDbContext)
        {
            this.cargoRequestManagerDbContext = cargoRequestManagerDbContext;
        }
    }
}
