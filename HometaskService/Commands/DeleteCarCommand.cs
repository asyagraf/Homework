using HometaskService.Commands.Interfaces;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class DeleteCarCommand : IDeleteCarCommand
    {
        private readonly ICarRepository _repository;
        public DeleteCarCommand(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Execute(string number)
        {
            _repository.Delete(number);
        }
    }
}
