using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace pong
{
    public partial class Form1 : Form
    {
        // Variables de Coordonnées
        public int sensX = 5;
        public int sensY = 5;
        // Variables de taille d'écran
        int xcentre;
        int ycentre;
        // Variables de scores
        int scoreplayer = 0;
        int scorecpu = 0;
        bool joueur1Gagne = false;
        bool joueur2Gagne = false;
        // Variables de barre d'espace
        int clickbarreesp = 0;

        // Méthode pour modifier les coordonées au meme temp la vitesse de la balle
        public void setsensX (int sensX) {this.sensX=sensX ; }
        public void setsensY (int sensY) { this.sensY= sensY; }    

        public Form1()
        {
            InitializeComponent();
            xcentre = this.ClientSize.Width / 2;
            ycentre = this.ClientSize.Height / 2;
            this.Paint += new PaintEventHandler(Form1_Paint);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Crée de nouvelles coordonées aléatoire pour la balle 
            Random newballspot = new Random();
            int newspot = newballspot.Next(10 , this.ClientSize.Height - 10);

            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
           


            // Quand la balle touche le cote gauche de l'écran
            if (x>625)
            {
                x = xcentre;
                y = newspot;// La balle apparrait dans une place aléatoire au centre en direction du perdant
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);// Rajout d'un audio quand la balle touche l'écran
                audio.Play();
                scoreplayer++;
                cpuscore.Text = scoreplayer.ToString();
            }

            // Quand la balle touche le cote droit de l'écran
            if (x<0 )
            {
                
                x = xcentre; 
                y = newspot;
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);
                audio.Play();
                scorecpu++;
                playerscore.Text = scorecpu.ToString();
            }

            // Quand la balle touche le cote haut de l'ecran
            if (y>440)
            {
                sensY = -sensY;// Changement de direction
                  
            }

            if (y < -1)
            {
                sensY = -sensY;
                
            }

            // Quand la balle touche la raquette droite elle change de direction en rebondissant
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.rebonddroit);
                audio.Play();

                // Calculez la position verticale relative de la balle par rapport à la raquette
                int relativeY = (pictureBox1.Bottom + pictureBox1.Top) / 2 - (pictureBox2.Bottom + pictureBox2.Top) / 2;

                // Modifiez la direction Y en fonction de la position relative sur la raquette
                sensY = (relativeY > 0) ? 5 : -5;

            }

            // Quand la balle touche la raquette gauche elle change de direction en rebondissant
            if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.rebondgauche);
                audio.Play();

                int relativeY = (pictureBox1.Bottom + pictureBox1.Top) / 2 - (pictureBox3.Bottom + pictureBox3.Top) / 2;

                
                sensY = (relativeY > 0) ? 5 : -5;
            }
            pictureBox1.Location = new Point(x + sensX, y + sensY);
            
            // Au bout de 10 points le jeu s'arrete en désignant un gagnant
            if (scoreplayer >= 10)
            {
                joueur1Gagne = true;
                timer1.Stop();
                Refresh();
            }
            if (scorecpu >= 10)
            {
                joueur2Gagne = true;
                timer1.Stop();
                Refresh();
            }

         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // Quand le joueur clique sur la touche haut avec les fleche 
            if (e.KeyCode == Keys.Up)
            {
                int x = pictureBox2.Location.X;
                int y = pictureBox2.Location.Y;
                this.DoubleBuffered = true;

                pictureBox2.Location = new Point(x, y - 15);// La raquette avance de 15 pixels

                // Eviter de dépasser la l'extrémité haute de l'écran
                if (pictureBox2.Top < 0)
                {
                    pictureBox2.Location = new Point(x, y + 15);
                }
            }

            // Quand le joueur presse la touche bas
            if (e.KeyCode == Keys.Down)
            {
                int x = pictureBox2.Location.X;
                int y = pictureBox2.Location.Y;

                pictureBox2.Location = new Point(x, y + 15);

                // Eviter de dépasser l'éxtrémitée bas de l'écran
                if (pictureBox2.Top > 400)
                {
                    pictureBox2.Location = new Point(x, y - 15);
                }
            }

            // Les touches utiliser pour un deuxieme joueur
            if (e.KeyCode == Keys.A)
            {
                int x = pictureBox3.Location.X;
                int y = pictureBox3.Location.Y;

                pictureBox3.Location = new Point(x, y - 15);

                if (pictureBox3.Top <= 0)
                {
                    pictureBox3.Location = new Point(x, y + 15);
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                int x = pictureBox3.Location.X;
                int y = pictureBox3.Location.Y;

                pictureBox3.Location = new Point(x, y + 15);

                if (pictureBox3.Top >= 400)
                {
                    pictureBox3.Location = new Point(x, y - 15);
                }
            }

            // Si un des joueurs presse la barre d'espace le jeu se met en pause
            if (e.KeyCode == Keys.Space)
            {

                // Si le joueur presse une fois la barre d'éspace cela met pause sinon cela reprend le jeu
                if (clickbarreesp % 2 == 0)
                {
                    timer1.Stop();
                }
                else
                {
                    timer1.Start(); 
                }
            }
            clickbarreesp++;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (joueur1Gagne)
            {
                // Affichez le message de victoire pour le joueur 1
                e.Graphics.DrawString("PLAYER 1 WIN !", new Font("Algerian", 20), Brushes.Orange, new PointF(50, 200));
            }
            else if (joueur2Gagne)
            {
                // Affichez le message de victoire pour le joueur 2
                e.Graphics.DrawString("PLAYER 2 WIN !", new Font("Algerian", 20), Brushes.Red, new PointF(400, 200));
            }
        }


      
    }
}
