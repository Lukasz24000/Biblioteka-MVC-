using Biblioteka.Entities;
using Biblioteka.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class BookModel
    {

        public BookModel()
        {
            var books = new BorrowService().GetBooks();
            Books = new SelectList(books, "Id","Title");
        }
        public SelectList Books { get; set; }
        public Book Book { get; set; }
    }
}
