using FluentValidation;
using HometaskService.ModelsDTO;

namespace HometaskService.Validation
{
    public class BookValidator : AbstractValidator<BookDTO>, IValidator<BookDTO>
    {
        public BookValidator()
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
        }

    }
}
