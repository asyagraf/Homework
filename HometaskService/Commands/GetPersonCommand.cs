using HometaskService.Commands.Interfaces;
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

        public string Execute(int id)
        {
            return _repository.GetById(id);
        }
    }
}
