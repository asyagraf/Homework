using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreateBookCommand : ICreateBookCommand
    {
        private readonly IBookRepository _repository;

        public CreateBookCommand(IBookRepository repository)
        {
            _repository = repository;
        }

        public void Execute(BookDTO book)
        {
            _repository.Create(book);
        }
    }
}
