using HometaskService.Commands;
using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
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
            services.AddMemoryCache();

            services.AddSingleton<List<string>>();

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