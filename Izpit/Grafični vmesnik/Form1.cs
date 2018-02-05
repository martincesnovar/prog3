using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void izpisovalnik_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                i = int.Parse(izpisovalnik.Text);
            }
            catch
            {
                i = 0;
            }
            i--;
            if (i > 0)
                izpisovalnik.Text = i.ToString();
            else
                izpisovalnik.Text = "Srečno novo leto!";
        }

        private void ponastavi_Click(object sender, EventArgs e)
        {
            izpisovalnik.Text = "10";
        }

        private void start_Click(object sender, EventArgs e)
        {
            izpisovalnik_VisibleChanged(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            izpisovalnik_VisibleChanged(sender, e);
            
        }
    }
}
