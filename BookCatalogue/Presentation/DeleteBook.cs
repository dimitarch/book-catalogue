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
    public partial class DeleteBook : Form
    {
        public BookLogistics books = new BookLogistics();

        public DeleteBook()
        {
            InitializeComponent();
        }

        public int Id { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Id = int.Parse(textBox1.Text);


            if (books.GetById(Id) != null)
            {
                books.Delete(Id);
            }
            else
            {
                string caption = "Warning!";
                string message = "No such book in the database!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }

            this.Close();
        }
    }
}
