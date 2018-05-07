using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Specialized;  

namespace 上位机
{
    public partial class 上位机 : Form
    {
        private const int unit_length = 16;//单元格大小
        private int drawstep = 8;//默认绘制单位
        private int Y_max;//Y轴最大数值
        private const int maxstep = 33;//绘制单位最大值
        private const int minstep = 1;//绘制单位最小值
        private const int startprint_x = 32;//点坐标偏移量
        private const int startprint_y = 5;//点坐标偏移量
        private Pen tablepen = new Pen(Color.FromArgb(0x00, 0x00, 0x00));//轴线颜色
        private Pen linespen = new Pen(Color.FromArgb(0xFF, 0x00, 0x00));//轴线颜色

        private List<byte> datalist_I_basemotor1 = new List<byte>();//电流值数据结构——线性链表
        private List<byte> datalist_I_basemotor2 = new List<byte>();
        private List<byte> datalist_I_basemotor3 = new List<byte>();
        private List<byte> datalist_I_basemotor4 = new List<byte>();
        private List<byte> datalist_I_ytmotoryaw = new List<byte>();
        private List<byte> datalist_I_ytmotorpitch = new List<byte>();
        private List<byte> datalist_I_bdmotor = new List<byte>();
        private List<byte> datalist_I_mclmotor1 = new List<byte>();
        private List<byte> datalist_I_mclmotor2 = new List<byte>();

        private List<byte> datalist_speed_basemotor1 = new List<byte>();//速度值数据结构——线性链表
        private List<byte> datalist_speed_basemotor2 = new List<byte>();
        private List<byte> datalist_speed_basemotor3 = new List<byte>();
        private List<byte> datalist_speed_basemotor4 = new List<byte>();
        private List<byte> datalist_speed_ytmotoryaw = new List<byte>();
        private List<byte> datalist_speed_ytmotorpitch = new List<byte>();
        private List<byte> datalist_speed_bdmotor = new List<byte>();
        private List<byte> datalist_speed_mclmotor1 = new List<byte>();
        private List<byte> datalist_speed_mclmotor2 = new List<byte>();

        private List<byte> datalist_location_ytmotoryaw = new List<byte>();//位置值数据结构——线性链表
        private List<byte> datalist_location_ytmotorpitch = new List<byte>();
        private List<byte> datalist_location_bdmotor = new List<byte>();

        private List<byte> datalist_power_basemotor1 = new List<byte>();//功率值数据结构——线性链表
        private List<byte> datalist_power_basemotor2 = new List<byte>();
        private List<byte> datalist_power_basemotor3 = new List<byte>();
        private List<byte> datalist_power_basemotor4 = new List<byte>();

