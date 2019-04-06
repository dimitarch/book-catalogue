using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookCatalogue.Presentation
{
    public partial class Details : Form
    {
        public Details()
        {
            InitializeComponent();
        }

        public string Title
        {
            set { textBox2.Text = value; }
        }

        public string Author
        {
            set { textBox3.Text = value; }
        }

        public string Description
        {
            set { textBox4.Text = value; }
        }

        public string Comment
        {
            set { textBox5.Text = value; }
        }

        public bool Read
        {
            set { checkBox1.Checked = value; }
        }

        public bool Liked
        {
            set { checkBox2.Checked = value; }
        }

        public bool Loved
        {
            set { checkBox3.Checked = value; }
        }
    }
}
