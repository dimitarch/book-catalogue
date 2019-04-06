using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using BookCatalogue.Data;
using BookCatalogue.Data.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogue.Logistics.LogisticsTests
{
    [TestFixture]
    class TestsBookLogistics
    {
        [Test]
        public void TestGetAll_ShouldGetAllBooks()
        {
            var bookLog = new BookLogistics();
            bookLog.bookContext = new BookContext();
            var books = bookLog.bookContext.Books.ToList();
            Assert.AreEqual(books.Count(), bookLog.GetAll().Count());
        }

        [Test]
        public void TestGetLoved_ShouldGetAllLoved()
        {
            var bookLog = new BookLogistics();
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Loved == true).ToList().Count(), bookLog.GetLoved().Count());
        }

        [Test]
        public void TestGetLiked_ShouldGetAllLiked()
        {
            var bookLog = new BookLogistics();
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Liked == true).ToList().Count(), bookLog.GetLiked().Count());
        }

        [Test]
        public void TestGetRead_ShouldGetAllRead()
        {
            var bookLog = new BookLogistics();
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Read == true).Count(), bookLog.GetRead().Count());
        }

        [Test]
        public void TestGetByName_ShouldGetAllByName()
        {
            var bookLog = new BookLogistics();
            string name = "1984";
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Name == name).Count(), bookLog.GetByName(name).Count());
        }

        [Test]
        public void TestGetByName_ShouldGetOnlyWthName()
        {
            var bookLog = new BookLogistics();
            string name = "91s84aswd";
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Name == name).ToList().Count(), 0);
        }

        [Test]
        public void TestGetByAuthor_ShouldGetAllByAuthor()
        {
            var bookLog = new BookLogistics();
            string author = "George Orwell";
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Author == author).Count(), bookLog.GetByAuthor(author).Count());
        }

        [Test]
        public void TestGetByName_ShouldGetOnlyByAuthor()
        {
            var bookLog = new BookLogistics();
            string author = "Gerga21 Orgeb";
            bookLog.bookContext = new BookContext();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Author == author).Count(), 0);
        }

        [Test]
        public void TestGetById_IdInRange_ShouldGetWithId()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            bookLog.bookContext = new BookContext();
            bookLog.Add(book);
            Assert.AreEqual(bookLog.GetById(book.Id).Id, book.Id);
            bookLog.Delete(book.Id);
        }

        [Test]
        public void TestAdd_NormalConditions_ShouldAdd()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            var last = bookLog.GetAll().Last();
            bookLog.Add(book);
            Assert.AreEqual(bookLog.GetAll().Last().Id, last.Id + 1);
            bookLog.Delete(book.Id);
        }

        [Test]
        public void TestUpdate_NormalConditions_ShouldUpdate()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1982", "George Orwell");
            bookLog.Add(book);
            var updatedBook = new Book("1984", "George Orwell");
            updatedBook.Id = book.Id;
            bookLog.Update(updatedBook);
            Assert.AreEqual(bookLog.GetById(book.Id).Name, updatedBook.Name);
            bookLog.Delete(book.Id);
        }

        [Test]
        public void TestDelete_NormalConditions_ShouldDelete()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            var count = bookLog.GetAll().Count();
            bookLog.Add(book);
            bookLog.Delete(book.Id);
            Assert.AreEqual(bookLog.GetAll().Count(), count);
        }
    }
}