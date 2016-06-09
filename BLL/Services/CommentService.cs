using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;

namespace BLL.Services
{
    public class CommentService : IService<CommentDTO>
    {

        public CommentService()
        {
            
        }

        public List<CommentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommentDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CommentDTO Add(CommentDTO t)
        {
            throw new NotImplementedException();
        }

        public CommentDTO Update(int id, CommentDTO t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
