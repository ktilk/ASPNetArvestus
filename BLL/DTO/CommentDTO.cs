using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public AuthorDTO AuthorDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
