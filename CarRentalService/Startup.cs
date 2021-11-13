using CarRentalService.Request;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CarRentalService
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

            services.AddMassTransit(cfg =>
            {
                cfg.UsingRabbitMq((context, factory) =>
                {
                    factory.Host("localhost", "/", hostCfg =>
                    {
                        hostCfg.Username("guest");
                        hostCfg.Password("guest");
                    });
                });
                cfg.AddRequestClient<RentalCarRequest>(new Uri("rabbitmq://localhost/get_rentalcar"));
                cfg.AddRequestClient<AllRentalCarsRequest>(new Uri("rabbitmq://localhost/get_all_rentalcars"));
                cfg.AddRequestClient<CreateRentalCarRequest>(new Uri("rabbitmq://localhost/create_rentalcar"));
                cfg.AddRequestClient<DeleteRentalCarRequest>(new Uri("rabbitmq://localhost/delete_rentalcar"));
                cfg.AddRequestClient<UpdateRentalCarRequest>(new Uri("rabbitmq://localhost/update_rentalcar"));
            });
            services.AddMassTransitHostedService();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
