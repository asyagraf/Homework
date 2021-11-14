using FluentValidation.TestHelper;
using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class DBBookValidatorTests
    {
        private DBBookValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new DBBookValidator();
        }

        [Test]
        public void ValidDBBook_Test()
        {
            DBBook book = new DBBook()
            {
                Id = 3,
                Name = "Name",
                Author = "Author"
            };

            TestValidationResult<DBBook> result = validator.TestValidate(book);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidDBBook_Test()
        {
            DBBook book = new DBBook()
            {
                Id = -1,
                Name = "",
                Author = ""
            };

            TestValidationResult<DBBook> result = validator.TestValidate(book);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Id);
            result.ShouldHaveValidationErrorFor(x => x.Author);
        }
    }
}
