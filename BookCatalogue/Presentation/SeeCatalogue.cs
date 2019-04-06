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
    public partial class SeeCatalogue : Form
    {
        public SeeCatalogue()
        {
            InitializeComponent();
        }

        private void SeeCatalogue_Load(object sender, EventArgs e)
        {
            var bookCatalogue = new BookLogistics();
            List<string> allBooks = new List<string>();

            listBox1.Items.Clear();
            foreach(var book in bookCatalogue.GetAll())
            {
                allBooks.Add($"{book.Id} -- {book.Name} -- {book.Author}");
            }

            listBox1.DataSource = allBooks;
        }
    }
}
