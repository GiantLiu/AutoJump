using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChat.AutoJump.Domain;
using WeChat.AutoJump.IService;
using WeChat.AutoJump.Utility;

namespace WeChat.AutoJump.WinApp
{
    public partial class Form1 : Form
    {
        public CacheModel Model { get; set; }
        public IActionService ActionSvc { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.ActionSvc = IocContainer.Resolve<IActionService>();
            this.Model = new CacheModel();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var deviceInfo = this.ActionSvc.GetDeciveID();
            if (String.IsNullOrEmpty(deviceInfo)) MessageBox.Show("当前没有检测到手机");
            else this.SetImg();
        }

        private void mainImg_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        this.Model.Start = e.Location;
                    }
                    break;
                case MouseButtons.Right:
                    {
                        this.Model.End = e.Location;
                        var time = this.Model.GetTime();
                        this.ActionSvc.Action(this.Model.Image, time);
                        this.Model = new CacheModel();
                        Thread.Sleep(time + 1000);
                        this.SetImg();
                    }
                    break;
                default: break;
            }
        }
        private void SetImg()
        {
            var img = this.ActionSvc.GetScreenshots();
            mainImg.Image = img;
            this.Model.Image = new WidthHeight() { Width = img.Width, Height = img.Height };
            var zoom = mainImg.Width / (img.Width + 0.00);
            mainImg.Height = (int)(img.Height * zoom);
            this.Model.PicBox = new WidthHeight() { Width = mainImg.Width, Height = mainImg.Height };
        }
    }
}
