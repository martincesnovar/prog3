using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika
{
    public partial class Form1 : Form
    {
        
        private bool menjaj = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void spremeni_barvo(object sender, EventArgs e)
        {
            if (menjaj)
            {
                Color[] c = { Color.Orange, Color.Green, Color.Purple };
                int[] stevci = new int[c.Length];
                Random rand = new Random();
                int rnd = rand.Next(c.Length);
                string niz = "";
                stevci[rnd]++;
                button1.BackColor = c[rnd];
                pictureBox1.BackColor = c[rnd];
                for(int i = 0; i < stevci.Length; i++)
                {
                    niz+=stevci[rnd];
                    richTextBox1.Text+=stevci[i];
                }
                
            }
        }

        private void preklopi(object sender, EventArgs e)
        {
            menjaj = !menjaj;
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
