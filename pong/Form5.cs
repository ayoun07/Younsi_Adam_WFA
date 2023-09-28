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
using NAudio.Wave;

namespace pong
{
    public partial class Form5 : Form
    {
        private WaveOutEvent outputDevice = new WaveOutEvent();
        private AudioFileReader audioFile;


        public Form5()
        {
            InitializeComponent();
            audioFile = new AudioFileReader("C:\\Users\\user\\Source\\Repos\\ayoun07\\pong\\pong\\Resources\\hhhhhhhhhhhhhhhh.wav");

            // Associez l'AudioFileReader à l'outputDevice
            outputDevice.Init(audioFile);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int volumeValue = trackBar1.Value;

            // Calculez le volume en pourcentage (de 0 à 1) en fonction de la valeur du TrackBar
            float volume = (float)volumeValue / 100f;

            // Ajustez le volume audio
            outputDevice.Volume = volume;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
