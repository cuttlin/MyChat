using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace MyChat
{
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlNode xn = doc.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
            txtName.Text = xn["name"].InnerText;
            txtSignature.Text = xn["signature"].InnerText;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("要重新启动嘛？", "提示", MessageBoxButtons.YesNoCancel,
  MessageBoxIcon.Question) == DialogResult.Yes)
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\Friends.xml");
                XmlNode xn = doc.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
                xn["name"].InnerText = txtName.Text.Trim();
                xn["signature"].InnerText = txtSignature.Text.Trim();
                doc.Save(@"..\..\Friends.xml");
                
                // 重启程序
                Application.ExitThread();
                Application.Exit();
                Application.Restart();
                Process.GetCurrentProcess().Kill();  
            }
        }
    }
}
