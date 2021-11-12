using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using FluentValidation;
using HometaskService.Validation;

namespace HometaskService.Commands
{
    public class CreatePersonCommand : ICreatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly PersonValidator _validator;
        public CreatePersonCommand(IRepository<Person, int> repository, PersonValidator validator)
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
