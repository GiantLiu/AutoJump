namespace WeChat.AutoJump.OpenCVTest
{
    partial class Form2
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
            this.mainImg = new Emgu.CV.UI.ImageBox();
            this.imgBox1 = new Emgu.CV.UI.ImageBox();
            this.imgBox2 = new Emgu.CV.UI.ImageBox();
            this.imgBox3 = new Emgu.CV.UI.ImageBox();
            this.imgBox4 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // mainImg
            // 
            this.mainImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mainImg.Location = new System.Drawing.Point(13, 13);
            this.mainImg.Name = "mainImg";
            this.mainImg.Size = new System.Drawing.Size(375, 667);
            this.mainImg.TabIndex = 2;
            this.mainImg.TabStop = false;
            // 
            // imgBox1
            // 
            this.imgBox1.Location = new System.Drawing.Point(394, 13);
            this.imgBox1.Name = "imgBox1";
            this.imgBox1.Size = new System.Drawing.Size(375, 333);
            this.imgBox1.TabIndex = 2;
            this.imgBox1.TabStop = false;
            // 
            // imgBox2
            // 
            this.imgBox2.Location = new System.Drawing.Point(394, 352);
            this.imgBox2.Name = "imgBox2";
            this.imgBox2.Size = new System.Drawing.Size(375, 333);
            this.imgBox2.TabIndex = 3;
            this.imgBox2.TabStop = false;
            // 
            // imgBox3
            // 
            this.imgBox3.Location = new System.Drawing.Point(775, 12);
            this.imgBox3.Name = "imgBox3";
            this.imgBox3.Size = new System.Drawing.Size(375, 333);
            this.imgBox3.TabIndex = 4;
            this.imgBox3.TabStop = false;
            // 
            // imgBox4
            // 
            this.imgBox4.Location = new System.Drawing.Point(775, 352);
            this.imgBox4.Name = "imgBox4";
            this.imgBox4.Size = new System.Drawing.Size(375, 333);
            this.imgBox4.TabIndex = 5;
            this.imgBox4.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 711);
            this.Controls.Add(this.imgBox4);
            this.Controls.Add(this.imgBox3);
            this.Controls.Add(this.imgBox2);
            this.Controls.Add(this.imgBox1);
            this.Controls.Add(this.mainImg);
            this.Name = "Form2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox mainImg;
        private Emgu.CV.UI.ImageBox imgBox1;
        private Emgu.CV.UI.ImageBox imgBox2;
        private Emgu.CV.UI.ImageBox imgBox3;
        private Emgu.CV.UI.ImageBox imgBox4;
    }
}

