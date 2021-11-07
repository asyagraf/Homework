using HometaskService.Commands.Interfaces;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class DeletePersonCommand : IDeletePersonCommand
    {
        private readonly IPersonRepository _repository;
        public DeletePersonCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
