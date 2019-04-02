using BookCatalogue.Data;
using BookCatalogue.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue.Logistics
{
    class BookLogistics
    {
        private BookContext bookContext;

        public List<Book> GetAll()
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.ToList();
            }
        }

        public Book Get(int id)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Find(id);
            }
        }

        public void Add(Book book)
        {
            using (bookContext = new BookContext())
            {
                bookContext.Books.Add(book);
                bookContext.SaveChanges();
            }
        }

        public void Update(Book book)
        {
            using (bookContext = new BookContext())
            {
                var item = bookContext.Books.Find(book.Id);
                if (item != null)
                {
                    bookContext.Entry(item).CurrentValues.SetValues(book);
                    bookContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (bookContext = new BookContext())
            {
                var book = bookContext.Books.Find(id);
                if (book != null)
                {
                    bookContext.Books.Remove(book);
                    bookContext.SaveChanges();
                }
            }
        }

        public void MarkLoved()
        {

        }

        public void MarkLiked()
        {

        }

        public void MarkRead()
        {

        }
        
        public void AddComment()
        {

        }
    }
}
