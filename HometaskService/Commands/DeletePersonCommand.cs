using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class DeletePersonCommand : IDeletePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        public DeletePersonCommand(IRepository<Person, int> repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
