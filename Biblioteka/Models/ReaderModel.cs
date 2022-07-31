using Biblioteka.Entities;
using Biblioteka.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class ReaderModel
    {
        public ReaderModel()
        {
            var readers = new BorrowService().GetReaders();
            Readers = new SelectList(readers, "Id", "Name");
        }
        public SelectList Readers { get; set; }
        public Reader Reader { get; set; }
    }
}
