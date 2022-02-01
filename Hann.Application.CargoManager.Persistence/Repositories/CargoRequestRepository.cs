using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Repositories
{
    public class CargoRequestRepository : GenericRepository<CargoRequest>, ICargoRequestRepository
    {
        private readonly CargoRequestManagerDbContext _cargoRequestManagerDbContext;

        public CargoRequestRepository(CargoRequestManagerDbContext cargoRequestManagerDbContext) : base(cargoRequestManagerDbContext)
        {
            _cargoRequestManagerDbContext = cargoRequestManagerDbContext;
        }

        public async Task ChangeApprovalStatus(CargoRequest cargoRequest, string status)
        {
            cargoRequest.Status = status;
            _cargoRequestManagerDbContext.Entry(cargoRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //await _cargoRequestManagerDbContext.SaveChangesAsync();
        }

        public async Task<CargoRequest> GetCargoRequestDetails(int id)
        {
            var response = await _cargoRequestManagerDbContext.CargoRequests
                .Where(q => q.Id == id)
                .Include(q=>q.DeliveryTerminal)
                .Include(q => q.DropOffTerminal)
                .FirstOrDefaultAsync();
            return response;
        }
    }
}
