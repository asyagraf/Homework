using FluentValidation;
using HometaskService.DBModels;

namespace HometaskService.Validation
{
    public class DBBookValidator : AbstractValidator<DBBook>
    {
        public DBBookValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Can't be null");
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Wrong name");
            RuleFor(x => x.Author)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Wrong author's name");
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue)
                .WithMessage("Wrong Id");
        }

    }
}
