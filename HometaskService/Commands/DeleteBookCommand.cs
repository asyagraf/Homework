using HometaskService.Commands.Interfaces;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommand(IBookRepository repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}
