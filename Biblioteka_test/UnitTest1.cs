using NUnit.Framework;
using Biblioteka;
using Biblioteka.Services;
using Biblioteka.Entities;
using System;

namespace Biblioteka_test
{

    public class Tests
    {

        //Reader Czytelnik = new Reader();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGet()
        {
            new BorrowService().GetBorrows();
            new BorrowService().GetBooks();
            new BorrowService().GetReaders();
        }
        [Test]
        public void TestAddReader()
        {
            Reader Czytelnik = new Reader();
            Czytelnik.Name = "Piotr";
            Czytelnik.Surname = "Lewandowski";
            Czytelnik.Street = "Fio³kowa";
            Czytelnik.StreetNumber = 206;
            Czytelnik.PostCode = 39834;
            new BorrowService().AddReader(Czytelnik);
        }
        [Test]
        public void TestAddBook()
        {
            Book Ksiazka = new Book();
            Ksiazka.Title = "Kod Leonarda da Vinci";
            Ksiazka.Author = "Dan Brown";
            Ksiazka.Year = 2006;
            new BorrowService().AddBook(Ksiazka);
        }
        [Test]
        public void TestAddBorrowing()
        {
            Borrow Wypozyczenie = new Borrow();
            Wypozyczenie.Reader = "2";
            Wypozyczenie.Book = "4";
            Wypozyczenie.BorrowDate = new DateTime (2018, 7, 24);
            Wypozyczenie.ReturnDate = new DateTime(2022, 8, 5);
            new BorrowService().AddBorrow(Wypozyczenie);
        }
    }
}