using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        public CreatePersonCommand(IRepository<Person, int> repository)
        {
            _repository = repository;
        }

        public void Execute(Person person)
        {
            _repository.Create(person);
        }
    }
}
