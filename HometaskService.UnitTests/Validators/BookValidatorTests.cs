using FluentValidation.TestHelper;
using HometaskService.ModelsDTO;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class BookValidatorTests
    {
        private BookValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new BookValidator();
        }

        [Test]
        public void ValidBookDTO_Test()
        {
            BookDTO book = new BookDTO()
            {
                Name = "Name",
                Author = "Author"
            };

            TestValidationResult<BookDTO> result = validator.TestValidate(book);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidBookDTO_Test()
        {
            BookDTO book = new BookDTO()
            {
                Name = "",
                Author = ""
            };

            TestValidationResult<BookDTO> result = validator.TestValidate(book);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Author);
        }
    }
}
