namespace 上位机
{
    partial class 上位机
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clear_receive_btn = new System.Windows.Forms.Button();
            this.clear_send_btn = new System.Windows.Forms.Button();
            this.send_data_btn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.send_data_box = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.receive_data_box = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.plot_clear_btn = new System.Windows.Forms.Button();
            this.location_curve = new System.Windows.Forms.Label();
            this.speed_curve = new System.Windows.Forms.Label();
            this.I_curve = new System.Windows.Forms.Label();
            this.location_plot = new System.Windows.Forms.PictureBox();
            this.speed_plot = new System.Windows.Forms.PictureBox();
            this.I_plot = new System.Windows.Forms.PictureBox();
            this.jian_btn = new System.Windows.Forms.Button();
            this.jia_btn = new System.Windows.Forms.Button();
            this.pid_write_btn = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.kd_value = new System.Windows.Forms.NumericUpDown();
            this.ki_value = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kp_value = new System.Windows.Forms.NumericUpDown();
            this.闭环控制 = new System.Windows.Forms.GroupBox();
            this.is_location_huan = new System.Windows.Forms.RadioButton();
            this.is_speed_huan = new System.Windows.Forms.RadioButton();
            this.is_I_huan = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.is_mclmotor2 = new System.Windows.Forms.RadioButton();
            this.is_mclmotor1 = new System.Windows.Forms.RadioButton();
            this.is_bdmotor = new System.Windows.Forms.RadioButton();
            this.is_motor_ytpitch = new System.Windows.Forms.RadioButton();
            this.is_motor_ytyaw = new System.Windows.Forms.RadioButton();
            this.is_motor4 = new System.Windows.Forms.RadioButton();
            this.is_motor3 = new System.Windows.Forms.RadioButton();
            this.is_motor2 = new System.Windows.Forms.RadioButton();
            this.is_motor1 = new System.Windows.Forms.RadioButton();
            this.wangluopeizhi = new System.Windows.Forms.GroupBox();
            this.local_ip_address_box = new System.Windows.Forms.TextBox();
            this.link_bind_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.link_state_box = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.send_object_select_item = new System.Windows.Forms.ComboBox();
            this.接收显示 = new System.Windows.Forms.GroupBox();
            this.is_string_show = new System.Windows.Forms.RadioButton();
            this.is_hex_show = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.is_string_send = new System.Windows.Forms.RadioButton();
            this.is_hex_send = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.location_plot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_plot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_plot)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kd_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ki_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kp_value)).BeginInit();
            this.闭环控制.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.wangluopeizhi.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.接收显示.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(819, 742);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.clear_receive_btn);
            this.tabPage1.Controls.Add(this.clear_send_btn);
            this.tabPage1.Controls.Add(this.send_data_btn);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 716);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据基本收发";
            // 
            // clear_receive_btn
            // 
            this.clear_receive_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clear_receive_btn.Location = new System.Drawing.Point(176, 659);
            this.clear_receive_btn.Name = "clear_receive_btn";
            this.clear_receive_btn.Size = new System.Drawing.Size(87, 35);
            this.clear_receive_btn.TabIndex = 4;
            this.clear_receive_btn.Text = "清空接收区";
            this.clear_receive_btn.UseVisualStyleBackColor = true;
            this.clear_receive_btn.Click += new System.EventHandler(this.clear_receive_btn_Click);
            // 
            // clear_send_btn
            // 
            this.clear_send_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clear_send_btn.Location = new System.Drawing.Point(341, 659);
            this.clear_send_btn.Name = "clear_send_btn";
            this.clear_send_btn.Size = new System.Drawing.Size(87, 35);
            this.clear_send_btn.TabIndex = 3;
            this.clear_send_btn.Text = "清空发送区";
            this.clear_send_btn.UseVisualStyleBackColor = true;
            this.clear_send_btn.Click += new System.EventHandler(this.clear_send_btn_Click);
            // 
            // send_data_btn
            // 
            this.send_data_btn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.send_data_btn.Location = new System.Drawing.Point(498, 659);
            this.send_data_btn.Name = "send_data_btn";
            this.send_data_btn.Size = new System.Drawing.Size(87, 35);
            this.send_data_btn.TabIndex = 2;
            this.send_data_btn.Text = "数据发送";
            this.send_data_btn.UseVisualStyleBackColor = true;
            this.send_data_btn.Click += new System.EventHandler(this.send_data_btn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.send_data_box);
            this.groupBox2.Location = new System.Drawing.Point(11, 391);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 252);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据发送";
            // 
            // send_data_box
            // 
            this.send_data_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.send_data_box.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.send_data_box.Location = new System.Drawing.Point(12, 20);
            this.send_data_box.Multiline = true;
            this.send_data_box.Name = "send_data_box";
            this.send_data_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.send_data_box.Size = new System.Drawing.Size(763, 216);
            this.send_data_box.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.receive_data_box);
            this.groupBox1.Location = new System.Drawing.Point(11, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据接收";
            // 
            // receive_data_box
            // 
            this.receive_data_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.receive_data_box.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.receive_data_box.Location = new System.Drawing.Point(12, 20);
            this.receive_data_box.Multiline = true;
            this.receive_data_box.Name = "receive_data_box";
            this.receive_data_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receive_data_box.Size = new System.Drawing.Size(763, 323);
            this.receive_data_box.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.plot_clear_btn);
            this.tabPage2.Controls.Add(this.location_curve);
            this.tabPage2.Controls.Add(this.speed_curve);
            this.tabPage2.Controls.Add(this.I_curve);
            this.tabPage2.Controls.Add(this.location_plot);
            this.tabPage2.Controls.Add(this.speed_plot);
            this.tabPage2.Controls.Add(this.I_plot);
            this.tabPage2.Controls.Add(this.jian_btn);
            this.tabPage2.Controls.Add(this.jia_btn);
            this.tabPage2.Controls.Add(this.pid_write_btn);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.闭环控制);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(811, 716);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "状态显示";
            // 
            // plot_clear_btn
            // 
            this.plot_clear_btn.Location = new System.Drawing.Point(600, 66);
            this.plot_clear_btn.Name = "plot_clear_btn";
            this.plot_clear_btn.Size = new System.Drawing.Size(75, 23);
            this.plot_clear_btn.TabIndex = 15;
            this.plot_clear_btn.Text = "清除显示";
            this.plot_clear_btn.UseVisualStyleBackColor = true;
            this.plot_clear_btn.Click += new System.EventHandler(this.plot_clear_btn_Click);
            // 
            // location_curve
            // 
            this.location_curve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.location_curve.AutoSize = true;
            this.location_curve.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.location_curve.Location = new System.Drawing.Point(335, 506);
            this.location_curve.Name = "location_curve";
            this.location_curve.Size = new System.Drawing.Size(76, 16);
            this.location_curve.TabIndex = 14;
            this.location_curve.Text = "功率曲线";
            // 
            // speed_curve
            // 
            this.speed_curve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speed_curve.AutoSize = true;
            this.speed_curve.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.speed_curve.Location = new System.Drawing.Point(335, 302);
            this.speed_curve.Name = "speed_curve";
            this.speed_curve.Size = new System.Drawing.Size(76, 16);
            this.speed_curve.TabIndex = 13;
            this.speed_curve.Text = "速度曲线";
            // 
            // I_curve
            // 
            this.I_curve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.I_curve.AutoSize = true;
            this.I_curve.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.I_curve.Location = new System.Drawing.Point(335, 99);
            this.I_curve.Name = "I_curve";
            this.I_curve.Size = new System.Drawing.Size(76, 16);
            this.I_curve.TabIndex = 12;
            this.I_curve.Text = "电流曲线";
            // 
            // location_plot
            // 
            this.location_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.location_plot.BackColor = System.Drawing.Color.LightGray;
            this.location_plot.Location = new System.Drawing.Point(8, 530);
            this.location_plot.Name = "location_plot";
            this.location_plot.Size = new System.Drawing.Size(800, 180);
            this.location_plot.TabIndex = 11;
            this.location_plot.TabStop = false;
            // 
            // speed_plot
            // 
            this.speed_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.speed_plot.BackColor = System.Drawing.Color.LightGray;
            this.speed_plot.Location = new System.Drawing.Point(7, 323);
            this.speed_plot.Name = "speed_plot";
            this.speed_plot.Size = new System.Drawing.Size(800, 180);
            this.speed_plot.TabIndex = 10;
            this.speed_plot.TabStop = false;
            // 
            // I_plot
            // 
            this.I_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.I_plot.BackColor = System.Drawing.Color.LightGray;
            this.I_plot.Location = new System.Drawing.Point(8, 118);
            this.I_plot.Name = "I_plot";
            this.I_plot.Size = new System.Drawing.Size(800, 180);
            this.I_plot.TabIndex = 9;
            this.I_plot.TabStop = false;
            // 
            // jian_btn
            // 
            this.jian_btn.Location = new System.Drawing.Point(696, 66);
            this.jian_btn.Name = "jian_btn";
            this.jian_btn.Size = new System.Drawing.Size(40, 23);
            this.jian_btn.TabIndex = 8;
            this.jian_btn.Text = "-";
            this.jian_btn.UseVisualStyleBackColor = true;
            this.jian_btn.Click += new System.EventHandler(this.jian_btn_Click);
            // 
            // jia_btn
            // 
            this.jia_btn.Location = new System.Drawing.Point(696, 27);
            this.jia_btn.Name = "jia_btn";
            this.jia_btn.Size = new System.Drawing.Size(40, 23);
            this.jia_btn.TabIndex = 6;
            this.jia_btn.Text = "+";
            this.jia_btn.UseVisualStyleBackColor = true;
            this.jia_btn.Click += new System.EventHandler(this.jia_btn_Click);
            // 
            // pid_write_btn
            // 
            this.pid_write_btn.Location = new System.Drawing.Point(600, 27);
            this.pid_write_btn.Name = "pid_write_btn";
            this.pid_write_btn.Size = new System.Drawing.Size(75, 23);
            this.pid_write_btn.TabIndex = 5;
            this.pid_write_btn.Text = "PID写入";
            this.pid_write_btn.UseVisualStyleBackColor = true;
            this.pid_write_btn.Click += new System.EventHandler(this.pid_write_btn_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.kd_value);
            this.groupBox7.Controls.Add(this.ki_value);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.kp_value);
            this.groupBox7.Location = new System.Drawing.Point(461, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(124, 88);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "PID调参";
            // 
            // kd_value
            // 
            this.kd_value.DecimalPlaces = 3;
            this.kd_value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kd_value.Location = new System.Drawing.Point(43, 64);
            this.kd_value.Name = "kd_value";
            this.kd_value.Size = new System.Drawing.Size(61, 21);
            this.kd_value.TabIndex = 8;
            // 
            // ki_value
            // 
            this.ki_value.DecimalPlaces = 3;
            this.ki_value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ki_value.Location = new System.Drawing.Point(43, 39);
            this.ki_value.Name = "ki_value";
            this.ki_value.Size = new System.Drawing.Size(61, 21);
            this.ki_value.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ki";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kp";
            // 
            // kp_value
            // 
            this.kp_value.DecimalPlaces = 3;
            this.kp_value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kp_value.Location = new System.Drawing.Point(43, 13);
            this.kp_value.Name = "kp_value";
            this.kp_value.Size = new System.Drawing.Size(61, 21);
            this.kp_value.TabIndex = 3;
            // 
            // 闭环控制
            // 
            this.闭环控制.Controls.Add(this.is_location_huan);
            this.闭环控制.Controls.Add(this.is_speed_huan);
            this.闭环控制.Controls.Add(this.is_I_huan);
            this.闭环控制.Location = new System.Drawing.Point(341, 6);
            this.闭环控制.Name = "闭环控制";
            this.闭环控制.Size = new System.Drawing.Size(98, 88);
            this.闭环控制.TabIndex = 1;
            this.闭环控制.TabStop = false;
            this.闭环控制.Text = "闭环控制";
            // 
            // is_location_huan
            // 
            this.is_location_huan.AutoSize = true;
            this.is_location_huan.Location = new System.Drawing.Point(17, 67);
            this.is_location_huan.Name = "is_location_huan";
            this.is_location_huan.Size = new System.Drawing.Size(59, 16);
            this.is_location_huan.TabIndex = 2;
            this.is_location_huan.TabStop = true;
            this.is_location_huan.Text = "功率环";
            this.is_location_huan.UseVisualStyleBackColor = true;
            // 
            // is_speed_huan
            // 
            this.is_speed_huan.AutoSize = true;
            this.is_speed_huan.Location = new System.Drawing.Point(17, 44);
            this.is_speed_huan.Name = "is_speed_huan";
            this.is_speed_huan.Size = new System.Drawing.Size(59, 16);
            this.is_speed_huan.TabIndex = 1;
            this.is_speed_huan.TabStop = true;
            this.is_speed_huan.Text = "速度环";
            this.is_speed_huan.UseVisualStyleBackColor = true;
            // 
            // is_I_huan
            // 
            this.is_I_huan.AutoSize = true;
            this.is_I_huan.Location = new System.Drawing.Point(17, 21);
            this.is_I_huan.Name = "is_I_huan";
            this.is_I_huan.Size = new System.Drawing.Size(59, 16);
            this.is_I_huan.TabIndex = 0;
            this.is_I_huan.TabStop = true;
            this.is_I_huan.Text = "电流环";
            this.is_I_huan.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.is_mclmotor2);
            this.groupBox6.Controls.Add(this.is_mclmotor1);
            this.groupBox6.Controls.Add(this.is_bdmotor);
            this.groupBox6.Controls.Add(this.is_motor_ytpitch);
            this.groupBox6.Controls.Add(this.is_motor_ytyaw);
            this.groupBox6.Controls.Add(this.is_motor4);
            this.groupBox6.Controls.Add(this.is_motor3);
            this.groupBox6.Controls.Add(this.is_motor2);
            this.groupBox6.Controls.Add(this.is_motor1);
            this.groupBox6.Location = new System.Drawing.Point(14, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(309, 88);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "电机选择";
            // 
            // is_mclmotor2
            // 
            this.is_mclmotor2.AutoSize = true;
            this.is_mclmotor2.Location = new System.Drawing.Point(210, 67);
            this.is_mclmotor2.Name = "is_mclmotor2";
            this.is_mclmotor2.Size = new System.Drawing.Size(89, 16);
            this.is_mclmotor2.TabIndex = 8;
            this.is_mclmotor2.TabStop = true;
            this.is_mclmotor2.Text = "摩擦轮电机2";
            this.is_mclmotor2.UseVisualStyleBackColor = true;
            // 
            // is_mclmotor1
            // 
            this.is_mclmotor1.AutoSize = true;
            this.is_mclmotor1.Location = new System.Drawing.Point(212, 44);
            this.is_mclmotor1.Name = "is_mclmotor1";
            this.is_mclmotor1.Size = new System.Drawing.Size(89, 16);
            this.is_mclmotor1.TabIndex = 7;
            this.is_mclmotor1.TabStop = true;
            this.is_mclmotor1.Text = "摩擦轮电机1";
            this.is_mclmotor1.UseVisualStyleBackColor = true;
            // 
            // is_bdmotor
            // 
            this.is_bdmotor.AutoSize = true;
            this.is_bdmotor.Location = new System.Drawing.Point(212, 21);
            this.is_bdmotor.Name = "is_bdmotor";
            this.is_bdmotor.Size = new System.Drawing.Size(71, 16);
            this.is_bdmotor.TabIndex = 6;
            this.is_bdmotor.TabStop = true;
            this.is_bdmotor.Text = "拨弹电机";
            this.is_bdmotor.UseVisualStyleBackColor = true;
            // 
            // is_motor_ytpitch
            // 
            this.is_motor_ytpitch.AutoSize = true;
            this.is_motor_ytpitch.Location = new System.Drawing.Point(102, 67);
            this.is_motor_ytpitch.Name = "is_motor_ytpitch";
            this.is_motor_ytpitch.Size = new System.Drawing.Size(101, 16);
            this.is_motor_ytpitch.TabIndex = 5;
            this.is_motor_ytpitch.TabStop = true;
            this.is_motor_ytpitch.Text = "云台电机PITCH";
            this.is_motor_ytpitch.UseVisualStyleBackColor = true;
            // 
            // is_motor_ytyaw
            // 
            this.is_motor_ytyaw.AutoSize = true;
            this.is_motor_ytyaw.Location = new System.Drawing.Point(102, 43);
            this.is_motor_ytyaw.Name = "is_motor_ytyaw";
            this.is_motor_ytyaw.Size = new System.Drawing.Size(89, 16);
            this.is_motor_ytyaw.TabIndex = 4;
            this.is_motor_ytyaw.TabStop = true;
            this.is_motor_ytyaw.Text = "云台电机YAW";
            this.is_motor_ytyaw.UseVisualStyleBackColor = true;
            // 
            // is_motor4
            // 
            this.is_motor4.AutoSize = true;
            this.is_motor4.Location = new System.Drawing.Point(102, 21);
            this.is_motor4.Name = "is_motor4";
            this.is_motor4.Size = new System.Drawing.Size(77, 16);
            this.is_motor4.TabIndex = 3;
            this.is_motor4.TabStop = true;
            this.is_motor4.Text = "底盘电机4";
            this.is_motor4.UseVisualStyleBackColor = true;
            this.is_motor4.CheckedChanged += new System.EventHandler(this.is_motor4_CheckedChanged);
            // 
            // is_motor3
            // 
            this.is_motor3.AutoSize = true;
            this.is_motor3.Location = new System.Drawing.Point(7, 67);
            this.is_motor3.Name = "is_motor3";
            this.is_motor3.Size = new System.Drawing.Size(77, 16);
            this.is_motor3.TabIndex = 2;
            this.is_motor3.TabStop = true;
            this.is_motor3.Text = "底盘电机3";
            this.is_motor3.UseVisualStyleBackColor = true;
            this.is_motor3.CheckedChanged += new System.EventHandler(this.is_motor3_CheckedChanged);
            // 
            // is_motor2
            // 
            this.is_motor2.AutoSize = true;
            this.is_motor2.Location = new System.Drawing.Point(7, 44);
            this.is_motor2.Name = "is_motor2";
            this.is_motor2.Size = new System.Drawing.Size(77, 16);
            this.is_motor2.TabIndex = 1;
            this.is_motor2.TabStop = true;
            this.is_motor2.Text = "底盘电机2";
            this.is_motor2.UseVisualStyleBackColor = true;
            this.is_motor2.CheckedChanged += new System.EventHandler(this.is_motor2_CheckedChanged);
            // 
            // is_motor1
            // 
            this.is_motor1.AutoSize = true;
            this.is_motor1.Location = new System.Drawing.Point(7, 21);
            this.is_motor1.Name = "is_motor1";
            this.is_motor1.Size = new System.Drawing.Size(77, 16);
            this.is_motor1.TabIndex = 0;
            this.is_motor1.TabStop = true;
            this.is_motor1.Text = "底盘电机1";
            this.is_motor1.UseVisualStyleBackColor = true;
            this.is_motor1.CheckedChanged += new System.EventHandler(this.is_motor1_CheckedChanged);
            // 
            // wangluopeizhi
            // 
            this.wangluopeizhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wangluopeizhi.Controls.Add(this.local_ip_address_box);
            this.wangluopeizhi.Location = new System.Drawing.Point(840, 24);
            this.wangluopeizhi.Name = "wangluopeizhi";
            this.wangluopeizhi.Size = new System.Drawing.Size(204, 64);
            this.wangluopeizhi.TabIndex = 2;
            this.wangluopeizhi.TabStop = false;
            this.wangluopeizhi.Text = "本机IP地址";
            // 
            // local_ip_address_box
            // 
            this.local_ip_address_box.Location = new System.Drawing.Point(21, 25);
            this.local_ip_address_box.Name = "local_ip_address_box";
            this.local_ip_address_box.Size = new System.Drawing.Size(159, 21);
            this.local_ip_address_box.TabIndex = 0;
            // 
            // link_bind_btn
            // 
            this.link_bind_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_bind_btn.Location = new System.Drawing.Point(899, 109);
            this.link_bind_btn.Name = "link_bind_btn";
            this.link_bind_btn.Size = new System.Drawing.Size(83, 28);
            this.link_bind_btn.TabIndex = 7;
            this.link_bind_btn.Text = "创建服务端";
            this.link_bind_btn.UseVisualStyleBackColor = true;
            this.link_bind_btn.Click += new System.EventHandler(this.link_bind_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.link_state_box);
            this.groupBox3.Location = new System.Drawing.Point(841, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 172);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "目前连入状态";
            // 
            // link_state_box
            // 
            this.link_state_box.Location = new System.Drawing.Point(20, 21);
            this.link_state_box.Multiline = true;
            this.link_state_box.Name = "link_state_box";
            this.link_state_box.Size = new System.Drawing.Size(166, 134);
            this.link_state_box.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.send_object_select_item);
            this.groupBox4.Location = new System.Drawing.Point(840, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 73);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "目标对象";
            // 
            // send_object_select_item
            // 
            this.send_object_select_item.FormattingEnabled = true;
            this.send_object_select_item.Location = new System.Drawing.Point(20, 32);
            this.send_object_select_item.Name = "send_object_select_item";
            this.send_object_select_item.Size = new System.Drawing.Size(159, 20);
            this.send_object_select_item.TabIndex = 0;
            // 
            // 接收显示
            // 
            this.接收显示.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.接收显示.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.接收显示.Controls.Add(this.is_string_show);
            this.接收显示.Controls.Add(this.is_hex_show);
            this.接收显示.Location = new System.Drawing.Point(840, 491);
            this.接收显示.Name = "接收显示";
            this.接收显示.Size = new System.Drawing.Size(204, 90);
            this.接收显示.TabIndex = 6;
            this.接收显示.TabStop = false;
            this.接收显示.Text = "接收显示";
            // 
            // is_string_show
            // 
            this.is_string_show.AutoSize = true;
            this.is_string_show.Location = new System.Drawing.Point(49, 60);
            this.is_string_show.Name = "is_string_show";
            this.is_string_show.Size = new System.Drawing.Size(83, 16);
            this.is_string_show.TabIndex = 1;
            this.is_string_show.TabStop = true;
            this.is_string_show.Text = "字符串显示";
            this.is_string_show.UseVisualStyleBackColor = true;
            // 
            // is_hex_show
            // 
            this.is_hex_show.AutoSize = true;
            this.is_hex_show.Location = new System.Drawing.Point(49, 29);
            this.is_hex_show.Name = "is_hex_show";
            this.is_hex_show.Size = new System.Drawing.Size(107, 16);
            this.is_hex_show.TabIndex = 0;
            this.is_hex_show.TabStop = true;
            this.is_hex_show.Text = "16进制数值显示";
            this.is_hex_show.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.is_string_send);
            this.groupBox5.Controls.Add(this.is_hex_send);
            this.groupBox5.Location = new System.Drawing.Point(841, 633);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 94);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送格式";
            // 
            // is_string_send
            // 
            this.is_string_send.AutoSize = true;
            this.is_string_send.Location = new System.Drawing.Point(49, 59);
            this.is_string_send.Name = "is_string_send";
            this.is_string_send.Size = new System.Drawing.Size(83, 16);
            this.is_string_send.TabIndex = 1;
            this.is_string_send.TabStop = true;
            this.is_string_send.Text = "字符串发送";
            this.is_string_send.UseVisualStyleBackColor = true;
            // 
            // is_hex_send
            // 
            this.is_hex_send.AutoSize = true;
            this.is_hex_send.Location = new System.Drawing.Point(49, 27);
            this.is_hex_send.Name = "is_hex_send";
            this.is_hex_send.Size = new System.Drawing.Size(107, 16);
            this.is_hex_send.TabIndex = 0;
            this.is_hex_send.TabStop = true;
            this.is_hex_send.Text = "16进制数值发送";
            this.is_hex_send.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 上位机
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1063, 742);
            this.Controls.Add(this.link_bind_btn);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.接收显示);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.wangluopeizhi);
            this.Controls.Add(this.tabControl1);
            this.Name = "上位机";
            this.Text = "上位机_XJTU_RM";
            this.Load += new System.EventHandler(this.上位机_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.上位机_Paint);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.location_plot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_plot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I_plot)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kd_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ki_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kp_value)).EndInit();
            this.闭环控制.ResumeLayout(false);
            this.闭环控制.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.wangluopeizhi.ResumeLayout(false);
            this.wangluopeizhi.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.接收显示.ResumeLayout(false);
            this.接收显示.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox send_data_box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox receive_data_box;
        private System.Windows.Forms.Button clear_receive_btn;
        private System.Windows.Forms.Button clear_send_btn;
        private System.Windows.Forms.Button send_data_btn;
        private System.Windows.Forms.GroupBox wangluopeizhi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox link_state_box;
        private System.Windows.Forms.TextBox local_ip_address_box;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox send_object_select_item;
        private System.Windows.Forms.GroupBox 接收显示;
        private System.Windows.Forms.RadioButton is_string_show;
        private System.Windows.Forms.RadioButton is_hex_show;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton is_string_send;
        private System.Windows.Forms.RadioButton is_hex_send;
        private System.Windows.Forms.Button link_bind_btn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton is_motor_ytpitch;
        private System.Windows.Forms.RadioButton is_motor_ytyaw;
        private System.Windows.Forms.RadioButton is_motor4;
        private System.Windows.Forms.RadioButton is_motor3;
        private System.Windows.Forms.RadioButton is_motor2;
        private System.Windows.Forms.RadioButton is_motor1;
        private System.Windows.Forms.GroupBox 闭环控制;
        private System.Windows.Forms.RadioButton is_I_huan;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown kd_value;
        private System.Windows.Forms.NumericUpDown ki_value;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown kp_value;
        private System.Windows.Forms.RadioButton is_location_huan;
        private System.Windows.Forms.RadioButton is_speed_huan;
        private System.Windows.Forms.Button pid_write_btn;
        private System.Windows.Forms.Button jian_btn;
        private System.Windows.Forms.Button jia_btn;
        private System.Windows.Forms.Label location_curve;
        private System.Windows.Forms.Label speed_curve;
        private System.Windows.Forms.Label I_curve;
        private System.Windows.Forms.PictureBox location_plot;
        private System.Windows.Forms.PictureBox speed_plot;
        private System.Windows.Forms.PictureBox I_plot;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton is_mclmotor2;
        private System.Windows.Forms.RadioButton is_mclmotor1;
        private System.Windows.Forms.RadioButton is_bdmotor;
        private System.Windows.Forms.Button plot_clear_btn;
    }
}

