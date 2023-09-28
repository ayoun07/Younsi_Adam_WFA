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
        // Variable qui recupere le choix du joueur seul ou a deux
        public bool Choix;
        
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Si le joueur a choisi de jouer seul il ouvre la fenetre ou l'ordinateur joue contre lui
            if (Choix == true)
            {
                Form4 ff = new Form4();
                ff.ShowDialog();
            }
            else
            // Sinon il ouvre la fenetre ou il joue a deux
            {
                Form1 fff = new Form1();
                fff.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (Choix == true)
            {
                Form4 ff = new Form4();
                // Changement de vitesse de la raquette dans le cas ou il clique sur medium et il joue seul
                ff.setdirectionpalette(25);
                // Changement de vitesse de la balle 
                ff.setsensX(7);
                ff.setsensY(7);
                ff.ShowDialog();
            }
            else
            {
                Form1 fff = new Form1();
                // Changement de vitesse de la balle
                fff.setsensX(7);
                fff.setsensY(7);
                fff.ShowDialog();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Boutton difficile
            if (Choix==true)
            {
                Form4 ff = new Form4();
                ff.setdirectionpalette(30);
                ff.setsensX(9);
                ff.setsensY(9);
                ff.ShowDialog();
            }
            else
            {
                Form1 fenetre = new Form1();
                fenetre.setsensX(9);
                fenetre.setsensY(9);

                fenetre.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
