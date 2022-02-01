using Hann.Application.CargoManager.Application.Contracts.Persistence;
using Hann.Application.CargoManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration  configuration,string conn)
        {
            services.AddDbContext<CargoRequestManagerDbContext>(options =>
            options.UseSqlServer(conn));

            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<IVehicleAllocationRespository, VehicleAllocationRepository>();
            services.AddScoped<ICargoRequestRepository, CargoRequestRepository>();

            return services;
        }
    }
}
