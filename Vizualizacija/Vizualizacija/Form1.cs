using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vizualizacija
{
    public partial class Form1 : Form
    {

        void PaintTree()
        {
            if (drevo == null) return;
        }
        string niz;
        private IskalnoDrevo<int> drevo = new IskalnoDrevo<int>();
        //private BinaryTree<int> drevo = new BinaryTree<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void vstavi_Click(object sender, EventArgs e)
        {
            niz = textBox.Text;
            if (Int32.TryParse(niz, out int st))
                drevo.Add(st);
        }

        private void isci_Click(object sender, EventArgs e)
        {
            niz = textBox.Text;
            if (Int32.TryParse(niz, out int st))
                drevo.Find(st);
        }

        private void zbrisi_Click(object sender, EventArgs e)
        {
            niz = textBox.Text;
            if (Int32.TryParse(niz, out int st))
                drevo.Remove(st);
        }
    }
}
