using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class UpdateClientValidatorTests
    {
        private UpdateClientValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new UpdateClientValidator();
        }

        [Test]
        public void ValidClientRequest_Test()
        {
            UpdateClientRequest client = new UpdateClientRequest()
            {
                Id = 5,
                FirstName = "Ann",
                LastName = "Green",
                MiddleName = "Anny",
                Experience = 7
            };

            TestValidationResult<UpdateClientRequest> result = validator.TestValidate(client);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidUpdateClientRequest_Test()
        {
            UpdateClientRequest client = new UpdateClientRequest()
            {
                Id = -3,
                FirstName = "",
                LastName = "123",
                MiddleName = "",
                Experience = -2
            };

            TestValidationResult<UpdateClientRequest> result = validator.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.FirstName);
            result.ShouldHaveValidationErrorFor(x => x.LastName);
            result.ShouldHaveValidationErrorFor(x => x.MiddleName);
            result.ShouldHaveValidationErrorFor(x => x.Experience);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
