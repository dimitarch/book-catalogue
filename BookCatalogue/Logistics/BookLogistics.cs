using BookCatalogue.Data;
using BookCatalogue.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue.Logistics
{
    public class BookLogistics
    {
        public BookContext bookContext;

        public List<Book> GetAll()
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.ToList();
            }
        }

        public List<Book> GetLoved()
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Where(b => b.Loved == true).ToList();
            }
        }

        public List<Book> GetLiked()
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Where(b => b.Liked == true).ToList();
            }
        }

        public List<Book> GetRead()
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Where(b => b.Read == true).ToList();
            }
        }

        public List<Book> GetByName(string name)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Where(b => b.Name == name).ToList();
            }
        }

        public List<Book> GetByAuthor(string author)
        {
            using (bookContext = new BookContext())
            {
                return bookContext.Books.Where(b => b.Author == author).ToList();
            }
        }

        public Book GetById(int id)
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

        public void MarkLoved(Book book)
        {
            book.Loved = true;
            book.Liked = false;
        }

        public void MarkLiked(Book book)
        {
            book.Liked = true;
            book.Loved = false;
        }

        public void MarkRead(Book book)
        {
            book.Read = true;
        }

        public void AddComment(Book book, string comment)
        {
            book.Comment = comment;
        }
    }
}