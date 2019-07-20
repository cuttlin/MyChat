using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Xml;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Model;
using System.Media;

namespace MyChat
{
    /// <summary>
    /// 定义委托解决跨线程访问窗体问题
    /// </summary>
    delegate void FreshFriendList();

    /// <summary>
    /// 主界面socket负责广播    0：寻找好友，1：回应好友信息，2：请求通信
    /// </summary>
    public partial class MainForm : Form
    {
        private string MyName;
        private string IP;
        private string MyPhoto;
        private string Signature;
        // 负责监听的Socket
        private Socket listenSocket = null;

        // 用来存放在线的好友
        private List<Friend> onlineList = new List<Friend>();

        // 用来存放ip与窗体的键值对集合，根据字符串类型取出窗体
        private Dictionary<string, FriendChat> dic = new Dictionary<string, FriendChat>();

        // 用来播放声音
        SoundPlayer sp = new SoundPlayer();
        public MainForm()
        {
            InitializeComponent();
            IPAddress ipaddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
            string strIp = ipaddress.ToString();
            this.IP = strIp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 初始化本地设置
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlElement friends = doc.DocumentElement;
            XmlNode xn = friends.SelectSingleNode(@"/friends/type[@val='我自己']/friend");
            this.MyName = xn["name"].InnerText;
            this.Signature = xn["signature"].InnerText;
            this.MyPhoto = xn["photo"].InnerText;
            this.BackgroundImage = Image.FromFile(xn["skin"].InnerText);
            lblName.Text = this.MyName;
            lblSignature.Text = this.Signature;
            if (this.MyPhoto == "1")
            {
                picB.Image = Image.FromFile(@"../../imgs/man.png");
            }
            else if (this.MyPhoto == "0")
            {
                picB.Image = Image.FromFile(@"../../imgs/woman.png");
            }

            // 设置窗体可以跨线程通信
            Control.CheckForIllegalCrossThreadCalls = false;
            // 初始化负责监听的Socket
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // 监听0.0.0.0的23333端口
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 23333);
            listenSocket.Bind(ip);
            // listenSocket.Listen(10);



            // 开启一个新的线程，在后台进行监听
            Thread t = new Thread(Receive);
            t.IsBackground = true;
            t.Start();


            // 加载自己好友方法
            ShowMyFriend();

            //登陆时应该先发一条消息，广播我已经登陆了
            AddFriend_Click(null, null);
        }

        // 添加好友方法
        private void AddFriend_Click(object sender, EventArgs e)
        {
            // 向255.255.255.255发送消息
            // 设置Socket类型
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // 设置Socket等级
            s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            // 设置要发送的IP
            IPEndPoint ip = new IPEndPoint(IPAddress.Broadcast, 23333);

            // 最终用来传输的集合
            List<byte> list = new List<byte>();
            byte b = 0;
            list.Add(b);

            // 获取本机IP地址
            IPAddress ipaddress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];
            string strIp = ipaddress.ToString();

            //使用Json来序列化自己的信息
            Friend f = new Friend();
            f.IP = strIp;
            f.Name = this.MyName;
            f.Photo = this.MyPhoto;
            f.Signature = this.Signature;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strF = js.Serialize(f);
            list.AddRange(Encoding.UTF8.GetBytes(strF));

