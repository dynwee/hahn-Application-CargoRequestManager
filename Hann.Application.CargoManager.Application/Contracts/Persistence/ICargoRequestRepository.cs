using Hann.Application.CargoManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Contracts.Persistence
{
    public interface ICargoRequestRepository : IGenericRepository<CargoRequest>
    {
        Task ChangeApprovalStatus(CargoRequest cargoRequest, string status);

        Task<CargoRequest> GetCargoRequestDetails(int id);
    }
}
