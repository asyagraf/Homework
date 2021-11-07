using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IPersonRepository _repository;
        public CreatePersonCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Person person)
        {
            _repository.Create(person);
        }
    }
}
