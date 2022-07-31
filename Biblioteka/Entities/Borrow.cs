using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        public  string Book { get; set; }
        public string Reader { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
