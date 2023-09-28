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

namespace pong
{
    public partial class Form4 : Form
    {
        // Variables de Coordonnées
        public int directionpalette = 20;
        public int sensX = 5;
        public int sensY = 5;
        // Variables de scores
        int scoreplayer = 0;
        int scorecpu = 0;
        // Variables de barre d'éspace
        int clickbarreesp = 0;
        // Variables de taille de l'écran
        int xcentre;
        int ycentre;

        public void setsensX(int sensX) { this.sensX = sensX; }
        public void setsensY(int sensY) { this.sensY = sensY; }

        public void setdirectionpalette(int directionpalette) {  this.directionpalette = directionpalette; }

        public Form4()
        {
            InitializeComponent();
            xcentre = this.ClientSize.Width / 2;
            ycentre = this.ClientSize.Height / 2;
        }
      

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random newballspot = new Random();
            int newspot = newballspot.Next(10, this.ClientSize.Height - 10);
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            pictureBox4.Top += directionpalette;
            if (pictureBox4.Top<0 || pictureBox4.Top > 400)
            {
                directionpalette = -directionpalette; 
            }




            if (x > 625)
            {
                x = xcentre;
                y = newspot;
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);
                audio.Play();
                scoreplayer++;
                label2.Text= scoreplayer.ToString();
            }
            if (x < 0)
            {

                x = xcentre;
                y = newspot;
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);
                audio.Play();
                scorecpu++;
                label1.Text = scorecpu.ToString();
            }

            if (y > 440)
            {
                sensY = -sensY;

            }

            if (y < -1)
            {
                sensY = -sensY;

            }
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

            if (pictureBox1.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                sensX = -sensX;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.rebondgauche);
                audio.Play();
                int relativeY = (pictureBox1.Bottom + pictureBox1.Top) / 2 - (pictureBox3.Bottom + pictureBox3.Top) / 2;


                sensY = (relativeY > 0) ? 5 : -5;
            }
            pictureBox1.Location = new Point(x + sensX, y + sensY);


            if (scoreplayer >=3)
            {
                timer1.Stop();
                MessageBox.Show("Vous avez perdu la partie");
                Close();
            }
            if (scorecpu >= 3)
            {
                timer1.Stop();
                MessageBox.Show("Vous avez gagnez la partie");
                Close();
            }


        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int x = pictureBox2.Location.X;
                int y = pictureBox2.Location.Y;
                this.DoubleBuffered = true;

                pictureBox2.Location = new Point(x, y - 15);

                if (pictureBox2.Top < 0)
                {
                    pictureBox2.Location = new Point(x, y + 15);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                int x = pictureBox2.Location.X;
                int y = pictureBox2.Location.Y;

                pictureBox2.Location = new Point(x, y + 15);

                if (pictureBox2.Top > 400)
                {
                    pictureBox2.Location = new Point(x, y - 15);
                }
            }

            if (e.KeyCode == Keys.Space)
            {
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
    }
    }

