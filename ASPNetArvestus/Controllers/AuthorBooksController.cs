using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace ASPNetArvestus.Controllers
{
    public class AuthorBooksController : Controller
    {
        private readonly DataBaseContext _db = new DataBaseContext();
        private readonly IEFRepository<AuthorBook> _repo;
        private readonly IEFRepository<Book> _repoBooks;
        private readonly IEFRepository<Author> _repoAuthors;

        public AuthorBooksController()
        {
            _repo = new EFRepository<AuthorBook>(_db);
            _repoBooks = new EFRepository<Book>(_db);
            _repoAuthors = new EFRepository<Author>(_db);
        }

        // GET: AuthorBooks
        public ActionResult Index()
        {
            var authorBooks = _repo.All;
            return View(authorBooks);
        }

        // GET: AuthorBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _repo.GetById(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // GET: AuthorBooks/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName");
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title");
            return View();
        }

        // POST: AuthorBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(authorBook);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _repo.GetById(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(authorBook);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", authorBook.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", authorBook.BookId);
            return View(authorBook);
        }

        // GET: AuthorBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorBook authorBook = _repo.GetById(id);
            if (authorBook == null)
            {
                return HttpNotFound();
            }
            return View(authorBook);
        }

        // POST: AuthorBooks/Delete/5
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
