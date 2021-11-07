using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetPersonCommand : IGetPersonCommand
    {
        private readonly IPersonRepository _repository;
        public GetPersonCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Execute(int id)
        {
            return _repository.GetById(id);
        }
    }
}