        //将远程连接的IP地址和Socket存入集合
        Dictionary<string, Socket> dicsocket = new Dictionary<string, Socket>();
        //将远程连接的IP地址与连接状态存入集合
        Dictionary<string, int> dicsocket_flag = new Dictionary<string, int>();
        //将远程连接的IP地址与对应的线程存入集合
        Dictionary<string, Thread> Thread_flag = new Dictionary<string, Thread>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public 上位机()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);//开启双缓冲
            this.UpdateStyles();
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void 上位机_Load(object sender, EventArgs e)
        {
            ///发送和接收格式初始化设置
            is_hex_send.Checked = true;
            is_hex_show.Checked = true;

            //获得本机IP地址
            foreach (string ip in GetLocalIpv4())
            {
                local_ip_address_box.Text = ip.ToString();
            }
            local_ip_address_box.AppendText(":555");
            is_motor1.Checked = true;
            is_I_huan.Checked = true;
            link_bind_btn.Enabled = true;

            timer1.Start();    
        }
        private void 上位机_Paint(object sender, PaintEventArgs e)
        {
            Bitmap I_bmp = new Bitmap(I_plot.Size.Width, I_plot.Size.Height);
            Bitmap speed_bmp = new Bitmap(speed_plot.Size.Width, speed_plot.Size.Height);
            Bitmap location_map = new Bitmap(location_plot.Size.Width, location_plot.Size.Height);

            Graphics gp = Graphics.FromImage(I_bmp);
            Graphics gp_speed = Graphics.FromImage(speed_bmp);
            Graphics gp_location = Graphics.FromImage(location_map);

            //纵向轴绘制
            for (int i = 0; i < I_plot.Size.Width / unit_length; i++)
            {
                //I_map
                Y_max = I_plot.Size.Height - 20;
                gp.DrawLine(tablepen, startprint_x + i * unit_length, startprint_y, startprint_x + i * unit_length, startprint_y + Y_max);
                gp.DrawString((i * (unit_length / drawstep)).ToString(), tabControl1.Font, Brushes.Black, new RectangleF(startprint_x + i * unit_length - 5, startprint_y + Y_max + 4, 50, 50), null);
                //speed_bmp
                Y_max = speed_plot.Size.Height - 20;
                gp_speed.DrawLine(tablepen, startprint_x + i * unit_length, startprint_y, startprint_x + i * unit_length, startprint_y + Y_max);
                gp_speed.DrawString((i * (unit_length / drawstep)).ToString(), tabControl1.Font, Brushes.Black, new RectangleF(startprint_x + i * unit_length - 5, startprint_y + Y_max + 4, 50, 50), null);
                //location_map
                Y_max = location_plot.Size.Height - 20;
                gp_location.DrawLine(tablepen, startprint_x + i * unit_length, startprint_y, startprint_x + i * unit_length, startprint_y + Y_max);
                gp_location.DrawString((i * (unit_length / drawstep)).ToString(), tabControl1.Font, Brushes.Black, new RectangleF(startprint_x + i * unit_length - 5, startprint_y + Y_max + 4, 50, 50), null);
            }

            //横向轴绘制
            //I_map
            Y_max = I_plot.Size.Height - 20;
            for (int i = 0; i <= Y_max / unit_length; i++)
            {
                gp.DrawLine(tablepen, startprint_x, startprint_y + i * unit_length, I_plot.Size.Width, startprint_y + i * unit_length);
                if (i == 0)
                    gp.DrawString("1.00", tabControl1.Font, Brushes.Black, new RectangleF(0, startprint_y - 4, 40, 50), null);
                if ((i + 1) > Y_max / unit_length)
                    gp.DrawString("0.00", tabControl1.Font, Brushes.Black, new RectangleF(0, i * unit_length + startprint_y - 4, 40, 50), null);
            }
            //speed_bmp
            Y_max = speed_plot.Size.Height - 20;
            for (int i = 0; i <= Y_max / unit_length; i++)
            {
                gp_speed.DrawLine(tablepen, startprint_x, startprint_y + i * unit_length, speed_plot.Size.Width, startprint_y + i * unit_length);
                if (i == 0)
                    gp_speed.DrawString("1.00", tabControl1.Font, Brushes.Black, new RectangleF(0, startprint_y - 4, 40, 50), null);
                if ((i + 1) > Y_max / unit_length)
                    gp_speed.DrawString("0.00", tabControl1.Font, Brushes.Black, new RectangleF(0, i * unit_length + startprint_y - 4, 40, 50), null);
            }
            //location_map
            Y_max = location_plot.Size.Height - 20;
            for (int i = 0; i <= Y_max / unit_length; i++)
            {
                gp_location.DrawLine(tablepen, startprint_x, startprint_y + i * unit_length, location_plot.Size.Width, startprint_y + i * unit_length);
                if (i == 0)
                    gp_location.DrawString("1.00", tabControl1.Font, Brushes.Black, new RectangleF(0, startprint_y - 4, 40, 50), null);
                if ((i + 1) > Y_max / unit_length)
                    gp_location.DrawString("0.00", tabControl1.Font, Brushes.Black, new RectangleF(0, i * unit_length + startprint_y - 4, 40, 50), null);
            }

            //绘制曲线
            List<byte> datalist_I = new List<byte>();//电流值数据结构——线性链表
            List<byte> datalist_speed = new List<byte>();//速度值数据结构——线性链表
            List<byte> datalist_location = new List<byte>();//位置值数据结构——线性链表
            if (is_motor1.Checked)
            {
                datalist_I = datalist_I_basemotor1;
                datalist_speed = datalist_speed_basemotor1;
                datalist_location = datalist_power_basemotor1;
            }
            else if (is_motor2.Checked)
            {
                datalist_I = datalist_I_basemotor2;
                datalist_speed = datalist_speed_basemotor2;
                datalist_location = datalist_power_basemotor2;
            }
            else if (is_motor3.Checked)
            {
                datalist_I = datalist_I_basemotor3;
                datalist_speed = datalist_speed_basemotor3;
                datalist_location = datalist_power_basemotor3;
            }
            else if (is_motor4.Checked)
            {
                datalist_I = datalist_I_basemotor4;
                datalist_speed = datalist_speed_basemotor4;
                datalist_location = datalist_power_basemotor4;
            }
            else if (is_motor_ytyaw.Checked)
            {
                datalist_I = datalist_I_ytmotoryaw;
                datalist_speed = datalist_speed_ytmotoryaw;
                datalist_location = datalist_location_ytmotoryaw;
            }
            else if (is_motor_ytpitch.Checked)
            {
                datalist_I = datalist_I_ytmotorpitch;
                datalist_speed = datalist_speed_ytmotorpitch;
                datalist_location = datalist_location_ytmotorpitch;
            }
            else if (is_bdmotor.Checked)
            {
                datalist_I = datalist_I_bdmotor;
                datalist_speed = datalist_speed_bdmotor;
                datalist_location = datalist_location_bdmotor;
            }
            else if (is_mclmotor1.Checked)
            {
                datalist_I = datalist_I_mclmotor1;
                datalist_speed = datalist_speed_mclmotor1;
            }
            else if (is_mclmotor2.Checked)
            {
                datalist_I = datalist_I_mclmotor2;
                datalist_speed = datalist_speed_mclmotor2;
            }

            //I_map
            Y_max = I_plot.Size.Height - 20;
            if (datalist_I.Count - 1 >= (I_plot.Size.Width - startprint_x) / drawstep)
            {
                datalist_I.RemoveRange(0, datalist_I.Count - 1 - (I_plot.Size.Width - startprint_x) / drawstep);
            }
            for (int i = 0; i < datalist_I.Count - 1; i++)
            {
                gp.DrawLine(linespen, startprint_x + i * drawstep, startprint_y + Y_max - datalist_I[i] * Y_max / 0xFF, startprint_x + (i + 1) * drawstep, startprint_y + Y_max - datalist_I[i + 1] * Y_max / 0xFF);
            }
            //speed_bmp
            Y_max = speed_plot.Size.Height - 20;
            if (datalist_speed.Count - 1 >= (speed_plot.Size.Width - startprint_x) / drawstep)
            {
                datalist_speed.RemoveRange(0, datalist_speed.Count - 1 - (speed_plot.Size.Width - startprint_x) / drawstep);
            }
            for (int i = 0; i < datalist_speed.Count - 1; i++)
            {
                gp_speed.DrawLine(linespen, startprint_x + i * drawstep, startprint_y + Y_max - datalist_speed[i] * Y_max / 0xFF, startprint_x + (i + 1) * drawstep, startprint_y + Y_max - datalist_speed[i + 1] * Y_max / 0xFF);
            }
            //location_map
            Y_max = location_plot.Size.Height - 20;
            if (datalist_location.Count - 1 >= (location_plot.Size.Width - startprint_x) / drawstep)
            {
                datalist_location.RemoveRange(0, datalist_location.Count - 1 - (location_plot.Size.Width - startprint_x) / drawstep);
            }
            for (int i = 0; i < datalist_location.Count - 1; i++)
            {
                gp_location.DrawLine(linespen, startprint_x + i * drawstep, startprint_y + Y_max - datalist_location[i] * Y_max / 0xFF, startprint_x + (i + 1) * drawstep, startprint_y + Y_max - datalist_location[i + 1] * Y_max / 0xFF);
            }

            //显示曲线
            I_plot.Image = I_bmp;
            speed_plot.Image = speed_bmp;
            location_plot.Image = location_map;
        }

