using CarRentalService.Request;
using FluentValidation.TestHelper;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class DeleteRentalCarValidatorTests
    {
        private DeleteRentalCarValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new DeleteRentalCarValidator();
        }

        [Test]
        public void ValidDeleteRentalCarRequest_Test()
        {
            DeleteRentalCarRequest car = new DeleteRentalCarRequest()
            {
                Id = 4
            };

            TestValidationResult<DeleteRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidDeleteRentalCarRequest_Test()
        {
            DeleteRentalCarRequest car = new DeleteRentalCarRequest()
            {
                Id = 0
            };

            TestValidationResult<DeleteRentalCarRequest> result = validator.TestValidate(car);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }
    }
}
