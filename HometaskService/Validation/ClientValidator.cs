using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class ClientValidator : AbstractValidator<ClientRequest>, IValidator<ClientRequest>
    {
        public ClientValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
        }
    }
}
