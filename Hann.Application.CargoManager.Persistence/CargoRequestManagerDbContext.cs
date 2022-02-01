using Hann.Application.CargoManager.Domain;
using Hann.Application.CargoManager.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence
{
    public class CargoRequestManagerDbContext : DbContext
    {
        public CargoRequestManagerDbContext(DbContextOptions<CargoRequestManagerDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CargoRequestManagerDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseDomainEntity>())
            {
                item.Entity.LastModifiedDate = DateTime.Now;

                if(item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<CargoRequest> CargoRequests { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleAllocation> VehicleAllocations { get; set; }
    }
}
