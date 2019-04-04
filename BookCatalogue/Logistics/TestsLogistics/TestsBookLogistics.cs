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
            Assert.AreEqual(bookLog.bookContext.Books.Count(), bookLog.GetAll().Count());
        }

        [Test]
        public void TestGetLoved_ShouldGetAllLoved()
        {
            var bookLog = new BookLogistics();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Loved == true).Count(), bookLog.GetLoved().Count());
        }

        [Test]
        public void TestGetLiked_ShouldGetAllLiked()
        {
            var bookLog = new BookLogistics();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Liked == true).Count(), bookLog.GetLiked().Count());
        }

        [Test]
        public void TestGetRead_ShouldGetAllRead()
        {
            var bookLog = new BookLogistics();
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Read == true).Count(), bookLog.GetRead().Count());
        }

        [Test]
        public void TestGetByName_ShouldGetAllByName()
        {
            var bookLog = new BookLogistics();
            string name = "1984";
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Name == name).Count(), bookLog.GetByName(name).Count());
        }

        [Test]
        public void TestGetByName_ShouldGetOnlyWthName()
        {
            var bookLog = new BookLogistics();
            string name = "91s84aswd";
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Name == name).Count(), 0);
        }

        [Test]
        public void TestGetByAuthor_ShouldGetAllByAuthor()
        {
            var bookLog = new BookLogistics();
            string author = "George Orwell";
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Author == author).Count(), bookLog.GetByAuthor(author).Count());
        }

        [Test]
        public void TestGetByName_ShouldGetOnlyByAuthor()
        {
            var bookLog = new BookLogistics();
            string author = "Gerga21 Orgeb";
            Assert.AreEqual(bookLog.bookContext.Books.Where(b => b.Author == author).Count(), 0);
        }

        [Test]
        public void TestGetById_IdInRange_ShouldGetWithId()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            bookLog.Add(book);
            Assert.AreEqual(bookLog.GetById(book.Id).Id, book.Id);
        }

        [Test]
        public void TestGetById_IdOutOFRange_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            bookLog.Add(book);
            Assert.Throws<IndexOutOfRangeException>(() => bookLog.GetById(bookLog.bookContext.Books.Count() +2));
        }

        [Test]
        public void TestAdd_NormalConditions_ShouldAdd()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            var count = bookLog.bookContext.Books.Count();
            bookLog.Add(book);
            Assert.AreEqual(bookLog.bookContext.Books.Count(), count + 1);
        }

        [Test]
        public void TestAdd_NullName_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book(null, "George Orwell");
            Assert.Throws<DbEntityValidationException>(() => bookLog.Add(book));
        }

        [Test]
        public void TestAdd_NullAuthor_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", null);
            Assert.Throws<DbEntityValidationException>(() => bookLog.Add(book));
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
        }

        [Test]
        public void TestUpdate_NullName_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1982", "George Orwell");
            bookLog.Add(book);
            var updatedBook = new Book(null, "George Orwell");
            updatedBook.Id = book.Id;
            Assert.Throws<DbEntityValidationException>(() => bookLog.Update(updatedBook));
        }

        [Test]
        public void TestUpdate_NullAuthor_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1982", "George Orwell");
            bookLog.Add(book);
            var updatedBook = new Book("1984", null);
            updatedBook.Id = book.Id;
            Assert.Throws<DbEntityValidationException>(() => bookLog.Update(updatedBook));
        }

        [Test]
        public void TestDelete_NormalConditions_ShouldDelete()
        {
            var bookLog = new BookLogistics();
            var book = new Book("1984", "George Orwell");
            var count = bookLog.bookContext.Books.Count();
            bookLog.Add(book);
            bookLog.Delete(book.Id);
            Assert.AreEqual(bookLog.bookContext.Books.Count(), count);
        }

        [Test]
        public void TestDelete__DbDoesNotContainElement_ShouldThrowException()
        {
            var bookLog = new BookLogistics();
            var book = new Book("George Orwell", "1984");
            Assert.Throws<DbUpdateConcurrencyException>(() => bookLog.Add(book));
        }
    }
}
