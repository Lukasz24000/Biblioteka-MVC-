using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteka.Models;
using Biblioteka.Services;
using Biblioteka.Entities;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var result = new BorrowService().GetBorrows();
            return View(result);
        }

        public IActionResult AddBorrow()
        {
            ViewBag.Readers = new BorrowModel().Readers;
            ViewBag.Books = new BorrowModel().Books;
            return View();
        }
        [HttpPost]
        public IActionResult AddBorrow(Borrow borrow)
        {
            new BorrowService().AddBorrow(borrow);
            return View();
        }

        public IActionResult AddReader()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddReader(Reader reader)
        {
            new BorrowService().AddReader(reader);
            return View();
        }

        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            new BorrowService().AddBook(book);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