        /// <summary>
        /// 返回所有本机IPv4地址
        /// </summary>
        /// <returns></returns>
        private string[] GetLocalIpv4()
        {
            //事先不知道ip的个数，数组长度未知，因此用StringCollection储存  
            IPAddress[] localIPs;
            localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            StringCollection IpCollection = new StringCollection();
            foreach (IPAddress ip in localIPs)
            {
                //根据AddressFamily判断是否为ipv4,如果是InterNetWorkV6则为ipv6  
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    IpCollection.Add(ip.ToString());
            }
            string[] IpArray = new string[IpCollection.Count];
            IpCollection.CopyTo(IpArray, 0);
            return IpArray;
        }
      
        /// <summary>
        /// 创建服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_bind_btn_Click(object sender, EventArgs e)
        {
            //创建Socket监听对象
            Socket socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (local_ip_address_box.Text != "")
            {
                //获得IP地址和端口号
                IPAddress local_ip = IPAddress.Parse(local_ip_address_box.Text.Substring(0, local_ip_address_box.Text.IndexOf(":555")));
                IPEndPoint point = new IPEndPoint(local_ip, 555);
                //绑定端口号
                socketwatch.Bind(point);
                MessageBox.Show("服务器创建成功，开始监听！");
                //设置最大连入客户端数量
                socketwatch.Listen(10);
                //开启新线程，等待客户端连入
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start(socketwatch);
                link_bind_btn.Enabled = false;
            }         
        }
        /// <summary>
        /// 服务器监听线程
        /// </summary>
        /// <param name="o"></param>
        private void Listen(object o)
        {
            Socket socketwatch = o as Socket;
            while (true)
            {
                try
                {
                    Socket socketsend = socketwatch.Accept();
                    //将远程连接的客户端的IP地址和Socket存入集合中
                    dicsocket.Add(socketsend.RemoteEndPoint.ToString(), socketsend);
                    //将远程连接的客户端的IP地址存入目标对象中
                    send_object_select_item.Items.Add(socketsend.RemoteEndPoint.ToString());
                    //为目标对象选择下拉框选择缺省值
                    if (send_object_select_item.Items.Count == 1)
                    {
                        send_object_select_item.SelectedIndex = 0;
                    }
                    //显示连入状态
                    link_state_box.AppendText(socketsend.RemoteEndPoint.ToString() + "\r\n");
                    //开启新线程，不停接收数据
                    Thread th = new Thread(Receive);
                    th.IsBackground = true;
                    th.Start(socketsend);

                    Thread_flag.Add(socketsend.RemoteEndPoint.ToString(), th);
                }
                catch
                { }
            }
        }     
        /// <summary>
        /// 数据接收和解析函数
        /// </summary>
        /// <param name="o"></param>
        private void Receive(object o)
        {
            Socket socketsend = o as Socket;
            socketsend.ReceiveBufferSize = 4096;
            //将远程连接的客户端的IP地址和连接状态存入集合中
            dicsocket_flag.Add(socketsend.RemoteEndPoint.ToString(), 20);
            while (true)
            {
                try
                {   
                    if (tabControl1.SelectedTab.Text.Equals("数据基本收发"))
                    {                        
                        byte[] buffer = new byte[1024 * 1024];
                        int r = socketsend.Receive(buffer);
                        if (r == 0 && dicsocket_flag[socketsend.RemoteEndPoint.ToString()] <= 2)
                        {
                            break;
                        }
                        if (is_hex_show.Checked)//16进制显示
                        {
                            for (int i = 0; i < r; i++)
                            {
                                if (buffer[i] == 0x6f && buffer[i+1] == 0x6b)//心跳包
                                {
                                    dicsocket_flag[socketsend.RemoteEndPoint.ToString()] = 20; // 喂狗
                                }
                                receive_data_box.AppendText("0x" + buffer[i].ToString("X2") + " ");
                            }
                            receive_data_box.AppendText("\r\n");
                        }
                        else//字符格式显示
                        {
                            string str = Encoding.UTF8.GetString(buffer, 0, r);
                            if (str.Contains("ok"))
                            {
                                dicsocket_flag[socketsend.RemoteEndPoint.ToString()] = 20; // 喂狗
                            }
                            receive_data_box.AppendText(str + "\r\n");
                        }
                    }
                    else if (tabControl1.SelectedTab.Text.Equals("状态显示"))
                    {
                        //读取读取缓冲数据
                        byte[] buffer = new byte[1024];
                        int n = socketsend.Receive(buffer);
                        if (n == 0 && dicsocket_flag[socketsend.RemoteEndPoint.ToString()] <= 2)
                        {
                            break;
                        }
                        data_packet_analysis(buffer, n, socketsend);//数据包解析
                    }
                }
                catch
                { }
            }
            //从集合中去除对应的IP地址
            dicsocket.Remove(socketsend.RemoteEndPoint.ToString());
            dicsocket_flag.Remove(socketsend.RemoteEndPoint.ToString());
            //重写连入状态文本框及目标对象下拉框选项
            link_state_box.Text = "";  
            send_object_select_item.Items.Clear();
            foreach (var item in dicsocket)
            {
                link_state_box.AppendText(item.Key + "\r\n");
                send_object_select_item.Items.Add(item.Key);
            }
            //若目标对象文本框中对象断开，则清空文本框
            if (socketsend.RemoteEndPoint.ToString() == send_object_select_item.Text)
            {
                send_object_select_item.Text = "";
            }
            //关闭并清除Socket内存
            socketsend.Close();
            socketsend.Dispose();
        }

