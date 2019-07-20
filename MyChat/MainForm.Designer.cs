namespace MyChat
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddFriend = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFriend = new System.Windows.Forms.TabPage();
            this.tabPageGroup = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsSystemBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSmall = new System.Windows.Forms.Button();
            this.picB = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.cmsSystemBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // AddFriend
            // 
            this.AddFriend.BackColor = System.Drawing.Color.Transparent;
            this.AddFriend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddFriend.BackgroundImage")));
            this.AddFriend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddFriend.FlatAppearance.BorderSize = 0;
            this.AddFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFriend.Location = new System.Drawing.Point(102, 465);
            this.AddFriend.Name = "AddFriend";
            this.AddFriend.Size = new System.Drawing.Size(38, 35);
            this.AddFriend.TabIndex = 1;
            this.toolTip1.SetToolTip(this.AddFriend, "试试刷出新好友");
            this.AddFriend.UseVisualStyleBackColor = false;
            this.AddFriend.Click += new System.EventHandler(this.AddFriend_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFriend);
            this.tabControl1.Controls.Add(this.tabPageGroup);
            this.tabControl1.Location = new System.Drawing.Point(0, 110);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 338);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageFriend
            // 
            this.tabPageFriend.AutoScroll = true;
            this.tabPageFriend.Location = new System.Drawing.Point(4, 22);
            this.tabPageFriend.Name = "tabPageFriend";
            this.tabPageFriend.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFriend.Size = new System.Drawing.Size(235, 312);
            this.tabPageFriend.TabIndex = 0;
            this.tabPageFriend.Text = "我的好友";
            this.tabPageFriend.UseVisualStyleBackColor = true;
            // 
            // tabPageGroup
            // 
            this.tabPageGroup.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroup.Name = "tabPageGroup";
            this.tabPageGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroup.Size = new System.Drawing.Size(235, 312);
            this.tabPageGroup.TabIndex = 1;
            this.tabPageGroup.Text = "我的群组";
            this.tabPageGroup.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(209, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmsSystemBar;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MyChat";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmsSystemBar
            // 
            this.cmsSystemBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmExit});
            this.cmsSystemBar.Name = "cmsSystemBar";
            this.cmsSystemBar.Size = new System.Drawing.Size(137, 48);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(136, 22);
            this.tsmOpen.Text = "打开主面板";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(136, 22);
            this.tsmExit.Text = "退出";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // btnSmall
            // 
            this.btnSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmall.Location = new System.Drawing.Point(174, 2);
            this.btnSmall.Name = "btnSmall";
            this.btnSmall.Size = new System.Drawing.Size(33, 23);
            this.btnSmall.TabIndex = 4;
            this.btnSmall.Text = "-";
            this.btnSmall.UseVisualStyleBackColor = true;
            this.btnSmall.Click += new System.EventHandler(this.btnSmall_Click);
            // 
            // picB
            // 
            this.picB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picB.Location = new System.Drawing.Point(12, 27);
            this.picB.Name = "picB";
            this.picB.Size = new System.Drawing.Size(60, 60);
            this.picB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picB.TabIndex = 5;
            this.picB.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(93, 37);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 12);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "lblName";
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.BackColor = System.Drawing.Color.Transparent;
            this.lblSignature.Location = new System.Drawing.Point(93, 74);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(77, 12);
            this.lblSignature.TabIndex = 7;
            this.lblSignature.Text = "lblSignature";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(191, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(140, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(244, 512);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblSignature);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picB);
            this.Controls.Add(this.btnSmall);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.AddFriend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.tabControl1.ResumeLayout(false);
            this.cmsSystemBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddFriend;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFriend;
        private System.Windows.Forms.TabPage tabPageGroup;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSmall;
        private System.Windows.Forms.PictureBox picB;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cmsSystemBar;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}