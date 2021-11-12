using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using FluentValidation;
using HometaskService.Validation;

namespace HometaskService.Commands
{
    public class UpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly PersonValidator _validator;
        public UpdatePersonCommand(IRepository<Person, int> repository, PersonValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void Execute(Person person)
        {
            try
            {
                _validator.ValidateAndThrow(person);
                _repository.Update(person);
            }
            catch
            {

            }
        }
    }
}
