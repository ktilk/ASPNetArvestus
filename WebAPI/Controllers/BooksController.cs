using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.Services;
using DAL;
using Domain;

namespace WebAPI.Controllers
{
    public class BooksController : ApiController
    {
        private BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        // GET: api/Books
        public List<BookDTO> GetBooks()
        {
            return _bookService.GetAll();
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookDTO))]
        public IHttpActionResult GetBook(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, BookDTO bookdto)
        {
            var book = _bookService.Update(id, bookdto);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = _bookService.Add(book);

            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            if (_bookService.GetById(id) == null)
            {
                return NotFound();
            }
            _bookService.Delete(id);
            return Ok();
        }
    }
}