using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class DeleteClientValidatorTests
    {
        private DeleteClientValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new DeleteClientValidator();
        }

        [Test]
        public void ValidDeleteClientRequest_Test()
        {
            DeleteClientRequest client = new DeleteClientRequest()
            {
                Id = 4
            };

            TestValidationResult<DeleteClientRequest> result = validator.TestValidate(client);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidDeleteClientRequest_Test()
        {
            DeleteClientRequest client = new DeleteClientRequest()
            {
                Id = 0
            };

            TestValidationResult<DeleteClientRequest> result = validator.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
