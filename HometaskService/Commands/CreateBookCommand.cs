using FluentValidation;
using HometaskService.Commands.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace HometaskService.Commands
{
    public class CreateBookCommand : ICreateBookCommand
    {
        private readonly IBookRepository _repository;
        private readonly IValidator<BookDTO> _validator;

        public CreateBookCommand(IBookRepository repository, IValidator<BookDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task ExecuteAsync(BookDTO book)
        {
            try
            {
                _validator.ValidateAndThrow(book);
                await _repository.Create(book);
            }
            catch
            {

            }
        }
    }
}
