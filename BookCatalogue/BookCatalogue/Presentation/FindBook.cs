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
    public partial class FindBook : Form
    {
        public BookLogistics books = new BookLogistics();

        public FindBook()
        {
            InitializeComponent();
        }

        public int Id
        { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Id = int.Parse(textBox1.Text);

            Data.Models.Book book = new Data.Models.Book();

            book = books.GetById(Id);

            Presentation.Details Details = new Presentation.Details();

            if (book != null)
            {
                Details.Title = book.Name;
                Details.Author = book.Author;
                Details.Description = book.Description;
                Details.Comment = book.Comment;
                Details.Read = book.Read;
                Details.Loved = book.Loved;
                Details.Liked = book.Liked;

                Details.Show();
            }
            else
            {
                string caption = "Book not found!";
                string message = "Use the form to add the new book.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }

            this.Close();
        }
    }
}
