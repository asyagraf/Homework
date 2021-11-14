using CarRentalService.Request;
using FluentValidation;
using HometaskService.Commands;
using HometaskService.Commands.Interfaces;
using HometaskService.Comsumer;
using HometaskService.DBModels;
using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
using HometaskService.Validation;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace HometaskService
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
                    factory.ReceiveEndpoint("get_rentalcar", configuration =>
                    configuration.ConfigureConsumer<RentalCarConsumer>(context));
                    factory.ReceiveEndpoint("get_all_rentalcars", configuration =>
                    configuration.ConfigureConsumer<AllRentalCarsConsumer>(context));
                    factory.ReceiveEndpoint("delete_rentalcar", configuration =>
                    configuration.ConfigureConsumer<DeleteRentalCarConsumer>(context));
                    factory.ReceiveEndpoint("create_rentalcar", configuration =>
                    configuration.ConfigureConsumer<CreateRentalCarConsumer>(context));
                    factory.ReceiveEndpoint("update_rentalcar", configuration =>
                    configuration.ConfigureConsumer<UpdateRentalCarConsumer>(context));

                    factory.ReceiveEndpoint("get_client", configuration =>
                    configuration.ConfigureConsumer<ClientConsumer>(context));
                    factory.ReceiveEndpoint("get_all_clients", configuration =>
                    configuration.ConfigureConsumer<AllClientsConsumer>(context));
                    factory.ReceiveEndpoint("delete_client", configuration =>
                    configuration.ConfigureConsumer<DeleteClientConsumer>(context));
                    factory.ReceiveEndpoint("create_client", configuration =>
                    configuration.ConfigureConsumer<CreateClientConsumer>(context));
                    factory.ReceiveEndpoint("update_client", configuration =>
                    configuration.ConfigureConsumer<UpdateClientConsumer>(context));
                });
                cfg.AddConsumer<RentalCarConsumer>();
                cfg.AddConsumer<AllRentalCarsConsumer>();
                cfg.AddConsumer<DeleteRentalCarConsumer>();
                cfg.AddConsumer<CreateRentalCarConsumer>();
                cfg.AddConsumer<UpdateRentalCarConsumer>();

                cfg.AddConsumer<ClientConsumer>();
                cfg.AddConsumer<AllClientsConsumer>();
                cfg.AddConsumer<DeleteClientConsumer>();
                cfg.AddConsumer<CreateClientConsumer>();
                cfg.AddConsumer<UpdateClientConsumer>();
            });
            services.AddMassTransitHostedService();

            services.AddMemoryCache();

            services.AddSingleton<List<string>>();

            services.AddTransient<IValidator<Person>, PersonValidator>();
            services.AddTransient<IValidator<DBBook>, DBBookValidator>();
            services.AddTransient<IValidator<BookDTO>, BookValidator>();
            services.AddTransient<IValidator<Car>, CarValidator>();
            services.AddTransient<IValidator<RentalCarRequest>, RentalCarValidator>();
            services.AddTransient<IValidator<CreateRentalCarRequest>, CreateRentalCarValidator>();
            services.AddTransient<IValidator<DeleteRentalCarRequest>, DeleteRentalCarValidator>();
            services.AddTransient<IValidator<UpdateRentalCarRequest>, UpdateRentalCarValidator>();
            services.AddTransient<IValidator<ClientRequest>, ClientValidator>();
            services.AddTransient<IValidator<CreateClientRequest>, CreateClientValidator>();
            services.AddTransient<IValidator<DeleteClientRequest>, DeleteClientValidator>();
            services.AddTransient<IValidator<UpdateClientRequest>, UpdateClientValidator>();

            services.AddTransient<IRentalRepository<DbRentalCar>, RentalCarRepository>();
            services.AddTransient<IRentalRepository<DbClient>, ClientRepository>();
            services.AddTransient<IMapper<DbRentalCar, RentalCarResponse>, RentalCarMapper>();
            services.AddTransient<IMapper<DbClient, ClientResponse>, ClientMapper>();
            services.AddTransient<IMapper<UpdateRentalCarRequest, DbRentalCar>, UpdateRentalCarMapper>();
            services.AddTransient<IMapper<CreateRentalCarRequest, DbRentalCar>, CreateRentalCarMapper>();
            services.AddTransient<IMapper<UpdateClientRequest, DbClient>, UpdateClientMapper>();
            services.AddTransient<IMapper<CreateClientRequest, DbClient>, CreateClientMapper>();

            services.AddTransient<IRepository<Person, int>, PersonRepository>();
            services.AddTransient<IGetPersonCommand, GetPersonCommand>();
            services.AddTransient<IDeletePersonCommand, DeletePersonCommand>();
            services.AddTransient<IGetAllPersonsCommand, GetAllPersonsCommand>();
            services.AddTransient<ICreatePersonCommand, CreatePersonCommand>();
            services.AddTransient<IUpdatePersonCommand, UpdatePersonCommand>();

            services.AddTransient<IRepository<Car, string>, CarRepository>();
            services.AddTransient<IGetCarCommand, GetCarCommand>();
            services.AddTransient<IDeleteCarCommand, DeleteCarCommand>();
            services.AddTransient<IGetAllCarsCommand, GetAllCarsCommand>();
            services.AddTransient<ICreateCarCommand, CreateCarCommand>();
            services.AddTransient<IUpdateCarCommand, UpdateCarCommand>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGetBookCommand, GetBookCommand>();
            services.AddTransient<IDeleteBookCommand, DeleteBookCommand>();
            services.AddTransient<IGetAllBooksCommand, GetAllBooksCommand>();
            services.AddTransient<ICreateBookCommand, CreateBookCommand>();
            services.AddTransient<IUpdateBookCommand, UpdateBookCommand>();

            services.AddTransient<IMapper<Person, PersonDTO>, PersonMapper>();
            services.AddTransient<IMapper<Car, CarDTO>, CarMapper>();
            services.AddTransient<IMapper<DBBook, BookDTO>, BookMapper>();

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
