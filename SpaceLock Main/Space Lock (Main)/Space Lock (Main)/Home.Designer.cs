namespace Space_Lock__Main_
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.password_box = new System.Windows.Forms.TextBox();
            this.login_box = new System.Windows.Forms.Button();
            this.password_label = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.stop_button = new System.Windows.Forms.Button();
            this.lock_button = new System.Windows.Forms.Button();
            this.status_box = new System.Windows.Forms.ListBox();
            this.settings_button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lock_pc_button = new System.Windows.Forms.Button();
            this.lblShade = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.picLeftPanel = new System.Windows.Forms.PictureBox();
            this.picRightPanel_left = new System.Windows.Forms.PictureBox();
            this.picRightPaneltop_right = new System.Windows.Forms.PictureBox();
            this.picRightPanel_filler = new System.Windows.Forms.PictureBox();
            this.picRightPanel_bottom_left = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.rotation_timer = new System.Windows.Forms.Timer(this.components);
            this.btnViewLog = new System.Windows.Forms.Button();
            this.picWelcome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPaneltop_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_filler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_bottom_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcome)).BeginInit();
            this.SuspendLayout();
            // 
            // password_box
            // 
            this.password_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_box.Location = new System.Drawing.Point(297, 186);
            this.password_box.Name = "password_box";
            this.password_box.PasswordChar = '*';
            this.password_box.Size = new System.Drawing.Size(245, 47);
            this.password_box.TabIndex = 1;
            // 
            // login_box
            // 
            this.login_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.login_box.FlatAppearance.BorderSize = 0;
            this.login_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_box.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.login_box.ForeColor = System.Drawing.Color.White;
            this.login_box.Image = ((System.Drawing.Image)(resources.GetObject("login_box.Image")));
            this.login_box.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.login_box.Location = new System.Drawing.Point(557, 185);
            this.login_box.Name = "login_box";
            this.login_box.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.login_box.Size = new System.Drawing.Size(148, 48);
            this.login_box.TabIndex = 2;
            this.login_box.Text = "Login";
            this.login_box.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.login_box.UseVisualStyleBackColor = false;
            this.login_box.Click += new System.EventHandler(this.login_box_Click);
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.ForeColor = System.Drawing.Color.White;
            this.password_label.Location = new System.Drawing.Point(272, 393);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(53, 13);
            this.password_label.TabIndex = 3;
            this.password_label.Text = "Password";
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start_button.FlatAppearance.BorderSize = 0;
            this.start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_button.ForeColor = System.Drawing.Color.White;
            this.start_button.Image = ((System.Drawing.Image)(resources.GetObject("start_button.Image")));
            this.start_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.start_button.Location = new System.Drawing.Point(53, 146);
            this.start_button.Name = "start_button";
            this.start_button.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.start_button.Size = new System.Drawing.Size(148, 48);
            this.start_button.TabIndex = 4;
            this.start_button.Text = "Start";
            this.start_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // close_button
            // 
            this.close_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.close_button.FlatAppearance.BorderSize = 0;
            this.close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.close_button.ForeColor = System.Drawing.Color.White;
            this.close_button.Image = ((System.Drawing.Image)(resources.GetObject("close_button.Image")));
            this.close_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_button.Location = new System.Drawing.Point(53, 354);
            this.close_button.Name = "close_button";
            this.close_button.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.close_button.Size = new System.Drawing.Size(148, 48);
            this.close_button.TabIndex = 5;
            this.close_button.Text = "Exit";
            this.close_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.close_button.UseVisualStyleBackColor = false;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stop_button.FlatAppearance.BorderSize = 0;
            this.stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stop_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.stop_button.ForeColor = System.Drawing.Color.White;
            this.stop_button.Image = ((System.Drawing.Image)(resources.GetObject("stop_button.Image")));
            this.stop_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stop_button.Location = new System.Drawing.Point(53, 198);
            this.stop_button.Name = "stop_button";
            this.stop_button.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.stop_button.Size = new System.Drawing.Size(148, 48);
            this.stop_button.TabIndex = 14;
            this.stop_button.Text = "Stop";
            this.stop_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // lock_button
            // 
            this.lock_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lock_button.FlatAppearance.BorderSize = 0;
            this.lock_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lock_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.lock_button.ForeColor = System.Drawing.Color.White;
            this.lock_button.Image = ((System.Drawing.Image)(resources.GetObject("lock_button.Image")));
            this.lock_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lock_button.Location = new System.Drawing.Point(53, 250);
            this.lock_button.Name = "lock_button";
            this.lock_button.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lock_button.Size = new System.Drawing.Size(148, 48);
            this.lock_button.TabIndex = 15;
            this.lock_button.Text = "Logout";
            this.lock_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lock_button.UseVisualStyleBackColor = false;
            this.lock_button.Click += new System.EventHandler(this.lock_button_Click);
            // 
            // status_box
            // 
            this.status_box.BackColor = System.Drawing.Color.Cornsilk;
            this.status_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.status_box.FormattingEnabled = true;
            this.status_box.Location = new System.Drawing.Point(181, 12);
            this.status_box.Name = "status_box";
            this.status_box.Size = new System.Drawing.Size(570, 78);
            this.status_box.TabIndex = 16;
            // 
            // settings_button
            // 
            this.settings_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.settings_button.FlatAppearance.BorderSize = 0;
            this.settings_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.settings_button.ForeColor = System.Drawing.Color.White;
            this.settings_button.Image = ((System.Drawing.Image)(resources.GetObject("settings_button.Image")));
            this.settings_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings_button.Location = new System.Drawing.Point(536, 250);
            this.settings_button.Name = "settings_button";
            this.settings_button.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.settings_button.Size = new System.Drawing.Size(169, 48);
            this.settings_button.TabIndex = 17;
            this.settings_button.Text = "Settings";
            this.settings_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.settings_button.UseVisualStyleBackColor = false;
            this.settings_button.Click += new System.EventHandler(this.settings_button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lock_pc_button
            // 
            this.lock_pc_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lock_pc_button.FlatAppearance.BorderSize = 0;
            this.lock_pc_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lock_pc_button.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.lock_pc_button.ForeColor = System.Drawing.Color.White;
            this.lock_pc_button.Image = ((System.Drawing.Image)(resources.GetObject("lock_pc_button.Image")));
            this.lock_pc_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lock_pc_button.Location = new System.Drawing.Point(53, 302);
            this.lock_pc_button.Name = "lock_pc_button";
            this.lock_pc_button.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lock_pc_button.Size = new System.Drawing.Size(148, 48);
            this.lock_pc_button.TabIndex = 18;
            this.lock_pc_button.Text = "Lock PC";
            this.lock_pc_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lock_pc_button.UseVisualStyleBackColor = false;
            this.lock_pc_button.Click += new System.EventHandler(this.lock_pc_button_Click);
            // 
            // lblShade
            // 
            this.lblShade.BackColor = System.Drawing.Color.White;
            this.lblShade.ForeColor = System.Drawing.Color.Black;
            this.lblShade.Location = new System.Drawing.Point(-12, -12);
            this.lblShade.Name = "lblShade";
            this.lblShade.Size = new System.Drawing.Size(785, 115);
            this.lblShade.TabIndex = 19;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(5, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(164, 94);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 20;
            this.picLogo.TabStop = false;
            // 
            // picLeftPanel
            // 
            this.picLeftPanel.BackColor = System.Drawing.Color.Transparent;
            this.picLeftPanel.Image = ((System.Drawing.Image)(resources.GetObject("picLeftPanel.Image")));
            this.picLeftPanel.Location = new System.Drawing.Point(21, 124);
            this.picLeftPanel.Name = "picLeftPanel";
            this.picLeftPanel.Size = new System.Drawing.Size(215, 309);
            this.picLeftPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLeftPanel.TabIndex = 21;
            this.picLeftPanel.TabStop = false;
            // 
            // picRightPanel_left
            // 
            this.picRightPanel_left.BackColor = System.Drawing.Color.Transparent;
            this.picRightPanel_left.Image = ((System.Drawing.Image)(resources.GetObject("picRightPanel_left.Image")));
            this.picRightPanel_left.Location = new System.Drawing.Point(264, 124);
            this.picRightPanel_left.Name = "picRightPanel_left";
            this.picRightPanel_left.Size = new System.Drawing.Size(291, 24);
            this.picRightPanel_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRightPanel_left.TabIndex = 22;
            this.picRightPanel_left.TabStop = false;
            // 
            // picRightPaneltop_right
            // 
            this.picRightPaneltop_right.BackColor = System.Drawing.Color.Transparent;
            this.picRightPaneltop_right.Image = ((System.Drawing.Image)(resources.GetObject("picRightPaneltop_right.Image")));
            this.picRightPaneltop_right.Location = new System.Drawing.Point(451, 124);
            this.picRightPaneltop_right.Name = "picRightPaneltop_right";
            this.picRightPaneltop_right.Size = new System.Drawing.Size(291, 24);
            this.picRightPaneltop_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRightPaneltop_right.TabIndex = 23;
            this.picRightPaneltop_right.TabStop = false;
            // 
            // picRightPanel_filler
            // 
            this.picRightPanel_filler.Location = new System.Drawing.Point(263, 146);
            this.picRightPanel_filler.Name = "picRightPanel_filler";
            this.picRightPanel_filler.Size = new System.Drawing.Size(479, 269);
            this.picRightPanel_filler.TabIndex = 24;
            this.picRightPanel_filler.TabStop = false;
            // 
            // picRightPanel_bottom_left
            // 
            this.picRightPanel_bottom_left.BackColor = System.Drawing.Color.Transparent;
            this.picRightPanel_bottom_left.Image = ((System.Drawing.Image)(resources.GetObject("picRightPanel_bottom_left.Image")));
            this.picRightPanel_bottom_left.Location = new System.Drawing.Point(263, 409);
            this.picRightPanel_bottom_left.Name = "picRightPanel_bottom_left";
            this.picRightPanel_bottom_left.Size = new System.Drawing.Size(206, 24);
            this.picRightPanel_bottom_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picRightPanel_bottom_left.TabIndex = 25;
            this.picRightPanel_bottom_left.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(435, 409);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(536, 409);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(206, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Browse.FlatAppearance.BorderSize = 0;
            this.btn_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Browse.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Browse.ForeColor = System.Drawing.Color.White;
            this.btn_Browse.Image = ((System.Drawing.Image)(resources.GetObject("btn_Browse.Image")));
            this.btn_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Browse.Location = new System.Drawing.Point(536, 184);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btn_Browse.Size = new System.Drawing.Size(169, 48);
            this.btn_Browse.TabIndex = 28;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // rotation_timer
            // 
            this.rotation_timer.Interval = 20000;
            // 
            // btnViewLog
            // 
            this.btnViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewLog.FlatAppearance.BorderSize = 0;
            this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLog.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewLog.ForeColor = System.Drawing.Color.White;
            this.btnViewLog.Image = ((System.Drawing.Image)(resources.GetObject("btnViewLog.Image")));
            this.btnViewLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewLog.Location = new System.Drawing.Point(536, 313);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnViewLog.Size = new System.Drawing.Size(169, 48);
            this.btnViewLog.TabIndex = 29;
            this.btnViewLog.Text = "View Logs";
            this.btnViewLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // picWelcome
            // 
            this.picWelcome.Image = ((System.Drawing.Image)(resources.GetObject("picWelcome.Image")));
            this.picWelcome.Location = new System.Drawing.Point(287, 168);
            this.picWelcome.Name = "picWelcome";
            this.picWelcome.Size = new System.Drawing.Size(230, 211);
            this.picWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWelcome.TabIndex = 30;
            this.picWelcome.TabStop = false;
            this.picWelcome.Visible = false;
            // 
            // Home
            // 
            this.AcceptButton = this.login_box;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(763, 464);
            this.ControlBox = false;
            this.Controls.Add(this.picWelcome);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picRightPanel_bottom_left);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lock_pc_button);
            this.Controls.Add(this.settings_button);
            this.Controls.Add(this.status_box);
            this.Controls.Add(this.lock_button);
            this.Controls.Add(this.stop_button);
            this.Controls.Add(this.close_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.login_box);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.lblShade);
            this.Controls.Add(this.picLeftPanel);
            this.Controls.Add(this.picRightPanel_left);
            this.Controls.Add(this.picRightPaneltop_right);
            this.Controls.Add(this.picRightPanel_filler);
            this.Name = "Home";
            this.Text = "SpaceLock Alpha";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeftPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPaneltop_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_filler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRightPanel_bottom_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWelcome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Button login_box;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.Button lock_button;
        private System.Windows.Forms.ListBox status_box;
        private System.Windows.Forms.Button settings_button;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button lock_pc_button;
        private System.Windows.Forms.Label lblShade;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox picLeftPanel;
        private System.Windows.Forms.PictureBox picRightPanel_left;
        private System.Windows.Forms.PictureBox picRightPaneltop_right;
        private System.Windows.Forms.PictureBox picRightPanel_filler;
        private System.Windows.Forms.PictureBox picRightPanel_bottom_left;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Timer rotation_timer;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.PictureBox picWelcome;
    }
}