using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multimedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2(textBox1.Text);
            Form2.ShowDialog();
            //this.Hide();
           // Form2 frm2 = new multimedia.Form2();
            //frm2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(textBox1.Text);
            Form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4(textBox1.Text);
            Form4.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5(textBox1.Text);
            Form5.ShowDialog();
        }

       
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form6 Form6 = new Form6(textBox1.Text);
            Form6.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 Form8 = new Form8(textBox1.Text);
            Form8.ShowDialog();
        }
    }
}
