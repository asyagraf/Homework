using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;

namespace HometaskService.Mappers
{
    public class PersonMapper : IMapper<Person, PersonDTO>
    {
        public PersonDTO Map(Person person)
        {
            if (person is null)
            {
                return null;
            }

            return new PersonDTO()
            {
                Name = person.Name,
                Surname = person.Surname,
                Age = person.Age
            };
        }
    }
}
