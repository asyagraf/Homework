using HometaskService.Commands.Interfaces;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

namespace HometaskService.Commands
{
    public class GetCarCommand : IGetCarCommand
    {
        private readonly ICarRepository _repository;
        private readonly IMapper<Car, CarDTO> _mapper;
        public GetCarCommand(ICarRepository repository, IMapper<Car, CarDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CarDTO Execute(string number)
        {
            return _mapper.Map(_repository.GetByNumber(number));
        }
    }
}
