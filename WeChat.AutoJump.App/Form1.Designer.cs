namespace WeChat.AutoJump.App
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
            this.AutoTimer = new System.Windows.Forms.Timer(this.components);
            this.mainImg = new Emgu.CV.UI.ImageBox();
            this.txtConst = new System.Windows.Forms.TextBox();
            this.labConst = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartX = new System.Windows.Forms.TextBox();
            this.txtStartY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndY = new System.Windows.Forms.TextBox();
            this.txtEndX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).BeginInit();
            this.SuspendLayout();
            // 
            // AutoTimer
            // 
            this.AutoTimer.Tick += new System.EventHandler(this.AutoTimer_Tick);
            // 
            // mainImg
            // 
            this.mainImg.Location = new System.Drawing.Point(12, 12);
            this.mainImg.Name = "mainImg";
            this.mainImg.Size = new System.Drawing.Size(375, 667);
            this.mainImg.TabIndex = 2;
            this.mainImg.TabStop = false;
            // 
            // txtConst
            // 
            this.txtConst.Location = new System.Drawing.Point(393, 32);
            this.txtConst.Name = "txtConst";
            this.txtConst.Size = new System.Drawing.Size(75, 21);
            this.txtConst.TabIndex = 3;
            // 
            // labConst
            // 
            this.labConst.AutoSize = true;
            this.labConst.Location = new System.Drawing.Point(393, 17);
            this.labConst.Name = "labConst";
            this.labConst.Size = new System.Drawing.Size(41, 12);
            this.labConst.TabIndex = 4;
            this.labConst.Text = "系数：";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(393, 657);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(393, 628);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "起点坐标";
            // 
            // txtStartX
            // 
            this.txtStartX.Location = new System.Drawing.Point(393, 75);
            this.txtStartX.Name = "txtStartX";
            this.txtStartX.Size = new System.Drawing.Size(75, 21);
            this.txtStartX.TabIndex = 8;
            // 
            // txtStartY
            // 
            this.txtStartY.Location = new System.Drawing.Point(393, 102);
            this.txtStartY.Name = "txtStartY";
            this.txtStartY.Size = new System.Drawing.Size(75, 21);
            this.txtStartY.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "中心坐标";
            // 
            // txtEndY
            // 
            this.txtEndY.Location = new System.Drawing.Point(393, 172);
            this.txtEndY.Name = "txtEndY";
            this.txtEndY.Size = new System.Drawing.Size(75, 21);
            this.txtEndY.TabIndex = 12;
            // 
            // txtEndX
            // 
            this.txtEndX.Location = new System.Drawing.Point(393, 145);
            this.txtEndX.Name = "txtEndX";
            this.txtEndX.Size = new System.Drawing.Size(75, 21);
            this.txtEndX.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "跳动距离";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(393, 215);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(75, 21);
            this.txtWidth.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "蓄力时间";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(393, 258);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(75, 21);
            this.txtTime.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "目标分数";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(393, 301);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(75, 21);
            this.txtTarget.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 693);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndY);
            this.Controls.Add(this.txtEndX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartY);
            this.Controls.Add(this.txtStartX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.labConst);
            this.Controls.Add(this.txtConst);
            this.Controls.Add(this.mainImg);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(492, 732);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(492, 732);
            this.Name = "Form1";
            this.Text = "微信跳一跳辅助";
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer AutoTimer;
        private Emgu.CV.UI.ImageBox mainImg;
        private System.Windows.Forms.TextBox txtConst;
        private System.Windows.Forms.Label labConst;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartX;
        private System.Windows.Forms.TextBox txtStartY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndY;
        private System.Windows.Forms.TextBox txtEndX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTarget;
    }
}

