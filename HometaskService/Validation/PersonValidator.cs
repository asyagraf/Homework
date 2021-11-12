using FluentValidation;
using HometaskService.Models;

namespace HometaskService.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
            RuleFor(x => x.Age)
                .GreaterThan(15)
                .LessThan(80)
                .WithMessage("Wrong age");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Wrong name");
            RuleFor(x => x.Surname)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Wrong name");
        }
    }
}
