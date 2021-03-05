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
    public partial class Form3 : Form
    {
        public Form3(string input)
        {
            InitializeComponent();
            textBox1.Text = input;
            run_length_decode();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox1.Text.Length.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox2.Text.Length.ToString();
        }

        private void run_length_decode()
        {
            try
            {
                String code = textBox1.Text;
                String Decompression = "";
                for (int i = 0; i < code.Length; i += 2)
                {
                    int num = int.Parse(code[i].ToString());
                    char sympol = code[i + 1];
                    for (int j = 0; j < num; j++)
                    {
                        Decompression += sympol;
                    }
                }
                textBox2.Text = Decompression;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
