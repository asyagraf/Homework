using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace HometaskService.Repositories
{
    public class CarRepository : ICarRepository
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

        public List<string> GetAll()
        {
            List<string> cars = new List<string>();
            foreach (string key in _keys)
            {
                try
                {
                    Car car = (Car)_cache.Get(key);
                    cars.Add($"Brand: {car.Brand}   Model: {car.Model}   Number: {car.Number}");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return cars;
        }

        public string GetByNumber(string number)
        {
            if (_cache.Get(number) is not null)
            {
                try
                {
                    Car car = (Car)_cache.Get(number);
                    return $"Brand: {car.Brand}\nModel: {car.Model}\nNumber: {number}";
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return "This car doesn't exist";
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
