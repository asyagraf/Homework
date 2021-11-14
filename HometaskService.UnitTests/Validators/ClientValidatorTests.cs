using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class ClientValidatorTests
    {
        private ClientValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new ClientValidator();
        }

        [Test]
        public void ValidClientRequest_Test()
        {
            ClientRequest client = new ClientRequest()
            {
                Id = 5
            };

            TestValidationResult<ClientRequest> result = validator.TestValidate(client);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidCar_Test()
        {
            ClientRequest client = new ClientRequest()
            {
                Id = 0
            };

            TestValidationResult<ClientRequest> result = validator.TestValidate(client);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
