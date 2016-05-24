using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class BookRepository : EFRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public List<Book> GetFiltered(string filter)
        {
            filter = filter?.ToLower() ?? "";
            var result = DbSet.ToList();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                result = result.Where(x => x.Title.ToLower().Contains(filter) || x.Publisher.PublisherName.ToLower().Contains(filter) || x.BookAuthors.Any(y => y.Author.FirstName.ToLower().Contains(filter) || y.Author.LastName.ToLower().Contains(filter))).ToList();
            }
            return result;
        }
    }
}
