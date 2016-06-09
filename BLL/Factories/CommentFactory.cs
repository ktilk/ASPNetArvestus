using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using Domain;

namespace BLL.Factories
{
    public static class CommentFactory
    {
        public static CommentDTO CreateBasicDTO(Comment comment)
        {
            return new CommentDTO()
            {
                CommentId = comment.CommentId,
                CommentText = comment.CommentText,
                AuthorDTO = AuthorFactory.CreateBasicDTO(comment.Author),
                BookDTO = BookFactory.CreateBasicDTO(comment.Book)
            };
        }
    }
}
