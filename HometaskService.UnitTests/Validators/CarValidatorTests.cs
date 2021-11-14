using FluentValidation.TestHelper;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HometaskService.UnitTests.Validators
{
    class CarValidatorTests
    {
        private CarValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new CarValidator();
        }

        [Test]
        public void ValidCar_Test()
        {
            Car car = new Car()
            {
                Owner = "Alex Green",
                Brand = "KIA",
                Model = "Rio",
                Number = "123QWE"
            };

            TestValidationResult<Car> result = validator.TestValidate(car);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidCar_Test()
        {
            Car car = new Car()
            {
                Owner = null,
                Brand = "",
                Model = "",
                Number = "1q"
            };

            TestValidationResult<Car> result = validator.TestValidate(car);
            result.ShouldHaveValidationErrorFor(x => x.Owner);
            result.ShouldHaveValidationErrorFor(x => x.Brand);
            result.ShouldHaveValidationErrorFor(x => x.Model);
            result.ShouldHaveValidationErrorFor(x => x.Number);
        }
    }
}
