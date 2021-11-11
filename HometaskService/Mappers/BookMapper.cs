using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;

namespace HometaskService.Mappers
{
    public class BookMapper : IMapper<DBBook, BookDTO>
    {
        public BookDTO Map(DBBook book)
        {
            if (book is null)
            {
                return null;
            }

            return new BookDTO()
            {
                Name = book.Name,
                Author = book.Author
            };
        }
    }
}
