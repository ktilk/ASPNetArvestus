using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using PagedList;

namespace ASPNetArvestus.ViewModels
{
    public class BookCreateEditViewModel
    {
        public Book Book { get; set; }
        public SelectList PublisherSelectList { get; set; }

        public int[] AuthorIds { get; set; }
        public MultiSelectList AuthorMultiSelectList { get; set; }
    }

    public class BookIndexViewModel
    {
        public List<Book> Books { get; set; }

        public string Filter { get; set; }
    }
}