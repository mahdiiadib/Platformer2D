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
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, landed, hit, hasKey;
        int pxVel = 15, pyVel = 0, pjVel = 25, meVel = 12, meVel2 = 10;

        bool up, dn;
        void moveV()
        {
            if(up && player.Top >= 0) player.Top -= 30;
            if(dn) player.Top += pxVel;
        }

        public Form1()
        {
            InitializeComponent();
            
            label1.Visible = label2.Visible = label3.Visible = label4.Visible = false;
            foreach(Control x in Controls)
            {
                x.Parent = this;
            }
            label6.Text = $"Retries: {Form0.retries}";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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

            hazard1.Left -= meVel;
            hazard2.Left -= meVel2;

            //moveV();
            label3.Text = $"{pyVel}";
            if (landed) label1.Text = "Landed"; else label1.Text = "Not Landed";
            if (hit) label2.Text = "Hit"; else label2.Text = "Not Hit";
            if (jumping) label4.Text = "Jumping"; else label4.Text = "Not Jumping";

            if (player.Top > ClientSize.Height || player.Bounds.IntersectsWith(hazard1.Bounds) || player.Bounds.IntersectsWith(hazard2.Bounds))
            {
                MainGameTimer.Stop();
                RestartLevel();
            }

            if (player.Bounds.IntersectsWith(key.Bounds) && key.Visible)
            {
                hasKey = true;
                key.Visible = false;
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && hasKey)
            {
                MainGameTimer.Stop();
                door.Image = Properties.Resources.door_open;
                NextLevel();
            }

            if (hazard1.Left <= pictureBox3.Left) meVel = -meVel;
            else if (hazard1.Right >= pictureBox3.Right) meVel = -meVel;
            
            if (hazard2.Left <= pictureBox2.Left) meVel2 = -meVel2;
            else if (hazard2.Right >= pictureBox2.Right) meVel2 = -meVel2;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.W) up= true;
            if (e.KeyCode == Keys.S) dn= true;
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
            if(!jumping)
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
            if (pyVel < 20) pyVel+=2;
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
            }

            if(player.Top <= 0) player.Top += 20;

            if(landed) jumping = false;
        }

        void RestartLevel()
        {
            Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer("Lose.wav");
            sp.Play();
            MessageBox.Show("Died :(");

            Form0.retries++;
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        void NextLevel()
        {
            Form0.wout1.Pause();
            SoundPlayer sp = new SoundPlayer(@"Star.wav");
            sp.Play();

            MessageBox.Show("Level 1 complete!");
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }
    }
}
