using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace HometaskService.Repositories
{
    public class CarRepository : IRepository<Car, string>
    {
        private IMemoryCache _cache;
        private List<string> _keys;

        public CarRepository(IMemoryCache cache, List<string> keys)
        {
            _cache = cache;
            _keys = keys;
        }

        public void Create(Car car)
        {
            if (_cache.Get(car.Number) is null)
            {
                _cache.Set(car.Number, car);
                _keys.Add(car.Number);
            }
        }

        public void Delete(string number)
        {
            if (_cache.Get(number) is not null)
            {
                _cache.Remove(number);
                _keys.Remove(number);
            }
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();
            foreach (string key in _keys)
            {
                try
                {
                    cars.Add((Car)_cache.Get(key));
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return cars;
        }

        public Car Get(string number)
        {
            if (_cache.Get(number) is not null)
            {
                try
                {
                    Car car = (Car)_cache.Get(number);
                    return (Car)_cache.Get(number);
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return null;
        }

        public void Update(Car car)
        {
            if (_cache.Get(car.Number) is not null)
            {
                _cache.Set(car.Number, car);
            }
        }
    }
}
