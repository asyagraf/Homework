using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetCarCommand : IGetCarCommand
    {
        private readonly ICarRepository _repository;
        public GetCarCommand(ICarRepository repository)
        {
            _repository = repository;
        }

        public Car Execute(string number)
        {
            return _repository.GetByNumber(number);
        }
    }
}
