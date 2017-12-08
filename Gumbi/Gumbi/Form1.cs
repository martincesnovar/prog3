using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gumbi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gumb_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            int x_gumba = gumb.Width;
            int y_gumba = gumb.Height;
            int x_v = ClientSize.Width-x_gumba;
            int y_v = ClientSize.Height - y_gumba;
            int x = generator.Next(0, x_v);
            int y = generator.Next(0, y_v);
            gumb.Location = new Point(x, y);
        }

        private void gumb_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
