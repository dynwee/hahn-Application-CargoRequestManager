using Hann.Application.CargoManager.Persistence;
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
                int retryforAvailability = 0;
                while (retryforAvailability < 3)
                {
                    Thread.Sleep(5000);
                    try
                    {
                        var db = scope.ServiceProvider.GetRequiredService<CargoRequestManagerDbContext>();
                        await db.Database.MigrateAsync();
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
