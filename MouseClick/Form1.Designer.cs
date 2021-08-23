namespace MouseClick
{
    partial class FormMain
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
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonCapPos = new System.Windows.Forms.Button();
            this.timerGetCurpos = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerUpdateUi = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabelNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(26, 39);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 21);
            this.textBoxX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxX, "横坐标");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxInterval);
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "坐标与间隔";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(297, 39);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(100, 21);
            this.textBoxInterval.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxInterval, "时间间隔(s)");
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(164, 39);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 21);
            this.textBoxY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxY, "纵坐标");
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(106, 179);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(265, 179);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "结束";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonCapPos
            // 
            this.buttonCapPos.Location = new System.Drawing.Point(188, 130);
            this.buttonCapPos.Name = "buttonCapPos";
            this.buttonCapPos.Size = new System.Drawing.Size(75, 23);
            this.buttonCapPos.TabIndex = 4;
            this.buttonCapPos.Text = "获取坐标点";
            this.buttonCapPos.UseVisualStyleBackColor = true;
            this.buttonCapPos.Click += new System.EventHandler(this.buttonCapPos_Click);
            // 
            // timerGetCurpos
            // 
            this.timerGetCurpos.Tick += new System.EventHandler(this.timerGetCurpos_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelNum,
            this.toolStripStatusLabelMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(497, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelMain.Text = "就绪";
            // 
            // timerUpdateUi
            // 
            this.timerUpdateUi.Tick += new System.EventHandler(this.timerUpdateUi_Tick);
            // 
            // toolStripStatusLabelNum
            // 
            this.toolStripStatusLabelNum.Name = "toolStripStatusLabelNum";
            this.toolStripStatusLabelNum.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabelNum.Text = "   ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 381);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonCapPos);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "鼠标定时点击程序v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonCapPos;
        private System.Windows.Forms.Timer timerGetCurpos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMain;
        private System.Windows.Forms.Timer timerUpdateUi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNum;
    }
}

