using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.AutoJump.Domain
{
    public class CacheModel
    {
        public WidthHeight Image { get; set; }
        public WidthHeight PicBox { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public int GetTime()
        {
            //double value = Math.Sqrt(Math.Abs(this.Start.X - this.End.X) * Math.Abs(this.Start.X - this.End.X) + Math.Abs(this.Start.Y - this.End.Y) * Math.Abs(this.Start.Y - this.End.Y));

            var imgStart = new Point();
            imgStart.X = (int)(this.Start.X * this.Zoom);
            imgStart.Y= (int)(this.Start.Y * this.Zoom);
            var imgEnd = new Point();
            imgEnd.X = (int)(this.End.X * this.Zoom);
            imgEnd.Y = (int)(this.End.Y * this.Zoom);
            double value = Math.Sqrt(Math.Abs(imgStart.X - imgEnd.X) * Math.Abs(imgStart.X - imgEnd.X) + Math.Abs(imgStart.Y - imgEnd.Y) * Math.Abs(imgStart.Y - imgEnd.Y));
            var constVal = 1495 / (this.Image.Width + 0.00);
            return (int)(value * constVal);
        }
        public double Zoom
        {
            get
            {
                return (double)this.Image.Width / (double)this.PicBox.Width;
            }
        }
    }
    public class WidthHeight
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
