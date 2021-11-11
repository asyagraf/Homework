using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HometaskService.Commands
{
    public class GetAllPersonsCommand : IGetAllPersonsCommand
    {
        private readonly IRepository<Person, int> _repository;
        private readonly IMapper<Person, PersonDTO> _mapper;
        public GetAllPersonsCommand(IRepository<Person, int> repository, IMapper<Person, PersonDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<PersonDTO> Execute()
        {
            return _repository.GetAll().Select(person => _mapper.Map(person)).ToList();
        }
    }
}
