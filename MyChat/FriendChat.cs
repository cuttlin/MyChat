using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web.Script.Serialization;
using Model;
using System.Xml;
using System.Media;

namespace MyChat
{
    public partial class FriendChat : Form
    {
        // 要进行通信的IP
        public string FriendIP { get; set; }
        
        // 自己的IP地址
        public string MyIP { get; set; }

        // 负责监听的Socket
        private Socket listenSocket = null;
        // 通信的端口
        private int comPort = 23333;

        public Color MyColor { get; set; }

        public RichTextBox rtbShow = null;

        // 用来播放声音
        SoundPlayer sp = new SoundPlayer();

        // 此构造函数用来生成先要进行通信的窗体
        public FriendChat(string friendIP,string myIP)
        {
            this.FriendIP = friendIP;
            this.MyIP = myIP;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlElement friends = doc.DocumentElement;
            XmlNode xn = friends.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
            this.MyColor = Color.FromArgb(Convert.ToInt32(xn["fontColor"].InnerText));
            InitializeComponent();
        }
        // 此构造函数用来生后进行通信的窗体
        //public FriendChat(string friendIP,int port)
        //{
        //    this.FriendIP = friendIP;
        //    // 通信端口计算方式：通过23333+对方ip最后一个段的数字即为通信端口
        //    this.comPort = port;
        //    InitializeComponent();
        //}

        private void FriendChat_Load(object sender, EventArgs e)
        {
            // 阻止对线程间通信的检查
            Control.CheckForIllegalCrossThreadCalls = false;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint listenIP = new IPEndPoint(IPAddress.Any, this.comPort);
            //listenSocket.Bind(listenIP);


            this.rtbShow = txtShow;
            //listenSocket.Listen(10);
            //Thread t = new Thread(Receive);
            //t.IsBackground = true;
            //t.Start();
        }

       

        /// <summary>
        /// 接收消息方法
        /// </summary>
        private void Receive()
        {
            byte[] b = new byte[1024];
            
            // 用来存放接受数据的ip改变情况
            EndPoint p = new IPEndPoint(IPAddress.Any, this.comPort);
            
            while (true)
            {
                int i = listenSocket.ReceiveFrom(b, ref p);
                sp.SoundLocation = @"../../voices/msg.wav";
                sp.Play();
                txtShow.AppendText(Encoding.UTF8.GetString(b,0,i));
            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            ChatContent cc = new ChatContent();
            cc.ChatType = 1;
            cc.SendIP = this.MyIP;
            cc.Content = txtSend.Text.Trim();
            cc.FontColor = this.MyColor.ToArgb().ToString(); ;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strCc = js.Serialize(cc);

            List<byte> list = new List<byte>();
            byte b = 2;
            list.Add(b);
            byte[] bCc = Encoding.UTF8.GetBytes(strCc);
            list.AddRange(bCc);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //s.Connect(FriendIP);

            IPEndPoint sendIP = new IPEndPoint(IPAddress.Parse(this.FriendIP),this.comPort);
            s.SendTo(list.ToArray(),sendIP);
            s.Close();
            FontSet(txtShow, txtSend.Text.Trim());
            txtShow.AppendText("我："+ txtSend.Text.Trim() + "\r\n");

            txtSend.Text = string.Empty;
        }

        /// <summary>
        /// 给自己的字体加上特效
        /// </summary>
        /// <param name="rtb">展示窗口</param>
        /// <param name="sendText">要发送的内容</param>
        private void FontSet(RichTextBox rtb,string sendText)
        {
            int start = rtb.Text.Length;
            
            rtb.Select(start, sendText.Length);
            rtb.SelectionColor = this.MyColor;
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        #region 窗体移动代码
        private Point mPoint = new Point();

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
        #endregion


        /// <summary>
        /// 窗体抖动方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picJitter_Click(object sender, EventArgs e)
        {
            ChatContent cc = new ChatContent();
            cc.ChatType = 2;
            cc.SendIP = this.MyIP;
            cc.Content = string.Empty;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strCc = js.Serialize(cc);

            List<byte> list = new List<byte>();
            byte b = 2;
            list.Add(b);
            byte[] bCc = Encoding.UTF8.GetBytes(strCc);
            list.AddRange(bCc);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //s.Connect(FriendIP);

            IPEndPoint sendIP = new IPEndPoint(IPAddress.Parse(this.FriendIP), this.comPort);
            s.SendTo(list.ToArray(), sendIP);
            s.Close();
            
        }

        private void picColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            Color c = cd.Color;
            this.MyColor = c;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlElement friends = doc.DocumentElement;
            XmlNode xn = friends.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
            xn["fontColor"].InnerText = c.ToArgb().ToString();
            doc.Save(@"..\..\Friends.xml");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Point p = new Point(btnList.Left, btnList.Top);
            contextMenuStrip1.Show(p);
        }

        private void tsmiEnter_Click(object sender, EventArgs e)
        {
            tsmiClick.Checked = false;
            tsmiClick.CheckState = CheckState.Unchecked;
            tsmiEnter.Checked = true;
            tsmiEnter.CheckState = CheckState.Checked;
            
            this.AcceptButton = btnSend;
        }

        private void tsmiClick_Click(object sender, EventArgs e)
        {
            tsmiClick.Checked = true;
            tsmiClick.CheckState = CheckState.Checked;
            tsmiEnter.Checked = false;
            tsmiEnter.CheckState = CheckState.Unchecked;
            this.AcceptButton = null;
        }

        private void picFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            Font f = fd.Font;
           // byte charSet =  f.GdiCharSet();
            // HFSoft.Serialization.Serializable.SerializeObject(
        }

        private void txtShow_TextChanged(object sender, EventArgs e)
        {
            this.rtbShow.SelectionStart = this.rtbShow.Text.Length;
            this.rtbShow.SelectionLength = 0;
        }

       
       
       
    }
}
