using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<BookDTO>> ExecuteAsync()
        {
            List<DBBook> books = await _repository.GetAll();
            return books.Select(book => _mapper.Map(book)).ToList();
        }
    }
}
