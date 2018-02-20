using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vizualizacija_Dreves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i;
        Drevo<int> drevo;
        Drevo<double> drevo1;
        Drevo<string> drevo_nizov;
        
        void PaintTree()
        {
            if (drevo == null) return;
            pictureBox1.Image = drevo.Draw(out i);
            if (drevo1 == null) return;
            pictureBox1.Image = drevo1.Draw(out i);
            if (drevo_nizov == null) return;
            pictureBox1.Image = drevo_nizov.Draw(out i);
        }

        private void gumb_dodaj_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(iskalnik.Text, out int st))
                {
                    var val = int.Parse(iskalnik.Text);
                    if (drevo == null)  gumb_ustvari_Click(gumb_dodaj, new EventArgs());
                    else drevo.Add(new Drevo<int>(val));
                    PaintTree();
                    this.Update();
                }
                else if (double.TryParse(iskalnik.Text, out double st1))
                {
                    var val = double.Parse(iskalnik.Text);
                    if (drevo1 == null) gumb_ustvari_Click(gumb_dodaj, new EventArgs());
                    else drevo1.Add(new Drevo<double>(val));
                    PaintTree();
                    this.Update();
                }
                else
                {
                    if (drevo_nizov == null) gumb_ustvari_Click(gumb_dodaj, new EventArgs());
                    else drevo_nizov.Add(new Drevo<string>(iskalnik.Text));
                    PaintTree();
                    this.Update();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Napaka");
            }
        }

        private void gumb_ustvari_Click(object sender, EventArgs e)
        {
            string niz = iskalnik.Text;
            if (int.TryParse(niz, out int st))
                drevo = new Drevo<int>(int.Parse(niz));
            else if (double.TryParse(niz, out double st1))
                drevo1 = new Drevo<double>(double.Parse(niz));
            else // niz
                drevo_nizov = new Drevo<string>(niz);
            PaintTree();
        }

        private void GumbOdstrani_Click(object sender, EventArgs e)
        {
            try
            {
                string niz = iskalnik.Text;
                if (int.TryParse(niz, out int st))
                {
                    int val = int.Parse(niz);
                    drevo.Odstrani(val, out bool c);
                    PaintTree();
                    this.Update();
                }
                else if (double.TryParse(niz, out double st1))
                {
                    double val1 = double.Parse(niz);
                    drevo1.Odstrani(val1, out bool c);
                    PaintTree();
                    this.Update();
                }
                else
                {
                    drevo_nizov.Odstrani(niz, out bool c);
                    PaintTree();
                    this.Update();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Napaka");
            }
        }
        /// <summary>
        /// bindanje bližnjic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iskalnik_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) gumb_dodaj_Click(gumb_dodaj, new EventArgs());
            else if (e.KeyCode == Keys.Delete) GumbOdstrani_Click(GumbOdstrani, new EventArgs());
        }

        private void GumbIsci_Click(object sender, EventArgs e)
        {
            prikazovalnik1.Text = drevo.Vrednost.ToString();
            prikazovalnik2.Text = drevo.Levo.Vrednost.ToString();
        }
    }
}
