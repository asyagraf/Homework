using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using NUnit.Framework;

namespace HometaskService.UnitTests.Mappers
{
    class PersonMappersTest
    {
        private IMapper<Person, PersonDTO> mapperPersonToPersonDTO;

        private Person person;

        [SetUp]
        public void SetUp()
        {
            mapperPersonToPersonDTO = new PersonMapper();

            person = new Person()
            {
                Id = 5,
                Name = "Andrew",
                Surname = "Scott",
                Age = 35
            };
        }

        [Test]
        public void ShouldReturnNullWhenPersonIsNull()
        {
            var result = mapperPersonToPersonDTO.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnPersonDTOWhenMappingValidPerson()
        {
            var result = mapperPersonToPersonDTO.Map(person);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PersonDTO>(result);
        }
    }
}
