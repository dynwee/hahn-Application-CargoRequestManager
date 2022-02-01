using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITerminalRepository TerminalRepository { get; }
        IVehicleAllocationRespository VehicleAllocationRespository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }

        ICargoRequestRepository CargoRequestRepository { get; }
        Task Save();
    }
}
