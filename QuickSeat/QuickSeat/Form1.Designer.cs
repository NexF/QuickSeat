namespace QuickSeat
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labName = new System.Windows.Forms.Label();
            this.lstBuildings = new System.Windows.Forms.ListBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.lstData = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstStartT = new System.Windows.Forms.ComboBox();
            this.lstEndT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clkSearching = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(10, 13);
            this.labName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(55, 15);
            this.labName.TabIndex = 0;
            this.labName.Text = "label1";
            // 
            // lstBuildings
            // 
            this.lstBuildings.FormattingEnabled = true;
            this.lstBuildings.ItemHeight = 15;
            this.lstBuildings.Location = new System.Drawing.Point(12, 44);
            this.lstBuildings.Margin = new System.Windows.Forms.Padding(4);
            this.lstBuildings.Name = "lstBuildings";
            this.lstBuildings.Size = new System.Drawing.Size(119, 229);
            this.lstBuildings.TabIndex = 1;
            this.lstBuildings.SelectedIndexChanged += new System.EventHandler(this.lstBuildings_SelectedIndexChanged);
            // 
            // lstRooms
            // 
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.ItemHeight = 15;
            this.lstRooms.Location = new System.Drawing.Point(140, 44);
            this.lstRooms.Margin = new System.Windows.Forms.Padding(4);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(312, 229);
            this.lstRooms.TabIndex = 2;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(305, 13);
            this.lstData.Margin = new System.Windows.Forms.Padding(4);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(147, 23);
            this.lstData.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 370);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(441, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始随机选座";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstStartT
            // 
            this.lstStartT.FormattingEnabled = true;
            this.lstStartT.Items.AddRange(new object[] {
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30"});
            this.lstStartT.Location = new System.Drawing.Point(12, 281);
            this.lstStartT.Margin = new System.Windows.Forms.Padding(4);
            this.lstStartT.Name = "lstStartT";
            this.lstStartT.Size = new System.Drawing.Size(188, 23);
            this.lstStartT.TabIndex = 7;
            // 
            // lstEndT
            // 
            this.lstEndT.FormattingEnabled = true;
            this.lstEndT.Items.AddRange(new object[] {
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30",
            "24:00"});
            this.lstEndT.Location = new System.Drawing.Point(260, 281);
            this.lstEndT.Margin = new System.Windows.Forms.Padding(4);
            this.lstEndT.Name = "lstEndT";
            this.lstEndT.Size = new System.Drawing.Size(192, 23);
            this.lstEndT.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 284);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "to";
            // 
            // clkSearching
            // 
            this.clkSearching.Interval = 1000;
            this.clkSearching.Tick += new System.EventHandler(this.clkSearching_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(460, 13);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(440, 407);
            this.txtLog.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.timeStart);
            this.groupBox1.Location = new System.Drawing.Point(11, 311);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 49);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "定时抢座功能";
            // 
            // timeStart
            // 
            this.timeStart.Enabled = false;
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(326, 18);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(109, 25);
            this.timeStart.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(269, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "我想让程序在右侧时间过后开始抢座";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 433);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstEndT);
            this.Controls.Add(this.lstStartT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.lstRooms);
            this.Controls.Add(this.lstBuildings);
            this.Controls.Add(this.labName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "预约系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.ListBox lstBuildings;
        private System.Windows.Forms.ListBox lstRooms;
        private System.Windows.Forms.ComboBox lstData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox lstStartT;
        private System.Windows.Forms.ComboBox lstEndT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer clkSearching;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker timeStart;
    }
}

