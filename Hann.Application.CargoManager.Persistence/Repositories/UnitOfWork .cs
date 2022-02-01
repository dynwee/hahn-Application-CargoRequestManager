using Hann.Application.CargoManager.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CargoRequestManagerDbContext _context;
        private ITerminalRepository _terminalRepository;
        private IVehicleAllocationRespository _vehicleAllocationRespository;
        private IVehicleTypeRepository _vehicleTypeRepository;
        private ICargoRequestRepository _cargoRequestRepository;


        public UnitOfWork(CargoRequestManagerDbContext context)
        {
            _context = context;      
        }

        public ITerminalRepository TerminalRepository =>
           _terminalRepository ??= new TerminalRepository(_context);
        public IVehicleAllocationRespository VehicleAllocationRespository =>
            _vehicleAllocationRespository ??= new VehicleAllocationRepository(_context);
        public IVehicleTypeRepository VehicleTypeRepository =>
            _vehicleTypeRepository ??= new VehicleTypeRepository(_context);

        public ICargoRequestRepository CargoRequestRepository =>
           _cargoRequestRepository ??= new CargoRequestRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
