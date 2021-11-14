using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class UpdateRentalCarValidatorTests
    {
        private UpdateRentalCarValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new UpdateRentalCarValidator();
        }

        [Test]
        public void ValidRentalCarRequest_Test()
        {
            UpdateRentalCarRequest car = new UpdateRentalCarRequest()
            {
                Id = 7,
                Number = "ANN123",
                IsAvailable = true,
                Brand = "KIA",
                Model = "Rio",
                Mileage = 10,
                ClientId = null
            };

            TestValidationResult<UpdateRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidUpdateRentalCarRequest_Test()
        {
            UpdateRentalCarRequest car = new UpdateRentalCarRequest()
            {
                Id = -3,
                Number = "r123",
                IsAvailable = true,
                Brand = "",
                Model = "",
                Mileage = -3,
                ClientId = -3
            };

            TestValidationResult<UpdateRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldHaveValidationErrorFor(x => x.Number);
            result.ShouldHaveValidationErrorFor(x => x.Id);
            result.ShouldHaveValidationErrorFor(x => x.Brand);
            result.ShouldHaveValidationErrorFor(x => x.Model);
            result.ShouldHaveValidationErrorFor(x => x.Mileage);
            result.ShouldHaveValidationErrorFor(x => x.ClientId);
        }
    }
}
