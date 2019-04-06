using System;
using BookCatalogue.Logistics;
using BookCatalogue.Data;
using BookCatalogue.Presentation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCatalogue
{

    public partial class Form1 : Form
    {
        public BookLogistics books = new BookLogistics();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presentation.FindBook Find = new Presentation.FindBook();
            Find.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presentation.AddBook Addition = new Presentation.AddBook();
            Addition.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Presentation.DeleteBook Deletion = new Presentation.DeleteBook();
            Deletion.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Presentation.UpdateBook Update = new Presentation.UpdateBook();
            Update.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SeeCatalogue Catalogue = new SeeCatalogue();
            Catalogue.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            SeeLiked Liked = new SeeLiked();
            Liked.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            SeeLoved Loved = new SeeLoved();
            Loved.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SeeRead Read = new SeeRead();
            Read.Show();
        }
    }
}
