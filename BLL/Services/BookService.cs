using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Factories;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace BLL.Services
{
    public class BookService : IService<BookDTO>
    {
        private readonly IBookRepository _bookRepo;
        //private readonly IPublisherRepository _publisherRepo;

        public BookService()
        {
            _bookRepo = new BookRepository(new DataBaseContext());
            //_publisherRepo = new PublisherRepository(new DataBaseContext());
        }

        public List<BookDTO> GetAll()
        {
            return _bookRepo.All.Select(x => BookFactory.CreateBasicDTO(x)).ToList();
        }

        public BookDTO GetById(int id)
        {
            var query = _bookRepo.GetById(id);
            if (query == null) return null;
            return BookFactory.CreateBasicDTO(query);
        }

        public BookDTO Add(BookDTO t)
        {
            var newBook = new Book
            {
                Title = t.BookTitle,
                PublisherId = t.PublisherDTO.PublisherId
            };
            _bookRepo.Add(newBook);
            _bookRepo.SaveChanges();
            return BookFactory.CreateBasicDTO(newBook);
        }

        public BookDTO Update(int id, BookDTO t)
        {
            var book = _bookRepo.GetById(id);
            if (book == null) return null;

            book.Title = t.BookTitle;
            book.PublisherId = t.PublisherDTO.PublisherId;
            
            _bookRepo.Update(book);
            _bookRepo.SaveChanges();

            return BookFactory.CreateBasicDTO(book);
        }

        public void Delete(int id)
        {
            _bookRepo.Delete(id);
            _bookRepo.SaveChanges();
        }
    }
}
