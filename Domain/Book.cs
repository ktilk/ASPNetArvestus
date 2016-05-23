using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book
    {
        public int BookId { get; set; }
        [MaxLength(128)]
        public string Title { get; set; }

        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual List<AuthorBook> BookAuthors { get; set; } = new List<AuthorBook>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
