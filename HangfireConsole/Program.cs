using System;
using System.IO;
using Hangfire;
using HangfireConsole.Constants;
using HangfireConsole.Services.Implementations;
using HangfireShared.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HangfireConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            var configuration = builder.Build();

            GlobalConfiguration.Configuration.UseSqlServerStorage(
                configuration.GetConnectionString(SqlConnectionNameConstants.Hangfire));

            var collection = new ServiceCollection();
            collection.AddScoped<IUserService, UserService>();
            var serviceProvider = collection.BuildServiceProvider();

            var backgroundServerOptions = new BackgroundJobServerOptions();
            backgroundServerOptions.Activator = new HangfireJobActivator(serviceProvider);
            using (var server = new BackgroundJobServer(backgroundServerOptions))
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}