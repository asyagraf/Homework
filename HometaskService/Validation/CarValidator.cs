using FluentValidation;
using HometaskService.Models;

namespace HometaskService.Validation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Owner)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Wrong owner's name");
            RuleFor(x => x.Brand)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Wrong brand");
            RuleFor(x => x.Model)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Wrong model");
            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .Length(6)
                .Matches("^[A-Z 0-9]*$")
                .WithMessage("Wrong number");
        }
    }
}
