using NAudio.Wave;
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

namespace platformer
{
    public partial class Form3 : Form
    {
        bool goLeft, goRight, jumping, landed, hit;
        int keyCnt = 0;
        int pxVel = 14, pyVel = 0, pjVel = 25;
        int mpVel = 10, mpVel2 = 10, meVel = 8;


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
        char lastDir = 'R';


        bool up, dn;
        void moveV()
        {
            if (up && player.Top >= 0) player.Top -= 30;
            if (dn) player.Top += pxVel;
        }


        public Form3()
        {
            InitializeComponent();
            this.Text = "Level 4";

            label1.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = false;
            foreach (Control x in Controls)
            {
                x.Parent = this;
            }
            label6.Text = $"Retries: {platformer.Form0.retries}";
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
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

            p_mover1.Left -= mpVel;
            p_mover2.Left -= mpVel2;
            hazard1.Top -= meVel;
            hazard2.Left -= meVel;

            //moveV();
            label3.Text = $"{pyVel}";
            if (landed) label1.Text = "Landed"; else label1.Text = "Not Landed";
            if (hit) label2.Text = "Hit"; else label2.Text = "Not Hit";
            if (jumping) label4.Text = "Jumping"; else label4.Text = "Not Jumping";

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

            foreach(Control x in Controls)
            {
                if(x is PictureBox)
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

            if (p_mover1.Left <= 5) mpVel = -mpVel;
            else if (p_mover1.Right + 5 >= ClientSize.Width) mpVel = -mpVel;

            if (p_mover2.Left <= 440) mpVel2 = -mpVel2;
            else if (p_mover2.Right + 5 >= ClientSize.Width) mpVel2 = -mpVel2;

            if (hazard1.Top <= 5) meVel = -meVel;
            else if (hazard1.Bottom + 5 >= ClientSize.Height) meVel = -meVel;

            if (hazard2.Left <= 5) meVel = -meVel;
            else if (hazard2.Right >= 1040) meVel = -meVel;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.W) up = true;
            if (e.KeyCode == Keys.S) dn = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.W) up = false;
            if (e.KeyCode == Keys.S) dn = false;
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
                lastDir = 'R';
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
                lastDir = 'L';
            }
            else
            {
                if (lastDir == 'R')
                {
                    player.Image = Properties.Resources.monkeR0;
                    R = 0;
                }
                else if (lastDir == 'L')
                {
                    player.Image = Properties.Resources.monkeL0;
                    L = 0;
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

                        if (x.Name.ToString() == "p_mover1")
                        {
                            player.Left -= mpVel;
                            label5.Text = x.Name;
                        }
                        if (x.Name.ToString() == "p_mover2")
                        {
                            player.Left -= mpVel2;
                            label5.Text = x.Name;
                        }
                        else label5.Text = "No Name";

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
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }

        void NextLevel()
        {
            platformer.Form0.wout1.Stop();
            platformer.Form0.wout1.Volume = 1;
            SoundPlayer sp = new SoundPlayer(@"TaDa.wav");
            sp.Play();

            MessageBox.Show($"You have completed the game!\nNumber of tries: {platformer.Form0.retries}");
            Form0 form0 = new Form0();
            form0.Show();
            Hide();
        }
    }
}
