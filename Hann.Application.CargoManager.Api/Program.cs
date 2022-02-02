using Hann.Application.CargoManager.Persistence;
using Hann.Application.CargoManager.Persistence.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<CargoRequestManagerDbContext>();

                    await CargoRequestDbContextSeed.SeedAsync(dbContext);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"error on migration from program.cs :{ex.Message}");
                }
               
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
