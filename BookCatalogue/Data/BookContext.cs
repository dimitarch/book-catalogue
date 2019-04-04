using BookCatalogue.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue.Data
{
    class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookContext")
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
