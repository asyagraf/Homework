using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class CreateRentalCarValidator : AbstractValidator<CreateRentalCarRequest>, IValidator<CreateRentalCarRequest>
    {
        public CreateRentalCarValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
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
            RuleFor(x => x.Mileage)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Mileage");
            RuleFor(x => x.ClientId)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong ClientId");
        }
    }
}
