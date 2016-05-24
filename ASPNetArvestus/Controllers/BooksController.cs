using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNetArvestus.ViewModels;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace ASPNetArvestus.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataBaseContext _db = new DataBaseContext();
        private readonly IBookRepository _repo;
        private readonly IEFRepository<Publisher> _repoPublisher;
        private readonly IEFRepository<Author> _repoAuthors;
        private readonly IEFRepository<AuthorBook> _repoAuthorBooks;

        public BooksController()
        {
            _repo = new BookRepository(_db);
            _repoPublisher = new EFRepository<Publisher>(_db);
            _repoAuthors = new EFRepository<Author>(_db);
            _repoAuthorBooks = new EFRepository<AuthorBook>(_db);
        }
        // GET: Books
        public ActionResult Index(BookIndexViewModel vm)
        {
            var res = _repo.GetFiltered(vm.Filter);
            vm.Books = res;
            return View(vm);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var vm = new BookCreateEditViewModel()
            {
                PublisherSelectList = new SelectList(_repoPublisher.All, "PublisherId", "PublisherName"),
                AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId), nameof(Author.FirstLastName))
            };

            return View(vm);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                foreach (var autohrId in vm.AuthorIds)
                {
                    vm.Book.BookAuthors.Add(new AuthorBook()
                    {
                        AuthorId = autohrId
                    });
                }
                _repo.Add(vm.Book);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.PublisherSelectList = new SelectList(_repoPublisher.All, "PublisherId", "PublisherName");
            return View(vm);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var vm = new BookCreateEditViewModel()
            {
                Book = book,
                PublisherSelectList = new SelectList(_repoPublisher.All, "PublisherId", "PublisherName"),
                AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId), nameof(Author.FirstLastName), _repoAuthorBooks.All.Where(x => x.BookId == book.BookId).Select(b => b.AuthorId).ToArray())
            };
            return View(vm);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //kõigepealt lastakse autorite list tühjaks, selle asemel, et uurida, millised autorid seal olid
                foreach (var authorBook in _repoAuthorBooks.All.Where(x => x.BookId == vm.Book.BookId))
                {
                    _repoAuthorBooks.Delete(authorBook);
                }
                _repo.Update(vm.Book);
                _repo.SaveChanges();
                //seejärel lisatakse valitud autorid listi
                foreach (var authorId in vm.AuthorIds)
                {
                    vm.Book.BookAuthors.Add((new AuthorBook() { AuthorId = authorId, AuthorBookId = vm.Book.BookId}));
                }
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.PublisherSelectList = new SelectList(_repoPublisher.All, "PublisherId", "PublisherName");
            vm.AuthorMultiSelectList = new MultiSelectList(_repoAuthors.All, nameof(Author.AuthorId),
                nameof(Author.FirstLastName), vm.AuthorIds);
            return View(vm);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _repo.GetById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            _repo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
