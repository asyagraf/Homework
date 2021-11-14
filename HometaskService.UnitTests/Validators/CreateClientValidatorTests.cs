using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class CreateClientValidatorTests
    {
        private CreateClientValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new CreateClientValidator();
        }

        [Test]
        public void ValidClientRequest_Test()
        {
            CreateClientRequest client = new CreateClientRequest()
            {
                FirstName = "Ann",
                LastName = "Green",
                MiddleName = "Anny",
                Experience = 7
            };

            TestValidationResult<CreateClientRequest> result = validator.TestValidate(client);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidCreateClientRequest_Test()
        {
            CreateClientRequest client = new CreateClientRequest()
            {
                FirstName = "",
                LastName = "123",
                MiddleName = "",
                Experience = -2
            };

            TestValidationResult<CreateClientRequest> result = validator.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.MiddleName);
            result.ShouldHaveValidationErrorFor(x => x.Experience);
        }
    }
}