            // 进行发送  协议0+本机ip
            s.SendTo(list.ToArray(), ip);
            s.Close();
        }





        /// <summary>
        /// 接收消息方法
        /// </summary>
        private void Receive()
        {
            try
            {
                // 用来存储获得的数据
                byte[] receiveBytes = new byte[1024 * 1024];


                // 用来存放接受数据的ip改变情况
                EndPoint p = new IPEndPoint(IPAddress.Any, 23333);

                // 不停地循环监听收到的消息
                while (true)
                {
                    int i = listenSocket.ReceiveFrom(receiveBytes, ref p);
                    if (receiveBytes[0] == 2)// 2代表请求通信，接收定义好的端口好，new出窗体对象，并隐藏
                    {
                        // 反序列化
                        string content = Encoding.UTF8.GetString(receiveBytes, 1, i - 1);
                        JavaScriptSerializer javass = new JavaScriptSerializer();
                        ChatContent cc = javass.Deserialize<ChatContent>(content);

                        if (cc.ChatType == 0)
                        {
                            sp.SoundLocation = @"../../voices/system.wav";
                            sp.Play();
                            if (!dic.ContainsKey(cc.SendIP))
                            {
                                FriendChat fc = new FriendChat(cc.SendIP, this.IP);
                                fc.Hide();
                                dic.Add(cc.SendIP, fc);
                            }
                        }

                        // 如果不可见，就不进行操作，防止线程问题
                        if (!dic[cc.SendIP].Visible)
                        {
                            continue;
                        }

                        if (cc.ChatType == 1)       // 发的文字
                        {
                            sp.SoundLocation = @"../../voices/msg.wav";
                            sp.Play();
                            FontSet(dic[cc.SendIP].rtbShow, cc.Content, Color.FromArgb(Convert.ToInt32(cc.FontColor)));
                            
                            dic[cc.SendIP].rtbShow.AppendText(cc.SendIP + "：" + cc.Content + "\r\n");

                        }
                        else if (cc.ChatType == 2)  // 发的窗口抖动
                        {
                            for (int j = 0; j < 200; j++)
                            {
                                dic[cc.SendIP].Left += 30;
                                dic[cc.SendIP].Top += 30;
                                dic[cc.SendIP].Left -= 30;
                                dic[cc.SendIP].Top -= 30;
                            }
                        }

                        continue;
                    }



                    // 解析数据，获得IP，IP是自己的则跳出执行下一个循环
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    Friend fri = jss.Deserialize<Friend>(Encoding.UTF8.GetString(receiveBytes, 1, i - 1));
                    EndPoint requestIP = new IPEndPoint(IPAddress.Parse(fri.IP), 23333);
                    if (fri.IP == this.IP)
                    {
                        continue;
                    }
                    // 判断发过来的消息是要干嘛
                    if (receiveBytes[0] == 0) // 0代表找好友,返回个人信息，并返回1协议
                    {
                        // 播放声音提醒好友上线
                        sp.SoundLocation = @"../../voices/Global.wav";
                        sp.Play();

                        // 在集合中添加此在线用户
                        onlineList.Add(fri);
                        // 调用下面的分析方法
                        Arrange(receiveBytes, i);

                        List<byte> list = new List<byte>();
                        // 使用协议1
                        byte b = 1;
                        list.Add(b);
                        //list.AddRange(Encoding.UTF8.GetBytes(ip));
                        // 将此机器的IP地址发送给所有机器


                        //使用Json来序列化自己的信息
                        Friend f = new Friend();
                        f.IP = this.IP;
                        f.Name = this.MyName;
                        f.Photo = this.MyPhoto;
                        f.Signature = this.Signature;
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string strF = js.Serialize(f);
                        list.AddRange(Encoding.UTF8.GetBytes(strF));

                        listenSocket.SendTo(list.ToArray(), requestIP);
                    }
                    else if (receiveBytes[0] == 1) // 1代表返回了好友信息，接收不再发广播
                    {
                        // 播放声音提醒好友上线
                        sp.SoundLocation = @"../../voices/Global.wav";
                        sp.Play();

                        onlineList.Add(fri);
                        Arrange(receiveBytes, i);
                    }
                    else if (receiveBytes[0] == 6)// 6表示此用户已下线
                    {
                        onlineList.Remove(fri);
                        UpdateFriendState(fri, false);
                    }

                }
            }
            catch { }

        }

        /// <summary>
        /// 用于处理分析Receive方法获取到的数据
        /// </summary>
        private void Arrange(byte[] receiveBytes, int i)
        {
            // 反序列化发送过来的用户数据
            string resVal = Encoding.UTF8.GetString(receiveBytes, 1, i - 1);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Friend f = js.Deserialize<Friend>(resVal);

            // 加载xml，获取xml文档节点
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Friends.xml");
            XmlElement friends = doc.DocumentElement;
            XmlNode xn = friends.SelectSingleNode(@"/friends/type/friend[ip='" + f.IP + "']");
            if (xn == null)//代表好友列表中没有此用户,进行添加
            {
                XmlElement friend = doc.CreateElement("friend");
                XmlElement xmlip = doc.CreateElement("ip");
                xmlip.InnerText = f.IP;
                XmlElement name = doc.CreateElement("name");
                name.InnerText = f.Name;
                XmlElement signature = doc.CreateElement("signature");
                signature.InnerText = f.Signature;
                XmlElement photo = doc.CreateElement("photo");
                photo.InnerText = f.Photo;
                XmlNode noGroup = doc.SelectSingleNode(@"/friends/type[@val='未分组好友']");
                friend.AppendChild(xmlip);
                friend.AppendChild(name);
                friend.AppendChild(photo);
                friend.AppendChild(signature);
                noGroup.AppendChild(friend);
                doc.Save(@"..\..\Friends.xml");


                // 重新加载好友列表
                ShowMyFriend();

                // 更新好友状态
                foreach (Friend item in onlineList)
                {
                    UpdateFriendState(item, true);
                }
            }
            else           //代表好友列表中存在此用户
            {
                // 更新一下好友的信息
                xn["name"].InnerText = f.Name;
                xn["photo"].InnerText = f.Photo;
                xn["signature"].InnerText = f.Signature;
                doc.Save(@"..\..\Friends.xml");
                // 重新加载好友列表
                ShowMyFriend();

                // 更新好友状态
                foreach (Friend item in onlineList)
                {
                    UpdateFriendState(item, true);
                }

            }

        }

        /// <summary>
        /// 更新好友在线状态,布尔值标识是上线还是下线
        /// </summary>
        private void UpdateFriendState(Friend f, bool flag)
        {
            // 遍历控件获得按钮设置为在线状态，并添加单击事件
            foreach (Control item in tabPageFriend.Controls)
            {
                if (item is Button)
                {
                    Panel p = (Panel)item.Tag;
                    foreach (Control btnitem in p.Controls)
                    {
                        if ((string)btnitem.Tag == f.IP)
                        {
                            if (flag)
                            {
                                btnitem.BackColor = Color.White;
                            }
                            else
                            {
                                btnitem.BackColor = Color.Gray;
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 退出程序方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // 推出之前发一条下线消息
            List<byte> list = new List<byte>();
            byte b = 6;
            list.Add(b);

            Friend f = new Friend();
            f.IP = this.IP;
            f.Name = this.MyName;
            f.Photo = this.MyPhoto;
            f.Signature = this.Signature;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strF = js.Serialize(f);
            list.AddRange(Encoding.UTF8.GetBytes(strF));
            IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, 23333);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            s.SendTo(list.ToArray(), anyIP);

            Application.Exit();
        }

        /// <summary>
        /// 最小化方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmall_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 显示窗体方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }


        /// <summary>
        /// 展示好友列表方法
        /// </summary>
        private void ShowMyFriend()
        {
            if (this.tabPageFriend.InvokeRequired)
            {
                FreshFriendList ffl = new FreshFriendList(ShowMyFriend);
                this.Invoke(ffl);
            }
            else
            {

                tabPageFriend.Controls.Clear();
                // 加载xml，获取xml文档节点
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\Friends.xml");
                XmlElement friends = doc.DocumentElement;
                // 遍历根节点下的第一个节点，好友类型
                foreach (XmlNode item in friends.ChildNodes)
                {
                    // 初始化好友类型按钮
                    Button b = new Button();
                    b.Text = item.Attributes["val"].Value;
                    b.Dock = DockStyle.Top;
                    b.Height = 25;
                    b.Click += new EventHandler(btnFriendType_Click);
                    // 为此好友类型设置一个容器
                    Panel p = new Panel();
                    p.AutoSize = true;
                    p.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    p.Dock = DockStyle.Top;
                    // 将此容器绑定到按钮的tag上，便于隐藏
                    b.Tag = p;
                    foreach (XmlNode ite in item.ChildNodes)
                    {
                        Button bt = new Button();
                        bt.Dock = DockStyle.Top;
                        bt.BackgroundImage = Image.FromFile(@"../../imgs/man.png");
                        bt.BackgroundImageLayout = ImageLayout.None;
                        bt.ImageAlign = ContentAlignment.MiddleLeft;
                        bt.TextAlign = ContentAlignment.MiddleRight;
                        bt.FlatStyle = FlatStyle.Flat;
                        bt.BackColor = Color.Gray;
                        bt.Height = 45;
                        XmlNode xn = ite.SelectSingleNode("name");
                        bt.Text = xn.InnerText;
                        // 将IP存放到此用户按钮的tag中
                        bt.Tag = ite.SelectSingleNode("ip").InnerText;
                        bt.Click += new EventHandler(btnFriendChat_Click); //new EventHandler(btnFriendChat_Click);
                        p.Controls.Add(bt);
                    }
                    // 因为dock属性是逆序置顶，所以倒叙添加
                    tabPageFriend.Controls.Add(p);
                    tabPageFriend.Controls.Add(b);
                }
            }
        }



        /// <summary>
        /// 点击好友聊天方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnFriendChat_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor == Color.Gray)
            {
                return;
            }
            string str = (string)btn.Tag;
            //IPEndPoint chatIp = new IPEndPoint(IPAddress.Parse(str), 23333);

            // 判断集合里有没有此键，没有就创建一个,并发送一条请求通信消息 2协议
            FriendChat showForm = null;
            if (!dic.ContainsKey(str))
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                byte b = 2;
                List<byte> list = new List<byte>();
                list.Add(b);

                // 初始化聊天对象
                JavaScriptSerializer js = new JavaScriptSerializer();
                ChatContent cc = new ChatContent();
                cc.SendIP = this.IP;
                cc.ChatType = 0;
                cc.Content = string.Empty;
                string strCc = js.Serialize(cc);
                list.AddRange(Encoding.UTF8.GetBytes(strCc));

                IPEndPoint lastComIP = new IPEndPoint(IPAddress.Parse(str), 23333);
                // 向对方请求通信
                s.SendTo(list.ToArray(), lastComIP);
                showForm = new FriendChat(str, this.IP);
                dic.Add(str, showForm);
            }
            else
            {
                showForm = dic[str];
            }
            showForm.Show();

        }



        /// <summary>
        /// 好友bar单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFriendType_Click(object sender, EventArgs e)
        {
            // 获得此Button tag中存储panel对象进行显示或隐藏
            Button btn = (Button)sender;
            Panel p = (Panel)btn.Tag;
            if (p.Visible == true)
            {
                p.Visible = false;
            }
            else
            {
                p.Visible = true;
            }
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
        /// 修改个人资料方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new UpdateUser().ShowDialog();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// 给自己的字体加上特效
        /// </summary>
        /// <param name="rtb">展示窗口</param>
        /// <param name="sendText">要发送的内容</param>
        private void FontSet(RichTextBox rtb, string sendText,Color c)
        {
            int start = rtb.Text.Length;

            rtb.Select(start, sendText.Length);
            rtb.SelectionColor = c;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new Skin(this).ShowDialog();
        }

    }

}
