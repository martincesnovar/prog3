using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slikar
{
    public partial class Form1 : Form
    {

        Point zadnjaLokacija;
        bool risemo;

        


        public Form1()
        {
            InitializeComponent();
            okvirZaSlike.BackgroundImage = new Bitmap(okvirZaSlike.ClientSize.Width, okvirZaSlike.ClientSize.Height);

        }




        private void PritiskMiske(object sender, MouseEventArgs e)
        {
            zadnjaLokacija = e.Location;
            risemo = true;
        }

        private void DvigMiske(object sender, MouseEventArgs e)
        {
            risemo = false;
        }
        

        private void PremikMiske(object sender, MouseEventArgs e)
        {
            if (risemo)
            {

                using (Graphics g = Graphics.FromImage(okvirZaSlike.BackgroundImage))
                {
                    g.DrawLine(Pens.Blue, zadnjaLokacija, e.Location);
                }
                zadnjaLokacija = e.Location; // Posodobimo lokacijo
                okvirZaSlike.Invalidate();
            }
        }

        private void okvirZaSlike_DvojniKlikMiske(object sender, MouseEventArgs e)
        {
            okvirZaSlike.BackgroundImage = new Bitmap(okvirZaSlike.ClientSize.Width, okvirZaSlike.ClientSize.Height);
        }
    }
}
