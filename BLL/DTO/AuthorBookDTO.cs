using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AuthorBookDTO
    {
        public int AuthorBookId { get; set; }
        public AuthorDTO AuthorDTO { get; set; }
        public BookDTO BookDTO { get; set; }
    }
}
