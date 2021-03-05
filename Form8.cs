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
    public partial class Form8 : Form
    {
        public Form8(string input)
        {
            InitializeComponent();
            textBox1.Text = input;
        }
        private SolidBrush blackBrush;
        int totalNodes = 0, maxTreeHeight = 0;
        node the_tree = null;
        node the_new = null;
        private Pen blackPen;
        Dictionary<string, node> char_connect_node = new Dictionary<string, node>();
        adaptive ad = null;

        private void Form8_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.SizeChanged += new EventHandler(panel1_SizeChanged);
            panel1.Font = new Font("SansSerif", 20.0f, FontStyle.Bold);
            blackPen = new Pen(Color.Black);
            blackBrush = new SolidBrush(Color.Black);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (the_tree != null)
                DrawTree(the_tree, e.Graphics);
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Form8_SizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad = null;
            the_tree = null;
            label1.Text = "";
            //textBox1.Text = "";

            int depth = 1;
            totalNodes = 0;
            InorderTraversal(the_tree, depth);
            maxTreeHeight = TreeHeight(the_tree);

            panel1.Invalidate();
            textBox1.Text = "";
        }

        private void InorderTraversal(node t, int depth)
        {
            if (t != null)
            {
                InorderTraversal(t.Left, depth + 1);
                t.Xpos = totalNodes++ + 1;
                t.Ypos = depth - 1;
                InorderTraversal(t.Right, depth + 1);
            }
        }

        private int TreeHeight(node t)
        {
            if (t == null) return -1;
            else return 1 + Math.Max(TreeHeight(t.Left), TreeHeight(t.Right));

        }

        public void DrawTree(node root, Graphics g)
        {
            try
            {
                panel1.Width = ClientSize.Width - 50;
                panel1.Height = ClientSize.Height - 20;

                int Width = panel1.Width;
                int Height = panel1.Height;
                int dx = 0, dy = 0, dx2 = 0, dy2 = 0, ys = 20;
                int XSCALE, YSCALE;
                int treeHeight = TreeHeight(root);

                XSCALE = (int)(Width / totalNodes);
                YSCALE = (int)((Height - ys) / (maxTreeHeight + 1));

                if (root != null)
                {
                    DrawTree(root.Left, g);
                    dx = root.Xpos * XSCALE;
                    dy = root.Ypos * YSCALE;
                    string s = root.sympol.ToString() + "(" + root.c.ToString() + ")";
                    g.DrawString(s, panel1.Font, blackBrush, new PointF(dx - ys - 30, dy));

                    if (root.Left != null)
                    {
                        dx2 = root.Left.Xpos * XSCALE;
                        dy2 = root.Left.Ypos * YSCALE;
                        g.DrawLine(blackPen, dx, dy, dx2, dy2);
                    }

                    if (root.Right != null)
                    {
                        dx2 = root.Right.Xpos * XSCALE;
                        dy2 = root.Right.Ypos * YSCALE;
                        g.DrawLine(blackPen, dx, dy, dx2, dy2);
                    }
                    DrawTree(root.Right, g);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text.Length > 1)
            {
                return;
            }

            if (ad == null)
                ad = new adaptive(textBox1.Text[0]);
            else
                ad.insertnew(textBox1.Text[0]);

            the_tree = ad.root;
            label1.Text += textBox1.Text[0];
            //textBox1.Text += textBox1.Text[0];

            int depth = 1;
            totalNodes = 0;
            InorderTraversal(the_tree, depth);
            maxTreeHeight = TreeHeight(the_tree);
            panel1.Invalidate();
            textBox1.Text = "";
        }
    }
}
