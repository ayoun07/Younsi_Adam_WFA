using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;


namespace pong
{
    public partial class Form2 : Form
    {

        // Déclaration de variables
        
        public Boolean choixun;
        // Déclaration de variables pour controler la musique du fond en utilisant la classe System.media.soundplayer
        public static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();



        public Form2()
        {
            InitializeComponent();
            // Instance de la classe 
            wplayer.URL = (@"C:\Users\user\Source\Repos\ayoun07\pong\pong\Resources\hhhhhhhhhhhhhhhh.wav");
            wplayer.controls.play();
            // Cacher le axWindowsplayer1 une fois la fenetre ouverte 
            axWindowsMediaPlayer1.Hide();
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            // Permet de savoir si le joueur joue seul ou a deux 
            // Le joueur a choisi de jouer seul
            choixun = true;
           ;
            // Crée une nouvelle fenetre
            Form3 fenetre = new Form3();
            // Recupere le choix du joueur
            fenetre.Choix = choixun;
            // Affiche la fenetre
            fenetre.ShowDialog();
        }


            private void button2_Click(object sender, EventArgs e)
        {
            // Le joueur a choisi de jouer a deux
            choixun=false;
            Form3 fenetre = new Form3();
            fenetre.Choix = choixun;
            fenetre.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Fermeture de la fenetre
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Ouvrir La fenetre pour gerer la musique 
            Form5 fenetre = new Form5();
            fenetre.ShowDialog();
        }
    }
}
