using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class AuthorService : IService<AuthorDTO>
    {
        public List<AuthorDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AuthorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AuthorDTO Add(AuthorDTO t)
        {
            throw new NotImplementedException();
        }

        public AuthorDTO Update(int id, AuthorDTO t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
