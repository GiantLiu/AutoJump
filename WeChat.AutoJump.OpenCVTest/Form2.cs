using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WeChat.AutoJump.OpenCVTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ProcessImg();
        }
        public void ProcessImg()
        {
            var imgDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            var curImgPath = Path.Combine(imgDic, "20180117114227698.png");
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(curImgPath);
            Image<Bgr, Byte> sourceImg = new Image<Bgr, Byte>(curImgPath);

            //原图宽的1/2
            var imgWidthCenter = (int)(img.Width / 2.0);
            //原图高的1/3
            var imgHeightSplit = (int)(img.Height / 3.0);

            var tempGrayPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", String.Format("{0}_{1}.png", img.Width, img.Height));

            var tempGrayImg = new Image<Bgr, byte>(tempGrayPath);

            var match = img.MatchTemplate(tempGrayImg, TemplateMatchingType.CcoeffNormed);

            double min = 0, max = 0;
            Point maxp = new Point(0, 0);//最好匹配的点
            Point minp = new Point(0, 0);
            CvInvoke.MinMaxLoc(match, ref min, ref max, ref minp, ref maxp);
            Console.WriteLine(min + " " + max);
            CvInvoke.Rectangle(img, new Rectangle(maxp, new Size(tempGrayImg.Width, tempGrayImg.Height)), new MCvScalar(0, 0, 255), 3);

            var startPoint = new Point();
            startPoint.X = maxp.X + (int)(tempGrayImg.Width / 2.0);
            startPoint.Y = maxp.Y + tempGrayImg.Height - 13;
            CvInvoke.Rectangle(img, new Rectangle(startPoint, new Size(1, 1)), new MCvScalar(0, 0, 0), 3);


            //裁剪查找区域
            //原图片1/3以下，小黑人以上
            var newImgStart = imgHeightSplit;
            var newImgEnd = maxp.Y + tempGrayImg.Height;
            var newImgHeight = newImgEnd - newImgStart;
            Rectangle rect = new Rectangle(0, newImgStart, img.Width, newImgHeight);
            var _newImg = sourceImg.Copy();
            CvInvoke.cvSetImageROI(_newImg, rect);
            var newImg = new Image<Bgr, byte>(sourceImg.Width, newImgHeight);
            CvInvoke.cvCopy(_newImg, newImg, IntPtr.Zero);


            ////看目标在程序的左边还是右边
            ////如果在左边，那目标点就在图片的右边
            bool targetInLeft = true;
            if (maxp.X < imgWidthCenter) targetInLeft = false;

            Rectangle halfRect;
            if (targetInLeft)
                halfRect = new Rectangle(0, 0, imgWidthCenter, newImgHeight);
            else
                halfRect = new Rectangle(imgWidthCenter, 0, imgWidthCenter, newImgHeight);
            var _halfImg = newImg.Copy();
            CvInvoke.cvSetImageROI(_halfImg, halfRect);
            var halfImg = new Image<Bgr, byte>(imgWidthCenter, newImgHeight);
            CvInvoke.cvCopy(_halfImg, halfImg, IntPtr.Zero);
            //halfImg.ToBitmap().Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "halfImg.png"));

            Point topPoint = new Point();
            for (int i = 0; i < halfImg.Rows; i++)
            {
                for (int j = 0; j < halfImg.Cols - 1; j++)
                {
                    var cur = halfImg[i, j];
                    var next = halfImg[i, j + 1];
                    if (Math.Abs(BgrHelp.GetDiff(cur, next)) > 2)
                    {
                        var x = 2;
                        next = halfImg[i, j + x];
                        while (Math.Abs(BgrHelp.GetDiff(cur, next)) > 2)
                        {
                            x++;
                            next = halfImg[i, j + x];
                        }
                        topPoint.Y = i;
                        topPoint.X = j + (int)(x / 2.0);
                        break;
                    }
                }
                if (!topPoint.IsEmpty) break;
            }

            //StringBuilder imgString = new StringBuilder();
            //for (int a = 0; a < halfImg.Rows; a++)
            //{
            //    for (int b = 0; b < halfImg.Cols; b++)
            //    {
            //        var rgbData = halfImg[a, b];
            //        imgString.AppendFormat("[{0},{1},[{2},{3},{4}]]\t\t", a, b, rgbData.Blue, rgbData.Green, rgbData.Red);
            //    }
            //    imgString.Append(Environment.NewLine);
            //}
            //File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "halfImg.txt"), imgString.ToString());

            //var demoImg = new Image<Bgr, Byte>(halfImg.Width, halfImg.Height);
            //for (int a = 0; a < halfImg.Rows; a++)
            //{
            //    for (int b = 0; b < halfImg.Cols; b++)
            //    {
            //        var dData = halfImg[a, b];
            //        demoImg[a, b] = new Bgr(dData.Blue, dData.Green, dData.Red);
            //    }
            //}
            //demoImg.ToBitmap().Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "demoImg.png"));

            //如果在左边。就找最左边的点。如果在右边。就找最右边的点
            Point leftRightPoint = new Point();
            if (targetInLeft)
            {
                for (int x = topPoint.X - 1, y = topPoint.Y - 1; x > 0; x--)
                {
                    var cur = halfImg[y, x];
                    var next = halfImg[y + 1, x];
                    if (Math.Abs(BgrHelp.GetDiff(cur, next)) > 2)
                    {
                        continue;
                    }
                    else
                    {
                        var n = 2;
                        next = halfImg[y + n, x];
                        while (Math.Abs(BgrHelp.GetDiff(cur, next)) <= 2)
                        {
                            n++;
                            next = halfImg[y + n, x];
                        }
                        if (n < 6)
                        {
                            y += (n - 1);
                            continue;
                        }
                        leftRightPoint.X = x + 1;
                        leftRightPoint.Y = y;
                    }
                    if (!leftRightPoint.IsEmpty) break;
                }
            }
            else
            {
                for (int x = topPoint.X + 1, y = topPoint.Y - 1; x < halfImg.Cols; x++)
                {
                    var cur = halfImg[y, x];
                    var next = halfImg[y + 1, x];
                    if (Math.Abs(BgrHelp.GetDiff(cur, next)) > 2)
                    {
                        continue;
                    }
                    else
                    {
                        var n = 2;
                        next = halfImg[y + n, x];
                        while (Math.Abs(BgrHelp.GetDiff(cur, next)) <= 2 && n <= 7)
                        {
                            n++;
                            next = halfImg[y + n, x];
                        }
                        if (n <= 4)
                        {
                            y += (n - 1);
                            continue;
                        }
                        leftRightPoint.X = x - 1;
                        leftRightPoint.Y = y;
                    }
                    if (!leftRightPoint.IsEmpty) break;
                }
            }


            CvInvoke.Rectangle(halfImg, new Rectangle(topPoint, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);
            CvInvoke.Rectangle(halfImg, new Rectangle(leftRightPoint, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);

            //这个顶点在原图中的位置
            var oldTopX = topPoint.X;
            if (!targetInLeft) oldTopX += imgWidthCenter;
            var oldTopY = topPoint.Y + imgHeightSplit;
            var oldTopPoint = new Point(oldTopX, oldTopY);
            CvInvoke.Rectangle(img, new Rectangle(oldTopPoint, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);

            //左/右边顶点
            var oldLeftRightX = leftRightPoint.X;
            if (!targetInLeft) oldLeftRightX += imgWidthCenter;
            var oldLeftRightY = leftRightPoint.Y + imgHeightSplit;
            var oldLeftRight = new Point(oldLeftRightX, oldLeftRightY);
            CvInvoke.Rectangle(img, new Rectangle(oldLeftRight, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);


            //画线
            var nodePoint1 = new Point(oldTopX, startPoint.Y);
            CvInvoke.Line(img, oldTopPoint, nodePoint1, new MCvScalar(0, 0, 255), 3);
            CvInvoke.Line(img, startPoint, nodePoint1, new MCvScalar(0, 0, 255), 3);

            var centerPoint = new Point(oldTopPoint.X, oldLeftRight.Y);
            CvInvoke.Line(img, startPoint, centerPoint, new MCvScalar(0, 0, 255), 3);


            mainImg.Image = img;
            imgBox1.Image = newImg;
            imgBox2.Image = halfImg;
        }
    }
    public static class BgrHelp
    {
        public static double GetDiff(Bgr one, Bgr two)
        {
            var diffR = one.Red - two.Red;
            var diffG = one.Green - two.Green;
            var diffB = one.Blue - two.Blue;
            return diffR + diffG + diffB;
        }
    }
}
