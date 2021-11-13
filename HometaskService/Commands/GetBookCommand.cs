using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;
using System.Threading.Tasks;

namespace HometaskService.Commands
{
    public class GetBookCommand : IGetBookCommand
    {
        private readonly IBookRepository _repository;
        private readonly IMapper<DBBook, BookDTO> _mapper;
        public GetBookCommand(IBookRepository repository, IMapper<DBBook, BookDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDTO> ExecuteAsync(int id)
        {
            DBBook book = await _repository.Get(id);
            return _mapper.Map(book);
        }
    }
}
