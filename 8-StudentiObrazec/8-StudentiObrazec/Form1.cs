using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_StudentiObrazec
{
    public partial class Form1 : Form
    {
        BindingList<Student> b = new BindingList<Student>();

        


        public Form1()
        {
            InitializeComponent();
            // listBox1.Items.Add(Tomi);

            listBox1.DataSource = b;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.Add(new Student(textBox_ime.Text, textBox_priimek.Text, comboBox1_spol.Text, dateTimePicker1_Datum.Value));
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Gumb_odstrani_Click(object sender, EventArgs e)
        {
            
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }
    }
}
