using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class CreateRentalCarValidatorTests
    {
        private CreateRentalCarValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new CreateRentalCarValidator();
        }

        [Test]
        public void ValidRentalCarRequest_Test()
        {
            CreateRentalCarRequest car = new CreateRentalCarRequest()
            {
                Number = "ANN123",
                IsAvailable = true,
                Brand = "KIA",
                Model = "Rio",
                Mileage = 10,
                ClientId = null
            };

            TestValidationResult<CreateRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidCreateRentalCarRequest_Test()
        {
            CreateRentalCarRequest car = new CreateRentalCarRequest()
            {
                Number = "r123",
                IsAvailable = true,
                Brand = "",
                Model = "",
                Mileage = -3,
                ClientId = -3
            };

            TestValidationResult<CreateRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldHaveValidationErrorFor(x => x.Number);
            result.ShouldHaveValidationErrorFor(x => x.Brand);
            result.ShouldHaveValidationErrorFor(x => x.Model);
            result.ShouldHaveValidationErrorFor(x => x.Mileage);
            result.ShouldHaveValidationErrorFor(x => x.ClientId);
        }
    }
}
