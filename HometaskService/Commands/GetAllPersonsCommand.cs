using HometaskService.Commands.Interfaces;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;

namespace HometaskService.Commands
{
    public class GetAllPersonsCommand : IGetAllPersonsCommand
    {
        private readonly IPersonRepository _repository;
        public GetAllPersonsCommand(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<string> Execute()
        {
            return _repository.GetAll();
        }
    }
}
