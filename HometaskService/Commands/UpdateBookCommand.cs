using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdateBookCommand : IUpdateBookCommand
    {
        private readonly IBookRepository _repository;

        public UpdateBookCommand(IBookRepository repository)
        {
            _repository = repository;
        }

        public void Execute(DBBook book)
        {
            _repository.Update(book);
        }
    }
}
