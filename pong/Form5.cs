using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;


namespace pong
{
    public partial class Form5 : Form
    {
        


        public Form5()
        {
            InitializeComponent();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Pour revenir en arriere
            Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Pour gérer et controler le son quand on scroll la barre 
            Form2.wplayer.controls.play();
            btn_sound.Image = Properties.Resources.sound_on;
            Form2.wplayer.settings.volume = trackBar1.Value;


            //Une fois on scroll jusqu'à 0 la picturebox affiche une image de sound off 
            if (trackBar1.Value == 0)
            {
                btn_sound.Image = Properties.Resources.sound_off;
            }
        }
    }
}
