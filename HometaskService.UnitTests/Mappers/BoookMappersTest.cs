using HometaskService.DBModels;
using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;
using NUnit.Framework;

namespace HometaskService.UnitTests.Mappers
{
    class BookMappersTest
    {
        private IMapper<DBBook, BookDTO> mapperDBBookToBookDTO;

        private DBBook book;

        [SetUp]
        public void SetUp()
        {
            mapperDBBookToBookDTO = new BookMapper();

            book = new DBBook()
            {
                Id = 10,
                Name = "Война и Мир",
                Author = "Лев Николаевич Толстой"
            };
        }

        [Test]
        public void ShouldReturnNullWhenDBBookIsNull()
        {
            var result = mapperDBBookToBookDTO.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnBookDTOWhenMappingValidDBBook()
        {
            var result = mapperDBBookToBookDTO.Map(book);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<BookDTO>(result);
        }
    }
}
