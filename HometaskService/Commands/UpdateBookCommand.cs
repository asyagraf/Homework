using FluentValidation;
using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace HometaskService.Commands
{
    public class UpdateBookCommand : IUpdateBookCommand
    {
        private readonly IBookRepository _repository;
        private readonly IValidator<DBBook> _validator;

        public UpdateBookCommand(IBookRepository repository, IValidator<DBBook> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task ExecuteAsync(DBBook book)
        {
            try
            {
                _validator.ValidateAndThrow(book);
                await _repository.Update(book);
            }
            catch
            {

            }
        }
    }
}
