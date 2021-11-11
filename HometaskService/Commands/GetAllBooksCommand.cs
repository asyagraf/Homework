using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HometaskService.Commands
{
    public class GetAllBooksCommand : IGetAllBooksCommand
    {
        private readonly IBookRepository _repository;
        private readonly IMapper<DBBook, BookDTO> _mapper;
        public GetAllBooksCommand(IBookRepository repository, IMapper<DBBook, BookDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<BookDTO> Execute()
        {
            return _repository.GetAll().Select(book => _mapper.Map(book)).ToList();
        }
    }
}
