using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using HometaskService.Validation;
using FluentValidation;

namespace HometaskService.Commands
{
    public class UpdateBookCommand : IUpdateBookCommand
    {
        private readonly IBookRepository _repository;
        private readonly DBBookValidator _validator;

        public UpdateBookCommand(IBookRepository repository, DBBookValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(DBBook book)
        {
            try
            {
                _validator.ValidateAndThrow(book);
                _repository.Update(book);
            }
            catch
            {

            }
        }
    }
}
