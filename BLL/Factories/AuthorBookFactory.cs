using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public static class AuthorBookFactory
    {
        public static AuthorBookDTO CreateBasicDTO(AuthorBook authorBook)
        {
            return new AuthorBookDTO()
            {
                AuthorBookId = authorBook.AuthorBookId,
                AuthorDTO = AuthorFactory.CreateBasicDTO(authorBook.Author),
                BookDTO = BookFactory.CreateBasicDTO(authorBook.Book)
            };
        }
    }
}
