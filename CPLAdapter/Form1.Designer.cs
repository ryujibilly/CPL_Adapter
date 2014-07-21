namespace CPL_Adapter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.ComboBox();
            this.txtBaud = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDaqIP = new System.Windows.Forms.TextBox();
            this.txtDaqPort = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGlasPort = new System.Windows.Forms.TextBox();
            this.txtGlasIP = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_TEST = new System.Windows.Forms.Button();
            this.btn_GOON = new System.Windows.Forms.Button();
            this.btn_SEND = new System.Windows.Forms.Button();
            this.btn_RE = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtBaud);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(265, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // txtPort
            // 
            this.txtPort.FormatString = "COM1";
            this.txtPort.FormattingEnabled = true;
            this.txtPort.Location = new System.Drawing.Point(100, 31);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(132, 23);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "COM1";
            this.txtPort.SelectedIndexChanged += new System.EventHandler(this.txtPort_SelectedIndexChanged);
            // 
            // txtBaud
            // 
            this.txtBaud.Location = new System.Drawing.Point(100, 78);
            this.txtBaud.Margin = new System.Windows.Forms.Padding(4);
            this.txtBaud.Name = "txtBaud";
            this.txtBaud.Size = new System.Drawing.Size(132, 25);
            this.txtBaud.TabIndex = 3;
            this.txtBaud.Text = "115200";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "波特率:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "串口号：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 27);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDaqIP);
            this.groupBox2.Controls.Add(this.txtDaqPort);
            this.groupBox2.Location = new System.Drawing.Point(289, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(265, 110);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "适配器网络设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "本地网络端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "本地网络IP：";
            // 
            // txtDaqIP
            // 
            this.txtDaqIP.Location = new System.Drawing.Point(127, 27);
            this.txtDaqIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtDaqIP.Name = "txtDaqIP";
            this.txtDaqIP.Size = new System.Drawing.Size(121, 25);
            this.txtDaqIP.TabIndex = 3;
            this.txtDaqIP.Text = "127.0.0.1";
            // 
            // txtDaqPort
            // 
            this.txtDaqPort.Location = new System.Drawing.Point(127, 61);
            this.txtDaqPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtDaqPort.Name = "txtDaqPort";
            this.txtDaqPort.Size = new System.Drawing.Size(121, 25);
            this.txtDaqPort.TabIndex = 3;
            this.txtDaqPort.Text = "3000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtGlasPort);
            this.groupBox3.Controls.Add(this.txtGlasIP);
            this.groupBox3.Location = new System.Drawing.Point(16, 133);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(265, 110);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GLAS网络设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Glas网络端口：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Glas网络IP：";
            // 
            // txtGlasPort
            // 
            this.txtGlasPort.Location = new System.Drawing.Point(127, 64);
            this.txtGlasPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtGlasPort.Name = "txtGlasPort";
            this.txtGlasPort.Size = new System.Drawing.Size(121, 25);
            this.txtGlasPort.TabIndex = 3;
            this.txtGlasPort.Text = "3001";
            // 
            // txtGlasIP
            // 
            this.txtGlasIP.Location = new System.Drawing.Point(127, 30);
            this.txtGlasIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtGlasIP.Name = "txtGlasIP";
            this.txtGlasIP.Size = new System.Drawing.Size(121, 25);
            this.txtGlasIP.TabIndex = 3;
            this.txtGlasIP.Text = "10.242.100.83";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(137, 27);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 29);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(63, 251);
            this.txtSave.Margin = new System.Windows.Forms.Padding(4);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(159, 29);
            this.txtSave.TabIndex = 2;
            this.txtSave.Text = "保存配置信息";
            this.txtSave.UseVisualStyleBackColor = true;
            this.txtSave.Click += new System.EventHandler(this.txtSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 307);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(412, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "说明：如果配置信息有改变，先保存配置信息后点击开始按钮";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_TEST);
            this.groupBox4.Controls.Add(this.btn_GOON);
            this.groupBox4.Controls.Add(this.btn_SEND);
            this.groupBox4.Controls.Add(this.btn_RE);
            this.groupBox4.Controls.Add(this.btnStart);
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Location = new System.Drawing.Point(289, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(265, 147);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据采集";
            // 
            // btn_TEST
            // 
            this.btn_TEST.Location = new System.Drawing.Point(138, 101);
            this.btn_TEST.Name = "btn_TEST";
            this.btn_TEST.Size = new System.Drawing.Size(121, 32);
            this.btn_TEST.TabIndex = 6;
            this.btn_TEST.Text = "测试、版本号";
            this.btn_TEST.UseVisualStyleBackColor = true;
            this.btn_TEST.Click += new System.EventHandler(this.btn_TEST_Click);
            // 
            // btn_GOON
            // 
            this.btn_GOON.Location = new System.Drawing.Point(137, 63);
            this.btn_GOON.Name = "btn_GOON";
            this.btn_GOON.Size = new System.Drawing.Size(121, 32);
            this.btn_GOON.TabIndex = 5;
            this.btn_GOON.Text = "续发";
            this.btn_GOON.UseVisualStyleBackColor = true;
            this.btn_GOON.Click += new System.EventHandler(this.btn_GOON_Click);
            // 
            // btn_SEND
            // 
            this.btn_SEND.Location = new System.Drawing.Point(11, 101);
            this.btn_SEND.Name = "btn_SEND";
            this.btn_SEND.Size = new System.Drawing.Size(121, 32);
            this.btn_SEND.TabIndex = 4;
            this.btn_SEND.Text = "连续发送";
            this.btn_SEND.UseVisualStyleBackColor = true;
            this.btn_SEND.Click += new System.EventHandler(this.btn_SEND_Click);
            // 
            // btn_RE
            // 
            this.btn_RE.Location = new System.Drawing.Point(11, 63);
            this.btn_RE.Name = "btn_RE";
            this.btn_RE.Size = new System.Drawing.Size(121, 32);
            this.btn_RE.TabIndex = 3;
            this.btn_RE.Text = "重发";
            this.btn_RE.UseVisualStyleBackColor = true;
            this.btn_RE.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 347);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DAQ-GLAS 适配器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGlasPort;
        private System.Windows.Forms.TextBox txtGlasIP;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDaqPort;
        private System.Windows.Forms.TextBox txtDaqIP;
        private System.Windows.Forms.Button txtSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtPort;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_RE;
        private System.Windows.Forms.Button btn_TEST;
        private System.Windows.Forms.Button btn_GOON;
        private System.Windows.Forms.Button btn_SEND;
    }
}

