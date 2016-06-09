using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public static class BookFactory
    {
        public static BookDTO CreateBasicDTO(Book book)
        {
            return new BookDTO()
            {
                BookId = book.BookId,
                BookTitle = book.Title,
                PublisherDTO = PublisherFactory.CreateBasicDTO(book.Publisher)
            };
        }
    }
}
