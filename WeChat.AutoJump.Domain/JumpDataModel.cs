using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.AutoJump.Domain
{
    public class JumpDataModel
    {
        private static readonly Lazy<JumpDataModel> Provider = new Lazy<JumpDataModel>(() => new JumpDataModel());
        public WidthHeight Image { get; set; }
        public Point End { get; set; }
        public Point Start { get; set; }
        public int TargetScore { get; set; }
        public int Score { get; set; }
        public double ConstNum { get; set; }
        public double JumpWidth { get; set; }
        public int Time { get; set; }
        private JumpDataModel()
        { }
        public void Calc()
        {
            this.JumpWidth = Math.Sqrt(Math.Abs(this.Start.X - this.End.X) * Math.Abs(this.Start.X - this.End.X) + Math.Abs(this.Start.Y - this.End.Y) * Math.Abs(this.Start.Y - this.End.Y));
            var constVal = this.ConstNum / (double)this.Image.Width;
            this.Time = (int)(this.JumpWidth * constVal);
        }
        public static JumpDataModel Instance { get { return Provider.Value; } }
    }
}
