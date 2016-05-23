using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<AuthorBook> AuthorBooks { get; set; } = new List<AuthorBook>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;
    }
}
