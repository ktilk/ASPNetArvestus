using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace ASPNetArvestus.ViewModels
{
    public class BookCreateEditViewModel
    {
        public Book Book { get; set; }
        public SelectList PublisherSelectList { get; set; }

        public int[] AuthorIds { get; set; }
        public MultiSelectList AuthorMultiSelectList { get; set; }
    }
}