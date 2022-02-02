using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Persistence.Data
{
    public  class CargoRequestDbContextSeed
    {
        public static async Task SeedAsync(CargoRequestManagerDbContext cargoRequestManagerDbContext)
        {
            int retryforAvailability = 0;
            while (retryforAvailability < 3)
            {
                Thread.Sleep(10000);
                try
                {
                    await cargoRequestManagerDbContext.Database.MigrateAsync();
                    Console.WriteLine($"Sucessfully database migration");
                    retryforAvailability = 4;
                }
                catch (Exception ex)
                {
                    retryforAvailability++;
                    Console.WriteLine($"error on migration:{ex.Message}");
                }
            }

        }
    }
}
