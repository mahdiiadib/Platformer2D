using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformer
{
    public partial class Form0 : Form
    {
        public static int retries { get; set; }
        public static WaveStream wstream1;
        public static WaveOut wout1;

        //public static string bgSong = "My_Best_Friend.wav";
        //public static string bgSong = "Korobeiniki.wav";

        //public static string[] bgSongs = new string[]{ "Lose.wav", "Star.wav" };
        public static string[] bgSongs = new string[]{ "My_Best_Friend.wav", "Korobeiniki.wav" };
        public static int curSong;

        public Form0()
        {
            InitializeComponent();
            this.Text = "Menu";
            
            retries = 0;

            curSong = new Random().Next(0, 11);
            //MessageBox.Show($"{curSong}");
            curSong = curSong % 2;
            //MessageBox.Show($"{curSong}\n{bgSongs[curSong]}");

            wstream1 = new WaveFileReader(bgSongs[curSong]);
            wout1 = new WaveOut();
            wout1.Init(wstream1);
            //wout1.Play();
            wout1.Volume = 0.5f;
        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public static void GetNextSong()
        {
            curSong = (curSong + 1) % bgSongs.Length;
            wstream1 = new WaveFileReader(bgSongs[curSong]);
            wout1 = new WaveOut();
            wout1.Init(wstream1);
            wout1.Volume = 0.5f;
        }
    }
}
