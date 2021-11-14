using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class UpdateClientValidator : AbstractValidator<UpdateClientRequest>, IValidator<UpdateClientRequest>
    {
        public UpdateClientValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
            RuleFor(x => x.Experience)
                .GreaterThan(0)
                .LessThan(100)
                .WithMessage("Wrong experience");
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .Matches("^[A-Z a-z]*$")
                .WithMessage("Wrong FirstName");
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .Matches("^[A-Z a-z]*$")
                .WithMessage("Wrong LastName");
            RuleFor(x => x.MiddleName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .Matches("^[A-Z a-z]*$")
                .WithMessage("Wrong MiddleName");
        }
    }
}
