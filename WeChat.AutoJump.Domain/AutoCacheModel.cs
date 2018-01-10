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
                var constVal = 1495 / (this.Image.Width + 0.00);
                return (int)(this.JumpWidth * constVal);
            }
        }
        public override string ToString()
        {
            return String.Format("Image:{0}\r\nTop:X:{1},Y:{2}\r\nStart:X:{3},Y:{4}\r\nJumpWidth:{5},Time:{6}",
                this.Image.ToString(),
                this.Top.X, this.Top.Y,
                this.Start.X, this.Start.Y,
                this.JumpWidth,
                this.Time);
        }
    }
}
