using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HometaskService.Commands
{
    public class GetAllCarsCommand : IGetAllCarsCommand
    {
        private readonly IRepository<Car, string> _repository;
        private readonly IMapper<Car, CarDTO> _mapper;
        public GetAllCarsCommand(IRepository<Car, string> repository, IMapper<Car, CarDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<CarDTO> Execute()
        {
            return _repository.GetAll().Select(car => _mapper.Map(car)).ToList();
        }
    }
}
