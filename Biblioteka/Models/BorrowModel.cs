using Biblioteka.Entities;
using Biblioteka.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class BorrowModel
    {
        public BorrowModel()
        {
            var readers = new BorrowService().GetReaders();
            var books = new BorrowService().GetBooks();

            Readers = new SelectList(readers, "Id", "Name");
            Books = new SelectList(books,"Id", "Title");
        }
        public SelectList Readers { get; set; }
        public SelectList Books { get; set; }
        public Borrow Borrow { get; set; }
    }
}

