using Dapper;
using Biblioteka.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Services
{
    public class BorrowService
    {
       
        private readonly string connectionString = @"Server=.\SQLEXPRESS; Database=Mini_biblioteka;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static List<Book> Books;

        public void AddBook(Book book)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Book
                ([title], [author], [year])
                VALUES (@Title,@Author,@Year)";

                var db = new DynamicParameters();
                db.Add("@Title", book.Title);
                db.Add("@Author", book.Author);
                db.Add("@Year", book.Year);

                int result = connection.Execute(query, db);

            }
        }
            public List<Book> GetBooks()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Book>("Select * from book").ToList();
                return result;
            }
        }

        private static List<Reader> Readers;
        public void AddReader(Reader reader)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Reader
                ( [Name], [Surname], [Street],[StreetNumber],[PostCode])
                VALUES (@Name,@Surname,@Street,@StreetNumber,@PostCode)";

                var db = new DynamicParameters();
                db.Add("@Name", reader.Name);
                db.Add("@Surname", reader.Surname);
                db.Add("@Street", reader.Street);
                db.Add("@StreetNumber", reader.StreetNumber);
                db.Add("@PostCode", reader.PostCode);

                int result = connection.Execute(query, db);

            }
        }
        public List<Reader> GetReaders()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();               
                var result = connection.Query<Reader>("Select * from reader").ToList();
                return result;
            }
        }

        private static List<Borrow> Borrows;
        public void AddBorrow(Borrow borrow)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Borrowing
                ( [id_book], [id_reader], [borrowdate],[returndate])
                VALUES (@Book,@Reader,@BorrowDate,@ReturnDate)";

                var db = new DynamicParameters();
                db.Add("@Book", borrow.Book );
                db.Add("@Reader", borrow.Reader);
                db.Add("@BorrowDate", borrow.BorrowDate);
                db.Add("@ReturnDate", borrow.ReturnDate);

                int result = connection.Execute(query, db);

            }
        }

        public List<Borrow> GetBorrows()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Borrow>("SELECT title as Book, name + ' ' + surname as Reader, borrowdate, returndate from book inner join borrowing on book.id = borrowing.id_book inner join reader on reader.id = borrowing.id_reader ").ToList();
                return result;


            }
        }
    }
}
