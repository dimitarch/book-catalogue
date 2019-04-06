using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookCatalogue.Logistics;

namespace BookCatalogue.Presentation
{
    public partial class AddBook : Form
    {
        public BookLogistics books = new BookLogistics();

        public AddBook()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return textBox1.Text; }
        }

        public string Author
        {
            get { return textBox2.Text; }
        }

        public string Description
        {
            get { return textBox3.Text; }
        }

        public string Comment
        {
            get { return textBox5.Text; }
        }

        public bool Read
        {
            get { return checkBox1.Checked; }
        }

        public bool Liked
        {
            get { return checkBox3.Checked; }
        }

        public bool Loved
        {
            get { return checkBox2.Checked; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Models.Book book = new Data.Models.Book();

            book.Name = Title;
            book.Author = Author;
            book.Description = Description;
            book.Comment = Comment;
            book.Read = Read;
            book.Loved = Loved;
            book.Liked = Liked;

            books.Add(book);

            this.Close();
        }
    }
}
