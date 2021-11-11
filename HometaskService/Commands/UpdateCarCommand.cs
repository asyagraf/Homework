using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdateCarCommand : IUpdateCarCommand
    {
        private readonly IRepository<Car, string> _repository;
        public UpdateCarCommand(IRepository<Car, string> repository)
        {
            _repository = repository;
        }

        public void Execute(Car car)
        {
            _repository.Update(car);
        }
    }
}