        int data_num = 0;//上次未处理数据长度
        byte[] data_buf = new byte[50000];//存放尚未处理的数据
        /// <summary>
        /// 数据包处理函数
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="n"></param>
        private void data_packet_analysis(byte[] buffer, int n, Socket socketsend)
        {
            //数据包解析
            int _frame_num = 0; // 功能字
            int _frame_len = 0; // 帧长度

            if (n > 20000) return;//接收到的数据过长，可能出错
            
            //从data_buf的第data_num处开始写入，与之前未处理数据连接在一起
            for (int count = 0; count < n; count++)
            {
                data_buf[data_num + count] = buffer[count];
            }
            data_num += n;

            int I = 0;
            while (I < data_num - 4)//遍历接收数据
            {
                //心跳包数据检测
                if (data_buf[I] == 0x6f && data_buf[I + 1]==0x6b)
                {
                    dicsocket_flag[socketsend.RemoteEndPoint.ToString()] = 20; // 喂狗
                }
                //数据解析
                if (data_buf[I] == 0xff && data_buf[I + 1] == 0xff && data_buf[I + 3] < 51)
                {
                    //MessageBox.Show("发现数据");
                    _frame_num = data_buf[I + 2];
                    _frame_len = data_buf[I + 3];
                    if ((data_num - I - 5) >= _frame_len) // 数据接收完毕
                    {
                        //MessageBox.Show("数据接收完毕");
                        byte sum = 0;
                        for (int j = I; j <= I + 3 + _frame_len; j++)//计算sum
                            sum += data_buf[j];
                        if (sum == data_buf[I + 4 + _frame_len])//sum校验
                        {
                            //MessageBox.Show("数据校验完毕"); 
                            int j;
                            switch (_frame_num)
                            {
                                case 1://底盘电机的电流和速度信息                                    
                                    j = I + 4;
                                    datalist_I_basemotor1.Add(data_buf[j]);
                                    datalist_speed_basemotor1.Add(data_buf[j + 1]);
                                    datalist_power_basemotor1.Add(data_buf[j + 2]);

                                    datalist_I_basemotor2.Add(data_buf[j + 3]);
                                    datalist_speed_basemotor2.Add(data_buf[j + 4]);
                                    datalist_power_basemotor2.Add(data_buf[j + 5]);
                                    //MessageBox.Show("数据解析");                     
                                    break;
                                case 2://底盘电机的电流和速度信息
                                    j = I + 4;
                                    datalist_I_basemotor3.Add(data_buf[j]);
                                    datalist_speed_basemotor3.Add(data_buf[j + 1]);
                                    datalist_power_basemotor3.Add(data_buf[j + 2]);

                                    datalist_I_basemotor4.Add(data_buf[j + 3]);
                                    datalist_speed_basemotor4.Add(data_buf[j + 4]);
                                    datalist_power_basemotor4.Add(data_buf[j + 5]);
                                    break;
                                case 3://云台电机的电流、速度、位置信息
                                    j = I + 4;
                                    datalist_I_ytmotoryaw.Add(data_buf[j]);
                                    datalist_speed_ytmotoryaw.Add(data_buf[j + 1]);
                                    datalist_location_ytmotoryaw.Add(data_buf[j + 2]);

                                    datalist_I_ytmotorpitch.Add(data_buf[j + 3]);
                                    datalist_speed_ytmotorpitch.Add(data_buf[j + 4]);
                                    datalist_location_ytmotorpitch.Add(data_buf[j + 5]);
                                    break;
                                case 4://拨弹电机的电流、速度、位置信息 //摩擦轮电机电流、速度信息 
                                    j = I + 4;
                                    datalist_I_bdmotor.Add(data_buf[j]);
                                    datalist_speed_bdmotor.Add(data_buf[j + 1]);
                                    datalist_location_bdmotor.Add(data_buf[j + 2]);

                                    datalist_I_mclmotor1.Add(data_buf[j + 3]);
                                    datalist_speed_mclmotor1.Add(data_buf[j + 4]);
                                    datalist_I_mclmotor2.Add(data_buf[j + 5]);
                                    datalist_speed_mclmotor2.Add(data_buf[j + 6]);
                                    break;
                                default:
                                    break;
                            }
                            I = I + 5 + _frame_len; // I指向下一帧数据
                        }
                        else //sum校验未通过
                        {
                            I++;
                        }
                    }
                    else//HEAD FUN LEN符合要求,但是数据未接收完毕
                    {
                        for (int j = I; j <= data_num - 1; j++)
                        {
                            data_buf[j - I] = data_buf[j];
                        }
                        data_num = data_num - I;
                        return;
                    }
                }
                else //HEAD FUN LEN不符合要求
                {
                    I++;
                }
            }
            if (I <= data_num) // 剩几字节没有处理完
            {
                for (int j = I; j <= data_num - 1; j++)
                {
                    data_buf[j - I] = data_buf[j];
                }
                data_num = data_num - I;
            }
        }

