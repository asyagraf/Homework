using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using FluentValidation;
using HometaskService.Validation;

namespace HometaskService.Commands
{
    public class UpdateCarCommand : IUpdateCarCommand
    {
        private readonly IRepository<Car, string> _repository;
        private readonly IValidator<Car> _validator;
        public UpdateCarCommand(IRepository<Car, string> repository, IValidator<Car> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Car car)
        {
            try
            {
                _validator.ValidateAndThrow(car);
                _repository.Update(car);
            }
            catch
            {

            }
        }
    }
}
