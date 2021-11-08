using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;
using HometaskService.Repositories.Interfaces;

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

        public BookDTO Execute(int id)
        {
            return _mapper.Map(_repository.Get(id));
        }
    }
}