        /// <summary>
        /// 数据发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void send_data_btn_Click(object sender, EventArgs e)
        {
            string ip_str = send_object_select_item.Text;
            if (ip_str == "")
            {
                MessageBox.Show("请选择发送对象！！！");
                return;
            }
            try
            {
                if (is_hex_send.Checked)//16进制发送
                {
                    byte[] Data = new byte[1];
                    for (int i = 0; i < (send_data_box.Text.Length - send_data_box.Text.Length % 2) / 2; i++)
                    {
                        string temp = send_data_box.Text.Substring(i * 2, 2);
                        Data[0] = Convert.ToByte(temp, 16);
                        dicsocket[ip_str].Send(Data);
                    }
                    if (send_data_box.Text.Length % 2 != 0)
                    {
                        //string temp = send_data_box.Text.Substring(send_data_box.Text.Length - 1, 1);
                        //Data = System.Text.Encoding.UTF8.GetBytes(temp);
                        Data[0] = Convert.ToByte(send_data_box.Text.Substring(send_data_box.Text.Length - 1, 1), 16);
                        dicsocket[ip_str].Send(Data);
                    }
                    string enter_key = "\r\n";
                    Data = System.Text.Encoding.UTF8.GetBytes(enter_key);
                    dicsocket[ip_str].Send(Data);
                }
                else//字符串发送
                {
                    string str = send_data_box.Text.Trim();
                    str += "\r\n";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                    dicsocket[ip_str].Send(buffer);
                }
            }
            catch
            {
                MessageBox.Show("数据发送失败！请检查发送格式");
            }
           
        }
        private void clear_receive_btn_Click(object sender, EventArgs e)
        {
            receive_data_box.Text = "";
        }
        private void clear_send_btn_Click(object sender, EventArgs e)
        {
            send_data_box.Text = "";
        }
        /// <summary>
        /// 清空绘图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plot_clear_btn_Click(object sender, EventArgs e)
        {
            datalist_I_basemotor1.Clear();
            datalist_I_basemotor2.Clear();
            datalist_I_basemotor3.Clear();
            datalist_I_basemotor4.Clear();
            datalist_I_ytmotoryaw.Clear();
            datalist_I_ytmotorpitch.Clear();
            datalist_I_bdmotor.Clear();
            datalist_I_mclmotor1.Clear();
            datalist_I_mclmotor2.Clear();

            datalist_speed_basemotor1.Clear();
            datalist_speed_basemotor2.Clear();
            datalist_speed_basemotor3.Clear();
            datalist_speed_basemotor4.Clear();
            datalist_speed_ytmotoryaw.Clear();
            datalist_speed_ytmotorpitch.Clear();
            datalist_speed_bdmotor.Clear();
            datalist_speed_mclmotor1.Clear();
            datalist_speed_mclmotor2.Clear();

            datalist_location_ytmotoryaw.Clear();
            datalist_location_ytmotorpitch.Clear();
            datalist_location_bdmotor.Clear();

            datalist_power_basemotor1.Clear();
            datalist_power_basemotor2.Clear();
            datalist_power_basemotor3.Clear();
            datalist_power_basemotor4.Clear();

            if (tabControl1.SelectedTab.Text.Equals("状态显示"))
            {
                Invalidate();
            }
        }

