using FluentValidation;
using HometaskService.Commands.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using HometaskService.Validation;

namespace HometaskService.Commands
{
    public class CreateBookCommand : ICreateBookCommand
    {
        private readonly IBookRepository _repository;
        private readonly BookValidator _validator;

        public CreateBookCommand(IBookRepository repository, BookValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(BookDTO book)
        {
            try
            {
                _validator.ValidateAndThrow(book);
                _repository.Create(book);
            }
            catch
            {

            }
        }
    }
}
