using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformer
{
    public partial class Form4 : Form
    {
        bool goLeft, goRight, jumping, landed, hit;
        int keyCnt = 0;
        int pxVel = 15, pyVel = 0, pjVel = 25;
        int meVel = 22, meVel2 = 20, meVel3 = 28;

        public Form4()
        {
            InitializeComponent();

            foreach (Control x in Controls)
            {
                x.Parent = this;
            }
            label6.Text = $"Retries: {Form0.retries}";
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainGameTimer_Tick(object sender, EventArgs e)
        {
            if (Form0.wout1.PlaybackState == PlaybackState.Stopped)
            {
                //Form0.wstream1.CurrentTime = new TimeSpan(0);
                Form0.GetNextSong();
                Form0.wout1.Play();
            }
            else if (Form0.wout1.PlaybackState == PlaybackState.Paused) Form0.wout1.Resume();

            MovePlayerHorizontal();
            MovePlayerVertical();

            hazard1.Top += meVel;
            hazard2.Top += meVel2;
            hazard3.Top += meVel3;


            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Tag.ToString() == "Key" && player.Bounds.IntersectsWith(x.Bounds) && x.Visible)
                    {
                        keyCnt++;
                        x.Visible = false;
                    }
                    if (x.Tag.ToString() == "Hazard" && player.Bounds.IntersectsWith(x.Bounds))
                    {
                        MainGameTimer.Stop();
                        RestartLevel();
                    }
                }
            }

            if (player.Top > ClientSize.Height)
            {
                MainGameTimer.Stop();
                RestartLevel();
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && keyCnt == 2)
            {
                MainGameTimer.Stop();
                door.Image = Properties.Resources.door_open;
                NextLevel();
            }

            if (hazard1.Top <= 5) meVel = -meVel;
            else if (hazard1.Bottom >= ClientSize.Height) meVel = -meVel;
            
            if (hazard2.Top <= 5) meVel2 = -meVel2;
            else if (hazard2.Bottom >= ClientSize.Height) meVel2 = -meVel2;
            
            if (hazard3.Top <= 5) meVel3 = -meVel3;
            else if (hazard3.Bottom >= ClientSize.Height) meVel3 = -meVel3;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) goLeft = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) goLeft = false;
            //if (e.KeyCode == Keys.Space) jumping = false;
        }

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                //MessageBox.Show($"Pressed {(int)e.KeyChar}");
                Jump();
            }
        }


        void Jump()
        {
            if (!jumping)
            {
                jumping = true;
                pyVel = -pjVel;
                player.Top += pyVel;

                SoundPlayer sp = new SoundPlayer(@"Jump.wav");
                sp.Play();
            }

            //MessageBox.Show($"{PlayerInside()}");
        }

        void MovePlayerHorizontal()
        {
            if (goRight && player.Right < ClientSize.Width)
            {
                player.Left += pxVel;
                player.Image = Properties.Resources.CharacterR;
            }
            if (goLeft && player.Left > 0)
            {
                player.Left -= pxVel;
                player.Image = Properties.Resources.characterL;
            }
        }

        void MovePlayerVertical()
        {
            if (pyVel < 20) pyVel += 2;
            if (!landed) player.Top += pyVel;

            foreach (Control x in Controls)
            {
                if (x is PictureBox && x.Tag.ToString() == "Platform")
                {
                    if (Math.Abs(player.Bottom - x.Top) <= 5 && (player.Right >= x.Left && player.Left <= x.Right))
                    {
                        pyVel = 0;
                        player.Top = x.Top - player.Width - 30;
                        landed = true;
                        break;
                    }
                    else if (Math.Abs(player.Top - x.Bottom) <= 10 && (player.Right >= x.Left && player.Left <= x.Right))
                    {
                        hit = true;
                        player.Top += 15;
                        //MessageBox.Show("Hit Head");
                        break;
                    }
                    else if (!hit && player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Top = x.Top - player.Width - 30;
                        if (player.Bounds.IntersectsWith(x.Bounds)) landed = true;
                        break;
                    }
                    else
                    {
                        landed = false;
                        hit = false;
                    }
                }

                if (x is PictureBox && x.Tag.ToString() == "Support" && player.Bounds.IntersectsWith(x.Bounds))
                {
                    if (x.Left - player.Right <= 5)
                    {
                        player.Left -= 25; ;
                        break;
                    }

                    if (player.Left - x.Right <= 5)
                    {
                        player.Left = x.Right + 25;
                        break;
                    }
                }
            }

            if (player.Top <= 0) player.Top += 20;

            if (landed) jumping = false;
        }

        void RestartLevel()
        {
            Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer("Lose.wav");
            sp.Play();
            MessageBox.Show("Died :(");

            Form0.retries++;
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        void NextLevel()
        {
            Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer(@"Star.wav");
            sp.Play();

            MessageBox.Show("Level 3 complete!");
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }
    }
}