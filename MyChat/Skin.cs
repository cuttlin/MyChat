using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MyChat
{
    public partial class Skin : Form
    {
        Form mform;// 主窗体
        public Skin(Form mainform)
        {
            this.mform = mainform;
            InitializeComponent();
        }

        private void Skin_Load(object sender, EventArgs e)
        {

        }

      

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlElement friends = doc.DocumentElement;
            XmlNode xn = friends.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
            PictureBox pic = (PictureBox)sender;
            string path = (string)pic.Tag;
            xn["skin"].InnerText = path;
            mform.BackgroundImage = Image.FromFile(xn["skin"].InnerText);
            doc.Save(@"..\..\Friends.xml");
            MessageBox.Show("修改成功！");
        }
    }
}
