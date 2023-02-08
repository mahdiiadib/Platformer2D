namespace platformer
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainGameTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.p_mover2 = new System.Windows.Forms.PictureBox();
            this.p_mover1 = new System.Windows.Forms.PictureBox();
            this.key2 = new System.Windows.Forms.PictureBox();
            this.key = new System.Windows.Forms.PictureBox();
            this.door = new System.Windows.Forms.PictureBox();
            this.hazard2 = new System.Windows.Forms.PictureBox();
            this.hazard1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BgPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mover2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mover1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.key2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hazard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hazard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(657, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "yvel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(657, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(657, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // MainGameTimer
            // 
            this.MainGameTimer.Enabled = true;
            this.MainGameTimer.Interval = 20;
            this.MainGameTimer.Tick += new System.EventHandler(this.MainGameTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "label6";
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::platformer.Properties.Resources.CharacterR;
            this.player.Location = new System.Drawing.Point(26, 495);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(32, 64);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 23;
            this.player.TabStop = false;
            this.player.Tag = "Player";
            // 
            // p_mover2
            // 
            this.p_mover2.BackColor = System.Drawing.Color.Transparent;
            this.p_mover2.BackgroundImage = global::platformer.Properties.Resources.Grass0043_1_350;
            this.p_mover2.Image = ((System.Drawing.Image)(resources.GetObject("p_mover2.Image")));
            this.p_mover2.Location = new System.Drawing.Point(565, 637);
            this.p_mover2.Name = "p_mover2";
            this.p_mover2.Size = new System.Drawing.Size(284, 29);
            this.p_mover2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_mover2.TabIndex = 21;
            this.p_mover2.TabStop = false;
            this.p_mover2.Tag = "Platform";
            // 
            // p_mover1
            // 
            this.p_mover1.BackColor = System.Drawing.Color.Transparent;
            this.p_mover1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_mover1.BackgroundImage")));
            this.p_mover1.Image = ((System.Drawing.Image)(resources.GetObject("p_mover1.Image")));
            this.p_mover1.Location = new System.Drawing.Point(565, 227);
            this.p_mover1.Name = "p_mover1";
            this.p_mover1.Size = new System.Drawing.Size(284, 29);
            this.p_mover1.TabIndex = 21;
            this.p_mover1.TabStop = false;
            this.p_mover1.Tag = "Platform";
            // 
            // key2
            // 
            this.key2.BackColor = System.Drawing.Color.Transparent;
            this.key2.Image = ((System.Drawing.Image)(resources.GetObject("key2.Image")));
            this.key2.Location = new System.Drawing.Point(1174, 519);
            this.key2.Name = "key2";
            this.key2.Size = new System.Drawing.Size(36, 29);
            this.key2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.key2.TabIndex = 15;
            this.key2.TabStop = false;
            this.key2.Tag = "Key";
            // 
            // key
            // 
            this.key.BackColor = System.Drawing.Color.Transparent;
            this.key.Image = ((System.Drawing.Image)(resources.GetObject("key.Image")));
            this.key.Location = new System.Drawing.Point(22, 103);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(36, 29);
            this.key.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.key.TabIndex = 15;
            this.key.TabStop = false;
            this.key.Tag = "Key";
            // 
            // door
            // 
            this.door.BackColor = System.Drawing.Color.Transparent;
            this.door.Image = global::platformer.Properties.Resources.door_closed;
            this.door.Location = new System.Drawing.Point(1174, 12);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(61, 103);
            this.door.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.door.TabIndex = 14;
            this.door.TabStop = false;
            this.door.Tag = "Door";
            // 
            // hazard2
            // 
            this.hazard2.BackColor = System.Drawing.Color.Transparent;
            this.hazard2.Image = ((System.Drawing.Image)(resources.GetObject("hazard2.Image")));
            this.hazard2.Location = new System.Drawing.Point(726, 30);
            this.hazard2.Name = "hazard2";
            this.hazard2.Size = new System.Drawing.Size(22, 112);
            this.hazard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hazard2.TabIndex = 5;
            this.hazard2.TabStop = false;
            this.hazard2.Tag = "Hazard";
            // 
            // hazard1
            // 
            this.hazard1.BackColor = System.Drawing.Color.Transparent;
            this.hazard1.Image = ((System.Drawing.Image)(resources.GetObject("hazard1.Image")));
            this.hazard1.Location = new System.Drawing.Point(687, 307);
            this.hazard1.Name = "hazard1";
            this.hazard1.Size = new System.Drawing.Size(27, 252);
            this.hazard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hazard1.TabIndex = 5;
            this.hazard1.TabStop = false;
            this.hazard1.Tag = "Hazard";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(1069, 113);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(166, 29);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "Platform";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(804, 360);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(166, 29);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "Platform";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(374, 471);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 29);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "Platform";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 662);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 29);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "Platform";
            // 
            // BgPicBox
            // 
            this.BgPicBox.Image = global::platformer.Properties.Resources.seamless_cartoon_desert_landscape_sandy_desert_with_mountains_background_1284_53568;
            this.BgPicBox.Location = new System.Drawing.Point(0, -4);
            this.BgPicBox.Name = "BgPicBox";
            this.BgPicBox.Size = new System.Drawing.Size(1236, 768);
            this.BgPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BgPicBox.TabIndex = 24;
            this.BgPicBox.TabStop = false;
            this.BgPicBox.Tag = "BG";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::platformer.Properties.Resources.seamless_cartoon_desert_landscape_sandy_desert_with_mountains_background_1284_53568;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1236, 761);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.p_mover2);
            this.Controls.Add(this.p_mover1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.key2);
            this.Controls.Add(this.key);
            this.Controls.Add(this.door);
            this.Controls.Add(this.hazard2);
            this.Controls.Add(this.hazard1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BgPicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyIsPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mover2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p_mover1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.key2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.key)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hazard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hazard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BgPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox hazard1;
        private System.Windows.Forms.PictureBox key;
        private System.Windows.Forms.PictureBox door;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer MainGameTimer;
        private System.Windows.Forms.PictureBox p_mover1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox hazard2;
        private System.Windows.Forms.PictureBox p_mover2;
        private System.Windows.Forms.PictureBox key2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox BgPicBox;
    }
}