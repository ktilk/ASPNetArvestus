using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public static class AuthorFactory
    {
        public static AuthorDTO CreateBasicDTO(Author author)
        {
            return new AuthorDTO()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
    }
}
