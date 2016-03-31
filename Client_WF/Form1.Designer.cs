namespace Client_WF
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txt_status = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btm_connect = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.panel_chooseTeam = new System.Windows.Forms.Panel();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_blue = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.backgroundWorkerForConnect = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_connect = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel_chooseTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.Location = new System.Drawing.Point(149, 410);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(219, 29);
            this.textBox1.TabIndex = 0;
            // 
            // txt_status
            // 
            this.txt_status.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_status.Location = new System.Drawing.Point(12, 292);
            this.txt_status.Multiline = true;
            this.txt_status.Name = "txt_status";
            this.txt_status.ReadOnly = true;
            this.txt_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_status.Size = new System.Drawing.Size(131, 147);
            this.txt_status.TabIndex = 2;
            this.txt_status.TabStop = false;
            this.txt_status.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_status_KeyDown);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.BackColor = System.Drawing.Color.Transparent;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.Location = new System.Drawing.Point(700, 366);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(72, 86);
            this.lbl_count.TabIndex = 4;
            this.lbl_count.Text = "0";
            this.lbl_count.Visible = false;
            // 
            // btm_connect
            // 
            this.btm_connect.BackColor = System.Drawing.Color.Tomato;
            this.btm_connect.ForeColor = System.Drawing.Color.White;
            this.btm_connect.Location = new System.Drawing.Point(461, 4);
            this.btm_connect.Name = "btm_connect";
            this.btm_connect.Size = new System.Drawing.Size(125, 33);
            this.btm_connect.TabIndex = 5;
            this.btm_connect.Text = "Connect to server";
            this.btm_connect.UseVisualStyleBackColor = false;
            this.btm_connect.Click += new System.EventHandler(this.btm_connect_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.BackColor = System.Drawing.Color.Transparent;
            this.lbl_status.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(230, 87);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(356, 45);
            this.lbl_status.TabIndex = 7;
            this.lbl_status.Text = "  ";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_chooseTeam
            // 
            this.panel_chooseTeam.BackColor = System.Drawing.Color.Lime;
            this.panel_chooseTeam.Controls.Add(this.btn_red);
            this.panel_chooseTeam.Controls.Add(this.btn_blue);
            this.panel_chooseTeam.Location = new System.Drawing.Point(-1, 181);
            this.panel_chooseTeam.Name = "panel_chooseTeam";
            this.panel_chooseTeam.Size = new System.Drawing.Size(786, 50);
            this.panel_chooseTeam.TabIndex = 15;
            this.panel_chooseTeam.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_chooseTeam_Paint);
            // 
            // btn_red
            // 
            this.btn_red.BackColor = System.Drawing.Color.LightCoral;
            this.btn_red.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_red.ForeColor = System.Drawing.Color.White;
            this.btn_red.Location = new System.Drawing.Point(413, 2);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(176, 45);
            this.btn_red.TabIndex = 8;
            this.btn_red.Text = "RED";
            this.btn_red.UseVisualStyleBackColor = false;
            this.btn_red.Click += new System.EventHandler(this.btn_red_Click);
            // 
            // btn_blue
            // 
            this.btn_blue.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_blue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_blue.ForeColor = System.Drawing.Color.White;
            this.btn_blue.Location = new System.Drawing.Point(231, 2);
            this.btn_blue.Name = "btn_blue";
            this.btn_blue.Size = new System.Drawing.Size(176, 45);
            this.btn_blue.TabIndex = 7;
            this.btn_blue.Text = "BLUE";
            this.btn_blue.UseVisualStyleBackColor = false;
            this.btn_blue.Click += new System.EventHandler(this.btn_blue_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(165, 4);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(290, 33);
            this.txt_ip.TabIndex = 17;
            // 
            // backgroundWorkerForConnect
            // 
            this.backgroundWorkerForConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Client_WF.Properties.Resources.still_6;
            this.pictureBox1.Location = new System.Drawing.Point(230, 303);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Client_WF.Properties.Resources.pole;
            this.pictureBox2.Location = new System.Drawing.Point(407, 379);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 73);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_connect
            // 
            this.lbl_connect.AutoSize = true;
            this.lbl_connect.BackColor = System.Drawing.Color.Transparent;
            this.lbl_connect.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_connect.ForeColor = System.Drawing.Color.Blue;
            this.lbl_connect.Location = new System.Drawing.Point(592, 13);
            this.lbl_connect.Name = "lbl_connect";
            this.lbl_connect.Size = new System.Drawing.Size(70, 17);
            this.lbl_connect.TabIndex = 19;
            this.lbl_connect.Text = "Connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "IP Address server";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(697, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 21;
            this.button1.Text = "New game";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(8, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(12, 12);
            this.button2.TabIndex = 22;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Client_WF.Properties.Resources.cheer;
            this.pictureBox3.Location = new System.Drawing.Point(-1, 135);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(786, 120);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client_WF.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_connect);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.panel_chooseTeam);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btm_connect);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.txt_status);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "JAW MA JAW JUM JUK CC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel_chooseTeam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txt_status;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Button btm_connect;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_chooseTeam;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_blue;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerForConnect;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

