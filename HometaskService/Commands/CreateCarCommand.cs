﻿using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using FluentValidation;
using HometaskService.Validation;

namespace HometaskService.Commands
{
    public class CreateCarCommand : ICreateCarCommand
    {
        private readonly IRepository<Car, string> _repository;
        private readonly CarValidator _validator;

        public CreateCarCommand(IRepository<Car, string> repository, CarValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Car car)
        {
            try
            {
                _validator.ValidateAndThrow(car);
                _repository.Create(car);
            }
            catch
            {

            }
        }
    }
}
