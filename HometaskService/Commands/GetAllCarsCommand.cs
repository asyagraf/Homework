using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;

namespace HometaskService.Commands
{
    public class GetAllCarsCommand : IGetAllCarsCommand
    {
        private readonly ICarRepository _repository;
        public GetAllCarsCommand(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<Car> Execute()
        {
            return _repository.GetAll();
        }
    }
}
