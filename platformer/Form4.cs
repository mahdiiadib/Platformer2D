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
        int pxVel = 13, pyVel = 0, pjVel = 25;
        int meVel = 22, meVel2 = 20, meVel3 = 28;


        List<Bitmap> pR = new List<Bitmap>()
        {
            //Properties.Resources.monkeR0,
            Properties.Resources.monkeR1,
            Properties.Resources.monkeR2,
            Properties.Resources.monkeR3,
            Properties.Resources.monkeR4,
            Properties.Resources.monkeR5,
            Properties.Resources.monkeR6,
            Properties.Resources.monkeR7,
            Properties.Resources.monkeR8,
            Properties.Resources.monkeR9,
            Properties.Resources.monkeR10,
            Properties.Resources.monkeR11,
            Properties.Resources.monkeR12,
            Properties.Resources.monkeR13,
            Properties.Resources.monkeR14,
            Properties.Resources.monkeR15,
            Properties.Resources.monkeR16
        };
        List<Bitmap> pL = new List<Bitmap>()
        {
            //Properties.Resources.monkeL0,
            Properties.Resources.monkeL1,
            Properties.Resources.monkeL2,
            Properties.Resources.monkeL3,
            Properties.Resources.monkeL4,
            Properties.Resources.monkeL5,
            Properties.Resources.monkeL6,
            Properties.Resources.monkeL7,
            Properties.Resources.monkeL8,
            Properties.Resources.monkeL9,
            Properties.Resources.monkeL10,
            Properties.Resources.monkeL11,
            Properties.Resources.monkeL12,
            Properties.Resources.monkeL13,
            Properties.Resources.monkeL14,
            Properties.Resources.monkeL15,
            Properties.Resources.monkeL16
        };
        int R = 0, L = 0;
        string lastDir = "R";


        public Form4()
        {
            InitializeComponent();
            this.Text = "Level 3";

            foreach (Control x in Controls)
            {
                x.Parent = this;
            }
            label6.Text = $"Retries: {platformer.Form0.retries}";
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainGameTimer_Tick(object sender, EventArgs e)
        {
            if (platformer.Form0.wout1.PlaybackState == PlaybackState.Stopped)
            {
                //Form0.wstream1.CurrentTime = new TimeSpan(0);
                platformer.Form0.GetNextSong();
                platformer.Form0.wout1.Play();
            }
            else if (platformer.Form0.wout1.PlaybackState == PlaybackState.Paused) platformer.Form0.wout1.Resume();

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
            if (goRight)
            {
                if (player.Right < ClientSize.Width)
                {
                    player.Left += pxVel;
                    //player.Image = Properties.Resources.monkeR0;
                    player.Image = pR[R];
                    R++;
                    if (R == pR.Count) R = 0;
                }
                lastDir = "R";
            }
            else if (goLeft)
            {
                if (player.Left > 0)
                {
                    player.Left -= pxVel;
                    //player.Image = Properties.Resources.monkeL0;
                    player.Image = pL[L];
                    L++;
                    if (L == pL.Count) L = 0;
                }
                lastDir = "L";
            }
            else
            {
                if (lastDir == "R")
                {
                    player.Image = Properties.Resources.monkeR0;
                    //R = 0;
                }
                else if (lastDir == "L")
                {
                    player.Image = Properties.Resources.monkeL0;
                    //L = 0;
                }
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
            platformer.Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer("Lose.wav");
            sp.Play();
            MessageBox.Show("Died :(");

            platformer.Form0.retries++;
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        void NextLevel()
        {
            platformer.Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer(@"Star.wav");
            sp.Play();

            MessageBox.Show("Level 3 complete!");
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }
    }
}