using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        public UpdatePersonCommand(IRepository<Person, int> repository)
        {
            _repository = repository;
        }

        public void Execute(Person person)
        {
            _repository.Update(person);
        }
    }
}
