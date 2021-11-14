using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class DeleteRentalCarValidator : AbstractValidator<DeleteRentalCarRequest>, IValidator<DeleteRentalCarRequest>
    {
        public DeleteRentalCarValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
        }
    }
}
