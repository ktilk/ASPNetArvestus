using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [MaxLength(128)]
        public string PublisherName { get; set; }

        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
