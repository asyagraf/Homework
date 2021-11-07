using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class DeleteCarCommand : IDeleteCarCommand
    {
        private readonly IRepository<Car, string> _repository;
        public DeleteCarCommand(IRepository<Car, string> repository)
        {
            _repository = repository;
        }

        public void Execute(string number)
        {
            _repository.Delete(number);
        }
    }
}
