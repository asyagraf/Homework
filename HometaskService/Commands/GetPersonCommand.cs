using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetPersonCommand : IGetPersonCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly IMapper<Person, PersonDTO> _mapper;
        public GetPersonCommand(IRepository<Person, int> repository, IMapper<Person, PersonDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public PersonDTO Execute(int id)
        {
            return _mapper.Map(_repository.Get(id));
        }
    }
}
