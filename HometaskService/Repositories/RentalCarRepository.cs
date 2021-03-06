using HometaskService.Database;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HometaskService.Repositories
{
    public class RentalCarRepository : IRentalRepository<DbRentalCar>
    {
        private readonly HometaskServiceDbContext dbContext;
        public RentalCarRepository()
        {
            dbContext = new HometaskServiceDbContext();
        }
        public async Task<DbRentalCar> GetById(int id)
        {
            return await dbContext.RentalCars.FindAsync(id);
        }

        public async Task<List<DbRentalCar>> GetAll()
        {
            return await dbContext.RentalCars.ToListAsync();
        }

        public async Task Create(DbRentalCar car)
        {
            if (car.ClientId is null || await dbContext.Clients.FindAsync(car.ClientId) is not null)
            {
                await dbContext.RentalCars.AddAsync(car);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var car = await dbContext.RentalCars.FindAsync(id);
            if (car is not null)
            {
                dbContext.RentalCars.Remove(car);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(DbRentalCar car)
        {
            var newCar = await dbContext.RentalCars.FindAsync(car.Id);
            if (newCar is not null)
            {
                newCar.Number = car.Number;
                newCar.IsAvailable = car.IsAvailable;
                newCar.Brand = car.Brand;
                newCar.Model = car.Model;
                newCar.Mileage = car.Mileage;
                newCar.ClientId = car.ClientId;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
