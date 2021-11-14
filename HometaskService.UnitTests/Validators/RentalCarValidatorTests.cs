using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class RentalCarValidatorTests
    {
        private RentalCarValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new RentalCarValidator();
        }

        [Test]
        public void ValidRentalCarRequest_Test()
        {
            RentalCarRequest car = new RentalCarRequest()
            {
                Id = 5
            };

            TestValidationResult<RentalCarRequest> result = validator.TestValidate(car);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidRentalCar_Test()
        {
            RentalCarRequest car = new RentalCarRequest()
            {
                Id = 0
            };

            TestValidationResult<RentalCarRequest> result = validator.TestValidate(car);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
