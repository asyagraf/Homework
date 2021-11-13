using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class RentalCarValidator : AbstractValidator<RentalCarRequest>, IValidator<RentalCarRequest>
    {
        public RentalCarValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
        }
    }
}
