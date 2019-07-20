namespace MyChat
{
    partial class FriendChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FriendChat));
            this.txtShow = new System.Windows.Forms.RichTextBox();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.picJitter = new System.Windows.Forms.PictureBox();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.btnList = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiClick = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.picFont = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picJitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFont)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShow
            // 
            this.txtShow.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShow.Location = new System.Drawing.Point(1, 45);
            this.txtShow.Name = "txtShow";
            this.txtShow.ReadOnly = true;
            this.txtShow.Size = new System.Drawing.Size(505, 221);
            this.txtShow.TabIndex = 0;
            this.txtShow.Text = "";
            this.txtShow.TextChanged += new System.EventHandler(this.txtShow_TextChanged);
            // 
            // txtSend
            // 
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSend.Location = new System.Drawing.Point(0, 303);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(506, 112);
            this.txtSend.TabIndex = 1;
            this.txtSend.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(407, 273);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(65, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(471, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(32, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // picJitter
            // 
            this.picJitter.BackColor = System.Drawing.Color.Transparent;
            this.picJitter.Image = ((System.Drawing.Image)(resources.GetObject("picJitter.Image")));
            this.picJitter.Location = new System.Drawing.Point(27, 273);
            this.picJitter.Name = "picJitter";
            this.picJitter.Size = new System.Drawing.Size(23, 24);
            this.picJitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picJitter.TabIndex = 5;
            this.picJitter.TabStop = false;
            this.picJitter.Click += new System.EventHandler(this.picJitter_Click);
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.Transparent;
            this.picColor.Image = ((System.Drawing.Image)(resources.GetObject("picColor.Image")));
            this.picColor.Location = new System.Drawing.Point(68, 272);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(27, 25);
            this.picColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picColor.TabIndex = 7;
            this.picColor.TabStop = false;
            this.picColor.Click += new System.EventHandler(this.picColor_Click);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Transparent;
            this.btnList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnList.BackgroundImage")));
            this.btnList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Location = new System.Drawing.Point(471, 273);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(24, 23);
            this.btnList.TabIndex = 8;
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClick,
            this.tsmiEnter});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // tsmiClick
            // 
            this.tsmiClick.Checked = true;
            this.tsmiClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiClick.Name = "tsmiClick";
            this.tsmiClick.Size = new System.Drawing.Size(142, 22);
            this.tsmiClick.Text = "点击发送";
            this.tsmiClick.Click += new System.EventHandler(this.tsmiClick_Click);
            // 
            // tsmiEnter
            // 
            this.tsmiEnter.Name = "tsmiEnter";
            this.tsmiEnter.Size = new System.Drawing.Size(142, 22);
            this.tsmiEnter.Text = "Enter键发送";
            this.tsmiEnter.Click += new System.EventHandler(this.tsmiEnter_Click);
            // 
            // picFont
            // 
            this.picFont.BackColor = System.Drawing.Color.Transparent;
            this.picFont.Image = ((System.Drawing.Image)(resources.GetObject("picFont.Image")));
            this.picFont.Location = new System.Drawing.Point(113, 272);
            this.picFont.Name = "picFont";
            this.picFont.Size = new System.Drawing.Size(27, 24);
            this.picFont.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFont.TabIndex = 9;
            this.picFont.TabStop = false;
            this.picFont.Click += new System.EventHandler(this.picFont_Click);
            // 
            // FriendChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 438);
            this.Controls.Add(this.picFont);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.picJitter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FriendChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FriendChat_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picJitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFont)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtShow;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox picJitter;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClick;
        private System.Windows.Forms.ToolStripMenuItem tsmiEnter;
        private System.Windows.Forms.PictureBox picFont;
    }
}