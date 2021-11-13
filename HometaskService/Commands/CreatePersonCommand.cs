using FluentValidation;
using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly IValidator<Person> _validator;
        public CreatePersonCommand(IRepository<Person, int> repository, IValidator<Person> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Person person)
        {
            try
            {
                _validator.ValidateAndThrow(person);
                _repository.Create(person);
            }
            catch
            {

            }
        }
    }
}
