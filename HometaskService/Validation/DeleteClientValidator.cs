using CarRentalService.Request;
using FluentValidation;

namespace HometaskService.Validation
{
    public class DeleteClientValidator : AbstractValidator<DeleteClientRequest>, IValidator<DeleteClientRequest>
    {
        public DeleteClientValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
        }
    }
}
