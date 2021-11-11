using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetCarCommand : IGetCarCommand
    {
        private readonly IRepository<Car, string> _repository;
        private readonly IMapper<Car, CarDTO> _mapper;
        public GetCarCommand(IRepository<Car, string> repository, IMapper<Car, CarDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CarDTO Execute(string number)
        {
            return _mapper.Map(_repository.Get(number));
        }
    }
}
