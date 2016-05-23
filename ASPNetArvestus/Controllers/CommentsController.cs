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
    public class CommentsController : Controller
    {
        private readonly DataBaseContext _db = new DataBaseContext();
        private readonly IEFRepository<Comment> _repo;
        private readonly IEFRepository<Book> _repoBooks;
        private readonly IEFRepository<Author> _repoAuthors;

        public CommentsController()
        {
            _repo = new EFRepository<Comment>(_db);
            _repoBooks = new EFRepository<Book>(_db);
            _repoAuthors = new EFRepository<Author>(_db);
        }
        // GET: Comments
        public ActionResult Index()
        {
            var comments = _repo.All;
            return View(comments);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _repo.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName");
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(comment);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _repo.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(comment);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(_repoAuthors.All, "AuthorId", "FirstName", comment.AuthorId);
            ViewBag.BookId = new SelectList(_repoBooks.All, "BookId", "Title", comment.BookId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = _repo.GetById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
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
