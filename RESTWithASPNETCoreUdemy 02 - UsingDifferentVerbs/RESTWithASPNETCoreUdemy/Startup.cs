using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RESTWithASPNETCoreUdemy.Models.Context;
using RESTWithASPNETCoreUdemy.Repository.Generic;
using RESTWithASPNETCoreUdemy.Services.Business;
namespace RESTWithASPNETCoreUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)//, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            //_logger = logger;
        }

        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostEnvironment _environment { get; }

        // This method gets called by the runtime.  Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));
            
            if (!_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    //_logger.LogCritical("Database migration failed ", ex);
                    throw;
                }
            }

            
            services.AddControllers();

            services.AddApiVersioning();
            //Dependency Injection
            services.AddScoped<IPersonBusiness,PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
