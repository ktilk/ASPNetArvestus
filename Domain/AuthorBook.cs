using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AuthorBook
    {
        public int AuthorBookId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
