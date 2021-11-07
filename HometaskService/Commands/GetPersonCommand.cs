using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetPersonCommand : IGetPersonCommand
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper<Person, PersonDTO> _mapper;
        public GetPersonCommand(IPersonRepository repository, IMapper<Person, PersonDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public PersonDTO Execute(int id)
        {
            return _mapper.Map(_repository.GetById(id));
        }
    }
}
