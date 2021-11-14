using FluentValidation.TestHelper;
using HometaskService.Models;
using HometaskService.Validation;
using NUnit.Framework;

namespace HometaskService.UnitTests.Validators
{
    class PersonValidatorTests
    {
        private PersonValidator validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            validator = new PersonValidator();
        }

        [Test]
        public void ValidPerson_Test()
        {
            Person person = new Person()
            {
                Id = 7,
                Name = "Name",
                Surname = "Surname",
                Age = 20
            };

            TestValidationResult<Person> result = validator.TestValidate(person);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void InvalidPerson_Test()
        {
            Person person = new Person()
            {
                Id = -2,
                Name = "",
                Surname = "",
                Age = -20
            };

            TestValidationResult<Person> result = validator.TestValidate(person);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Id);
            result.ShouldHaveValidationErrorFor(x => x.Surname);
            result.ShouldHaveValidationErrorFor(x => x.Age);
        }
    }
}
