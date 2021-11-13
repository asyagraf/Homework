using HometaskService.Commands.Interfaces;
using HometaskService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace HometaskService.Commands
{
    public class DeleteBookCommand : IDeleteBookCommand
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommand(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(int id)
        {
            await _repository.Delete(id);
        }
    }
}
