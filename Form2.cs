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
    public partial class Form2 : Form
    {
        public Form2(string input)
        {
            InitializeComponent();
            textBox1.Text = input;
            run_length();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox1.Text.Length.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox2.Text.Length.ToString();
        }

        public void run_length() {
            try
            {
                if (textBox1.Text == "")
                {
                    return;
                }
                String Comprission = "";
                String code = textBox1.Text;
                char seq = code[0];
                int count = 1;
                for (int i = 1; i < code.Length; i++)
                {
                    if (code[i] == seq)
                    {
                        count++;
                        if (count > 9)
                        {
                            count = 9;
                        }
                    }
                    else
                    {
                        Comprission += count.ToString() + seq;
                        seq = code[i];
                        count = 1;
                    }
                }
                Comprission += count.ToString() + seq;
                textBox2.Text = Comprission;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
