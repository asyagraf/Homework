using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreateCarCommand : ICreateCarCommand
    {
        private readonly ICarRepository _repository;
        public CreateCarCommand(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Car car)
        {
            _repository.Create(car);
        }
    }
}
