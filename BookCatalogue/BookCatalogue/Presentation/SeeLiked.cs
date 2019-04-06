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
    public partial class SeeLiked : Form
    {
        public SeeLiked()
        {
            InitializeComponent();
        }

        private void SeeLiked_Load(object sender, EventArgs e)
        {
            var bookCatalogue = new BookLogistics();
            List<string> allLiked = new List<string>();

            listBox1.Items.Clear();
            foreach (var book in bookCatalogue.GetAll())
            {
                if (book.Liked == true)
                {
                    allLiked.Add($"{book.Id} -- {book.Name} -- {book.Author}");
                }
            }

            listBox1.DataSource = allLiked;
        }
    }
}
