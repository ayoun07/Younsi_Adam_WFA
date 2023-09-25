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
        int sensX = 15;
        int sensY = 15;
        int scoreplayer = 0;
        int scorecpu = 0;
        int clickbarreesp = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random newballspot = new Random();
            int newspot = newballspot.Next(100 , ClientSize.Height - 100);

            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;

            if (x>615 )
            {
                sensX = -15;
                pictureBox1.Top = newspot;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);
                audio.Play();
                scoreplayer++;
                playerscore.Text = scoreplayer.ToString();
            }
            if (x<=0 )
            {
                sensX = 15;
         
                pictureBox1.Top = newspot;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.lose);
                audio.Play();
                scorecpu++;
                cpuscore.Text = scorecpu.ToString();
            }

            if (y>440)
            {
                sensY = -15;
                pictureBox1.Top = newspot;  
            }

            if (y <= 0)
            {
                sensY = 15;
                pictureBox1.Top = newspot;
            }
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                sensX = -15;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.rebonddroit);
                audio.Play();
                
                
            }

            if (pictureBox1.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                sensX = 15;
                SoundPlayer audio = new SoundPlayer(pong.Properties.Resources.rebondgauche);
                audio.Play();
            }

            pictureBox1.Location = new Point(x + sensX, y + sensY);
            

            if (scoreplayer >=10)
            {
                timer1.Stop();
            }
            if (scorecpu >= 10)
            {
                timer1.Stop();
            }

         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                int x = pictureBox2.Location.X;
                int y = pictureBox2.Location.Y;

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

                if (pictureBox2.Top > 370)
                {
                    pictureBox2.Location = new Point(x, y - 15);
                }
            }

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

                if (pictureBox3.Top >= 370)
                {
                    pictureBox3.Location = new Point(x, y - 15);
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
