using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public PublisherDTO PublisherDTO { get; set; }
    }
}