        /// <summary>
        /// pid参数发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pid_write_btn_Click(object sender, EventArgs e)
        {
            //读取PID数据
            byte[] pid_byte = new byte[12];
            Int32 kp = Convert.ToInt32(kp_value.Value * 1000);
            pid_byte[0] = (Byte)(kp >> 24);//高8位字节
            pid_byte[1] = (Byte)((kp << 8) >> 24);
            pid_byte[2] = (Byte)((kp << 16) >> 24);
            pid_byte[3] = (Byte)((kp << 24) >> 24);
            Int32 ki = Convert.ToInt32(ki_value.Value * 1000);
            pid_byte[4] = (Byte)(ki >> 24);//高8位字节
            pid_byte[5] = (Byte)((ki << 8) >> 24);
            pid_byte[6] = (Byte)((ki << 16) >> 24);
            pid_byte[7] = (Byte)((ki << 24) >> 24);
            Int32 kd = Convert.ToInt32(kd_value.Value * 1000);
            pid_byte[8] = (Byte)(kd >> 24);//高8位字节
            pid_byte[9] = (Byte)((kd << 8) >> 24);
            pid_byte[10] = (Byte)((kd << 16) >> 24);
            pid_byte[11] = (Byte)((kd << 24) >> 24);

            //数据包加载
            List<byte> datalist_pid = new List<byte>();//数据包
            //帧头
            datalist_pid.Add(0xff);
            datalist_pid.Add(0xff);
            //功能字
            if (is_motor1.Checked)
            {
                datalist_pid.Add(0x01);
                datalist_pid.Add(0x24);
            }
            else if (is_motor2.Checked)
            {
                datalist_pid.Add(0x02);
                datalist_pid.Add(0x24);
            }
            else if (is_motor3.Checked)
            {
                datalist_pid.Add(0x03);
                datalist_pid.Add(0x24);
            }
            else if (is_motor4.Checked)
            {
                datalist_pid.Add(0x04);
                datalist_pid.Add(0x24);
            }
            else if (is_motor_ytyaw.Checked)
            {
                datalist_pid.Add(0x05);
                datalist_pid.Add(0x24);
            }
            else if (is_motor_ytpitch.Checked)
            {
                datalist_pid.Add(0x06);
                datalist_pid.Add(0x24);
            }
            else if (is_bdmotor.Checked)
            {
                datalist_pid.Add(0x07);
                datalist_pid.Add(0x24);
            }
            else if (is_mclmotor1.Checked)
            {
                datalist_pid.Add(0x08);
                datalist_pid.Add(0x18);
            }
            else if (is_mclmotor2.Checked)
            {
                datalist_pid.Add(0x09);
                datalist_pid.Add(0x18);
            }
            //数据帧
            if (is_location_huan.Checked & (is_mclmotor1.Checked | is_mclmotor2.Checked))//错误检验
            {
                MessageBox.Show("摩擦轮电机没有位置环！！！", "错误");
                return;
            }


            if (is_I_huan.Checked)//电流环
            {
                for (int i = 0; i < 12; i++)
                {
                    datalist_pid.Add(pid_byte[i]);
                }
                if (is_mclmotor1.Checked | is_mclmotor2.Checked)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        datalist_pid.Add(0x00);
                    }
                }
                else
                {
                    for (int i = 0; i < 24; i++)
                    {
                        datalist_pid.Add(0x00);
                    }
                }
            }
            if (is_speed_huan.Checked)//速度环
            {
                for (int i = 0; i < 12; i++)
                {
                    datalist_pid.Add(0x00);
                }
                for (int i = 0; i < 12; i++)
                {
                    datalist_pid.Add(pid_byte[i]);
                }
                if (!(is_mclmotor1.Checked | is_mclmotor2.Checked))
                {
                    for (int i = 0; i < 12; i++)
                    {
                        datalist_pid.Add(0x00);
                    }
                }
            }
            if (is_location_huan.Checked & !(is_mclmotor1.Checked | is_mclmotor2.Checked))//位置环/功率环
            {
                for (int i = 0; i < 24; i++)
                {
                    datalist_pid.Add(0x00);
                }
                for (int i = 0; i < 12; i++)
                {
                    datalist_pid.Add(pid_byte[i]);
                }
            }
            //校验位
            byte sum_byte = new byte();
            for (int i = 0; i < datalist_pid.Count; i++)
            {
                sum_byte = (byte)(sum_byte + datalist_pid[i]);
            }
            datalist_pid.Add(sum_byte);


            string ip_str = send_object_select_item.Text;
            if (ip_str == "")
            {
                MessageBox.Show("请选择发送对象！！！");
                return;
            }
            //发送数据包
            byte[] Data = new byte[1];
            for (int i = 0; i < datalist_pid.Count; i++)
            {
                Data[0] = datalist_pid[i];
                dicsocket[ip_str].Send(Data);
            }
        }

        private void jia_btn_Click(object sender, EventArgs e)
        {
            if (drawstep > minstep)
                drawstep--;
            Invalidate();
        }
        private void jian_btn_Click(object sender, EventArgs e)
        {
            if (drawstep < maxstep)
                drawstep++;
            Invalidate();
        }

        private void is_motor1_CheckedChanged(object sender, EventArgs e)
        {
            if (is_motor1.Checked | is_motor2.Checked | is_motor3.Checked | is_motor4.Checked)
            {
                location_curve.Text = "功率曲线";
                is_location_huan.Text = "功率环";
            }
            else
            {
                location_curve.Text = "位置曲线";
                is_location_huan.Text = "位置环";
            }
        }
        private void is_motor2_CheckedChanged(object sender, EventArgs e)
        {
            if (is_motor1.Checked | is_motor2.Checked | is_motor3.Checked | is_motor4.Checked)
            {
                location_curve.Text = "功率曲线";
                is_location_huan.Text = "功率环";
            }
            else
            {
                location_curve.Text = "位置曲线";
                is_location_huan.Text = "位置环";
            }
        }
        private void is_motor3_CheckedChanged(object sender, EventArgs e)
        {
            if (is_motor1.Checked | is_motor2.Checked | is_motor3.Checked | is_motor4.Checked)
            {
                location_curve.Text = "功率曲线";
                is_location_huan.Text = "功率环";
            }
            else
            {
                location_curve.Text = "位置曲线";
                is_location_huan.Text = "位置环";
            }
        }
        private void is_motor4_CheckedChanged(object sender, EventArgs e)
        {
            if (is_motor1.Checked | is_motor2.Checked | is_motor3.Checked | is_motor4.Checked)
            {
                location_curve.Text = "功率曲线";
                is_location_huan.Text = "功率环";
            }
            else
            {
                location_curve.Text = "位置曲线";
                is_location_huan.Text = "位置环";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Equals("状态显示"))
            {
                Invalidate();
            }
            List<string> ip_str = new List<string>();
            foreach (var item in dicsocket_flag)
            {
                ip_str.Add(item.Key);
            }
            if (ip_str.Count > 0)
            {
                for (int i = 0; i < ip_str.Count; i++)
                {
                    int temp = dicsocket_flag[ip_str[i]] - 1;
                    //receive_data_box.AppendText(temp.ToString());
                    dicsocket_flag[ip_str[i]] = temp;

                    if (temp <= 2)
                    {
                        //关闭并清除Socket内存
                        dicsocket[ip_str[i]].Close();
                        dicsocket[ip_str[i]].Dispose();
                        //终止进程
                        Thread_flag[ip_str[i]].Abort();

                        //从集合中去除对应的IP地址
                        dicsocket.Remove(ip_str[i]);
                        dicsocket_flag.Remove(ip_str[i]);
                        //重写连入状态文本框及目标对象下拉框选项
                        link_state_box.Text = "";
                        send_object_select_item.Items.Clear();
                        foreach (var item in dicsocket)
                        {
                            link_state_box.AppendText(item.Key + "\r\n");
                            send_object_select_item.Items.Add(item.Key);
                        }
                        //若目标对象文本框中对象断开，则清空文本框
                        if (ip_str[i] == send_object_select_item.Text)
                        {
                            send_object_select_item.Text = "";
                        }
                    }
                }
            }
        }
    }
}
