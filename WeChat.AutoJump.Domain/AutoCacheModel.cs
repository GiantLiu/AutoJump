using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.AutoJump.Domain
{
    public class AutoCacheModel
    {
        public WidthHeight Image { get; set; }
        public Point End { get; set; }
        public Point Start { get; set; }
        public int Score { get; set; }
        public double JumpWidth
        {
            get
            {
                double value = Math.Sqrt(Math.Abs(this.Start.X - this.End.X) * Math.Abs(this.Start.X - this.End.X) + Math.Abs(this.Start.Y - this.End.Y) * Math.Abs(this.Start.Y - this.End.Y));
                return value;
            }
        }
        public int Time
        {
            get
            {
                var constVal = double.Parse(AppSettingHelper.Get("ConstValue")) / (double)this.Image.Width;
                return (int)(this.JumpWidth * constVal);
            }
        }
    }
}
