using FluentValidation;
using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class UpdatePersonCommand : IUpdatePersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly IValidator<Person> _validator;
        public UpdatePersonCommand(IRepository<Person, int> repository, IValidator<Person> validator)
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
