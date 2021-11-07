using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly IPersonRepository _repository;
        public UpdatePersonCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Person person)
        {
            _repository.Update(person);
        }
    }
}
