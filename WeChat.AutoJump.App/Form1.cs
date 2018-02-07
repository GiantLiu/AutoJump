using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeChat.AutoJump.Domain;
using WeChat.AutoJump.IService;
using WeChat.AutoJump.Utility;

namespace WeChat.AutoJump.App
{
    public partial class Form1 : Form
    {
        public bool IsAutoJump { get; set; }
        public IActionService ActionSvc { get; set; }
        public bool HasDevice { get; set; }
        public JumpDataModel Model { get; set; }
        public Form1()
        {
            this.IsAutoJump = false;
            InitializeComponent();
            this.ActionSvc = IocContainer.Resolve<IActionService>();
            this.Model = JumpDataModel.Instance;
        }

        private void AutoTimer_Tick(object sender, EventArgs e)
        {
            var timer = sender as System.Windows.Forms.Timer;
            try {
                timer.Stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (this.IsAutoJump) timer.Start();
            }
        }

        public string GetDeviceID()
        {
            var deviceID = ActionSvc.GetDeviceID();
            return deviceID;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var deviceID = this.GetDeviceID();
            if (String.IsNullOrEmpty(deviceID))
            {
                MessageBox.Show("当前没有检测到手机\r\n请在手机 设置->开发者选项->打开开发都选项和USB调试 后继续运行此程序");
                return;
            }
            if (String.IsNullOrEmpty(txtTarget.Text))
            {
                MessageBox.Show("请设置一个目标分数,当达到此分数后，程序自动停止");
                return;
            }
            this.Model.TargetScore = int.Parse(txtTarget.Text);
            this.IsAutoJump = true;
            this.AutoTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.IsAutoJump = false;
            this.AutoTimer.Stop();
        }
        private void setUI()
        {

        }
    }
}
