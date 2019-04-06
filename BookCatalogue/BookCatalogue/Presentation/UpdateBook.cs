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
    public partial class UpdateBook : Form
    {
        public BookLogistics books = new BookLogistics();

        public UpdateBook()
        {
            InitializeComponent();
        }

        public int Id
        {
            get { return int.Parse(textBox1.Text); }
        }

        public string Title
        {
            get { return textBox2.Text; }
        }

        public string Author
        {
            get { return textBox3.Text; }
        }

        public string Description
        {
            get { return textBox4.Text; }
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

        private void button2_Click(object sender, EventArgs e)
        {

            Data.Models.Book book = new Data.Models.Book();

            book.Id = Id;
            book.Name = Title;
            book.Author = Author;
            book.Description = Description;
            book.Comment = Comment;
            book.Read = Read;
            book.Loved = Loved;
            book.Liked = Liked;

            books.Update(book);

            this.Close();
        }
    }
}
