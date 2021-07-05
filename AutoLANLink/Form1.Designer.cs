
namespace AutoLANLink
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rCheck_HZ = new System.Windows.Forms.RadioButton();
            this.rCheck_CJ = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rickMessage = new System.Windows.Forms.RichTextBox();
            this.back_CaiJi_Jieshou = new System.ComponentModel.BackgroundWorker();
            this.back_HuiZong_Fasong = new System.ComponentModel.BackgroundWorker();
            this.btn_Initialize = new System.Windows.Forms.Button();
            this.back_HuiZong_Jieshou = new System.ComponentModel.BackgroundWorker();
            this.timer_HZ_Jieshou = new System.Windows.Forms.Timer(this.components);
            this.timer_HZ_Fasong = new System.Windows.Forms.Timer(this.components);
            this.timer_CJ_Jieshou = new System.Windows.Forms.Timer(this.components);
            this.lab_ip = new System.Windows.Forms.Label();
            this.lab_ziwang = new System.Windows.Forms.Label();
            this.lab_wangguan = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "软件信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rCheck_CJ);
            this.groupBox2.Controls.Add(this.rCheck_HZ);
            this.groupBox2.Location = new System.Drawing.Point(16, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 55);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "笔记本类型";
            // 
            // rCheck_HZ
            // 
            this.rCheck_HZ.AutoSize = true;
            this.rCheck_HZ.Location = new System.Drawing.Point(23, 28);
            this.rCheck_HZ.Name = "rCheck_HZ";
            this.rCheck_HZ.Size = new System.Drawing.Size(62, 21);
            this.rCheck_HZ.TabIndex = 0;
            this.rCheck_HZ.TabStop = true;
            this.rCheck_HZ.Text = "汇总本";
            this.rCheck_HZ.UseVisualStyleBackColor = true;
            // 
            // rCheck_CJ
            // 
            this.rCheck_CJ.AutoSize = true;
            this.rCheck_CJ.Location = new System.Drawing.Point(105, 28);
            this.rCheck_CJ.Name = "rCheck_CJ";
            this.rCheck_CJ.Size = new System.Drawing.Size(62, 21);
            this.rCheck_CJ.TabIndex = 1;
            this.rCheck_CJ.TabStop = true;
            this.rCheck_CJ.Text = "采集本";
            this.rCheck_CJ.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lab_wangguan);
            this.groupBox3.Controls.Add(this.lab_ziwang);
            this.groupBox3.Controls.Add(this.lab_ip);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(19, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 190);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "网络信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "子网掩码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "网关：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rickMessage);
            this.groupBox4.Location = new System.Drawing.Point(299, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 371);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作输出详情";
            // 
            // rickMessage
            // 
            this.rickMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rickMessage.Location = new System.Drawing.Point(3, 19);
            this.rickMessage.Name = "rickMessage";
            this.rickMessage.Size = new System.Drawing.Size(371, 349);
            this.rickMessage.TabIndex = 0;
            this.rickMessage.Text = "";
            // 
            // back_CaiJi_Jieshou
            // 
            this.back_CaiJi_Jieshou.DoWork += new System.ComponentModel.DoWorkEventHandler(this.back_CaiJi_Jieshou_DoWork);
            this.back_CaiJi_Jieshou.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.back_CaiJi_Jieshou_RunWorkerCompleted);
            // 
            // back_HuiZong_Fasong
            // 
            this.back_HuiZong_Fasong.DoWork += new System.ComponentModel.DoWorkEventHandler(this.back_HuiZong_Fasong_DoWork);
            this.back_HuiZong_Fasong.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.back_HuiZong_Fasong_RunWorkerCompleted);
            // 
            // btn_Initialize
            // 
            this.btn_Initialize.Location = new System.Drawing.Point(21, 400);
            this.btn_Initialize.Name = "btn_Initialize";
            this.btn_Initialize.Size = new System.Drawing.Size(75, 30);
            this.btn_Initialize.TabIndex = 2;
            this.btn_Initialize.Text = "系统初始化";
            this.btn_Initialize.UseVisualStyleBackColor = true;
            this.btn_Initialize.Click += new System.EventHandler(this.btn_Initialize_Click);
            // 
            // back_HuiZong_Jieshou
            // 
            this.back_HuiZong_Jieshou.DoWork += new System.ComponentModel.DoWorkEventHandler(this.back_HuiZong_Jieshou_DoWork);
            this.back_HuiZong_Jieshou.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.back_HuiZong_Jieshou_RunWorkerCompleted);
            // 
            // timer_HZ_Jieshou
            // 
            this.timer_HZ_Jieshou.Interval = 1000;
            this.timer_HZ_Jieshou.Tick += new System.EventHandler(this.timer_HZ_Jieshou_Tick);
            // 
            // timer_HZ_Fasong
            // 
            this.timer_HZ_Fasong.Interval = 1000;
            this.timer_HZ_Fasong.Tick += new System.EventHandler(this.timer_HZ_FaSong_Tick);
            // 
            // timer_CJ_Jieshou
            // 
            this.timer_CJ_Jieshou.Interval = 1000;
            this.timer_CJ_Jieshou.Tick += new System.EventHandler(this.timer_CJ_JieShou_Tick);
            // 
            // lab_ip
            // 
            this.lab_ip.AutoSize = true;
            this.lab_ip.Location = new System.Drawing.Point(78, 36);
            this.lab_ip.Name = "lab_ip";
            this.lab_ip.Size = new System.Drawing.Size(43, 17);
            this.lab_ip.TabIndex = 3;
            this.lab_ip.Text = "label4";
            // 
            // lab_ziwang
            // 
            this.lab_ziwang.AutoSize = true;
            this.lab_ziwang.Location = new System.Drawing.Point(78, 89);
            this.lab_ziwang.Name = "lab_ziwang";
            this.lab_ziwang.Size = new System.Drawing.Size(43, 17);
            this.lab_ziwang.TabIndex = 4;
            this.lab_ziwang.Text = "label5";
            // 
            // lab_wangguan
            // 
            this.lab_wangguan.AutoSize = true;
            this.lab_wangguan.Location = new System.Drawing.Point(78, 140);
            this.lab_wangguan.Name = "lab_wangguan";
            this.lab_wangguan.Size = new System.Drawing.Size(43, 17);
            this.lab_wangguan.TabIndex = 5;
            this.lab_wangguan.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "暂停";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "汇总本最多链接数量：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(159, 318);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Initialize);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rCheck_HZ;
        private System.Windows.Forms.RadioButton rCheck_CJ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rickMessage;
        private System.ComponentModel.BackgroundWorker back_CaiJi_Jieshou;
        private System.ComponentModel.BackgroundWorker back_HuiZong_Fasong;
        private System.Windows.Forms.Button btn_Initialize;
        private System.ComponentModel.BackgroundWorker back_HuiZong_Jieshou;
        private System.Windows.Forms.Timer timer_HZ_Jieshou;
        private System.Windows.Forms.Timer timer_HZ_Fasong;
        private System.Windows.Forms.Timer timer_CJ_Jieshou;
        private System.Windows.Forms.Label lab_wangguan;
        private System.Windows.Forms.Label lab_ziwang;
        private System.Windows.Forms.Label lab_ip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

