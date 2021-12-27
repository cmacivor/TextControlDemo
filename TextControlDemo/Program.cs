using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TextControlDemo.Extensions;

namespace TextControlDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();

            //var serviceProvider = CreateServices();

            //using (var scope = serviceProvider.CreateScope())
            //{
            //    UpdateDatabase(serviceProvider);
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //private static IServiceProvider CreateServices()
        //{
        //    //var assembly = Assembly.GetExecutingAssembly();
        //    //var connString = Configuration

        //    return new ServiceCollection()
        //        // Add common FluentMigrator services
        //        .AddFluentMigratorCore()
        //        .ConfigureRunner(rb => rb
        //            // Add SQLite support to FluentMigrator
        //            .AddPostgres() //.AddSQLite()
        //                           // Set the connection strings
        //                           //.WithGlobalConnectionString("Data Source=test.db")
        //            .WithGlobalConnectionString("User ID=postgres;Password=Emmett2810$;Host=localhost;Port=5432;Database=TextControlDemo2;")
        //            // Define the assembly containing the migrations
        //            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
        //        // Enable logging to console in the FluentMigrator way
        //        .AddLogging(lb => lb.AddFluentMigratorConsole())
        //        // Build the service provider
        //        .BuildServiceProvider(true);
        //}

        //private static void UpdateDatabase(IServiceProvider serviceProvider)
        //{
        //    // Instantiate the runner
        //    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

        //    // Execute the migrations
        //    runner.MigrateUp();
        //}
    }
}
