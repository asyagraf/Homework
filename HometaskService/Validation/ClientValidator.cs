using FluentValidation;
using HometaskService.DBModels;

namespace HometaskService.Validation
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Wrong first name");
            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Wrong last name");
            RuleFor(x => x.MiddleName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Wrong middle name");
            RuleFor(x => x.Experience)
                .GreaterThan(1)
                .LessThan(80)
                .WithMessage("Wrong experience");
        }
    }
}
