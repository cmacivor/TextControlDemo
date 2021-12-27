using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextControlDemo.Controllers;
using TextControlDemo.Migrations;
using TextControlDemo.Repositories;

namespace TextControlDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<DapperContext>();
            services.AddSingleton<Database>();

            services.AddTransient<ITxDocumentRepository, TxDocumentRepository>();


            //https://code-maze.com/dapper-migrations-fluentmigrator-aspnetcore/
            services.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddPostgres()
                .WithGlobalConnectionString(Configuration.GetConnectionString("NpgsqlConnection"))
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());


            //var serviceProvider = CreateServices();

            //using (var scope = serviceProvider.CreateScope())
            //{
            //    UpdateDatabase(serviceProvider);
            //}
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }

        private static IServiceProvider CreateServices()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //var connString = Configuration

            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddPostgres() //.AddSQLite()
                    // Set the connection string
                    //.WithGlobalConnectionString("Data Source=test.db")
                    .WithGlobalConnectionString("User ID=postgres;Password=Emmett2810$;Host=localhost;Port=5432;Database=TextControlDemo2;")
                    // Define the assembly containing the migrations
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            // serve static linked files (JavaScript and CSS for the editor)
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                   System.IO.Path.Combine(System.IO.Path.GetDirectoryName(
                       System.Reflection.Assembly.GetEntryAssembly().Location),
                       "TXTextControl.Web")),
                RequestPath = "/TXTextControl.Web"
            });

            // enable Web Sockets
            app.UseWebSockets();

            // attach the Text Control WebSocketHandler middleware
            app.UseMiddleware<TXTextControl.Web.WebSocketMiddleware>();
        }
    }
}
