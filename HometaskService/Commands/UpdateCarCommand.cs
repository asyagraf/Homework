using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdateCarCommand : IUpdateCarCommand
    {
        private readonly ICarRepository _repository;
        public UpdateCarCommand(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Car car)
        {
            _repository.Update(car);
        }
    }
}
