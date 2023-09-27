using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pong
{
    public partial class Form3 : Form
    {

        
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fenetre = new Form1();
            fenetre.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.setsensX(10);
            f.setsensY(10);
            f.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fenetre = new Form1();
            fenetre.setsensX(15);
            fenetre.setsensY(15);
            
            fenetre.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
