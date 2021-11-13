using HometaskService.Database;
using HometaskService.DBModels;
using System.Collections.Generic;
using System.Linq;

namespace HometaskService.Repositories
{
    public class RentalCarRepository
    {
        private readonly HometaskServiceDbContext dbContext;
        public RentalCarRepository()
        {
            dbContext = new HometaskServiceDbContext();
        }
        public DbRentalCar GetById(int id)
        {
            return dbContext.RentalCars.Find(id);
        }

        public List<DbRentalCar> GetAll()
        {
            return dbContext.RentalCars.ToList();
        }

        public void Create(DbRentalCar car)
        {
            dbContext.RentalCars.Add(car);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.RentalCars.Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public void Update(DbRentalCar car)
        {
            var newCar = dbContext.RentalCars.Find(car.Id);
            newCar.Number = car.Number;
            newCar.IsAvailable = car.IsAvailable;
            newCar.Brand = car.Brand;
            newCar.Model = car.Model;
            newCar.Mileage = car.Mileage;
            newCar.ClientId = car.ClientId;
            dbContext.SaveChanges();
        }
    }
}
