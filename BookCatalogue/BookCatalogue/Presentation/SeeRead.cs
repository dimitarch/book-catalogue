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
    public partial class SeeRead : Form
    {
        public SeeRead()
        {
            InitializeComponent();
        }

        private void SeeRead_Load(object sender, EventArgs e)
        {
            var bookCatalogue = new BookLogistics();
            List<string> allRead = new List<string>();

            listBox1.Items.Clear();
            foreach (var book in bookCatalogue.GetAll())
            {
                if (book.Read == true)
                {
                    allRead.Add($"{book.Id} -- {book.Name} -- {book.Author}");
                }
            }

            listBox1.DataSource = allRead;
        }
    }
}
