using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreateCarCommand : ICreateCarCommand
    {
        private readonly IRepository<Car, string> _repository;

        public CreateCarCommand(IRepository<Car, string> repository)
        {
            _repository = repository;
        }

        public void Execute(Car car)
        {
            _repository.Create(car);
        }
    }
}
