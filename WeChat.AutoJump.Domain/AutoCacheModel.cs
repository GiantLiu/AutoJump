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
        public Point Top { get; set; }
        public Point Start { get; set; }
        public double JumpWidth
        {
            get
            {
                var lineWidth = Math.Abs(this.Top.X - this.Start.X);
                var jumpWidth = lineWidth / Math.Cos(30 * (Math.PI / 180.0));
                return jumpWidth;
            }
        }
        public int Time
        {
            get
            {
                var constVal = double.Parse(AppSettingHelper.Get("ConstValue"));
                return (int)(this.JumpWidth * constVal);
            }
        }
    }
}
