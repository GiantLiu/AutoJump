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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ProcessImg();
        }
        public void ProcessImg()
        {
            var imgDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            var curImgPath = Path.Combine(imgDic, "20180109094721127.png");
            Image<Gray, Byte> img = new Image<Gray, byte>(curImgPath);

            //原图宽的1/2
            var imgWidthCenter = (int)(img.Width / 2.0);
            //原图高的1/3
            var imgHeightSplit = (int)(img.Height / 3.0);

            var tempGrayPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "Gray.png");

            var tempGrayImg = new Image<Gray, byte>(tempGrayPath);

            var match = img.MatchTemplate(tempGrayImg, TemplateMatchingType.CcorrNormed);
            
            double min = 0, max = 0;
            Point maxp = new Point(0, 0);//最好匹配的点
            Point minp = new Point(0, 0);
            CvInvoke.MinMaxLoc(match, ref min, ref max, ref minp, ref maxp);
            Console.WriteLine(min + " " + max);
            CvInvoke.Rectangle(img, new Rectangle(maxp, new Size(tempGrayImg.Width, tempGrayImg.Height)), new MCvScalar(0, 0, 255), 3);

            var startPoint = new Point();
            startPoint.X = maxp.X + (int)(tempGrayImg.Width / 2.0);
            startPoint.Y = maxp.Y + tempGrayImg.Height - 20;
            CvInvoke.Rectangle(img, new Rectangle(startPoint, new Size(1, 1)), new MCvScalar(0, 0, 0), 3);

            mainImg.Image = img;
            //裁剪查找区域
            //原图片1/3以下，小黑人以上
            var newImgStart = imgHeightSplit;
            var newImgEnd = maxp.Y + tempGrayImg.Height;
            var newImgHeight = newImgEnd - newImgStart;
            Rectangle rect = new Rectangle(0, newImgStart, img.Width, newImgHeight);

            CvInvoke.cvSetImageROI(img, rect);
            var newImg = new Image<Gray, byte>(img.Width, newImgHeight);
            CvInvoke.cvCopy(img, newImg, IntPtr.Zero);

            imgBox1.Image = newImg;
            //var newImg = grayImg.CopyBlank();
            //var rows = grayImg.Rows;
            //var cols = grayImg.Cols;
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols - 1; j++)
            //    {
            //        var cur = grayImg[i, j];
            //        var next = grayImg[i, j + 1];
            //        if (Math.Abs(cur.Intensity - next.Intensity) <= 1)
            //            newImg[i, j] = new Gray(255);
            //        else
            //            newImg[i, j] = new Gray(0);
            //    }
            //    newImg[i, cols - 1] = new Gray(255);
            //}

            //看小黑人在程序的左边还是右边
            //如果在左边，那目标点就在图片的右边
            bool targetInLeft = true;
            if (maxp.X < imgWidthCenter) targetInLeft = false;

            Rectangle halfRect;
            if (targetInLeft)
                halfRect = new Rectangle(0, 0, imgWidthCenter, newImgHeight);
            else
                halfRect = new Rectangle(imgWidthCenter, 0, imgWidthCenter, newImgHeight);

            CvInvoke.cvSetImageROI(newImg, halfRect);
            var halfImg = new Image<Gray, byte>(imgWidthCenter, newImgHeight);
            CvInvoke.cvCopy(newImg, halfImg, IntPtr.Zero);

            imgBox2.Image = halfImg;
            Point topPoint = new Point();
            for (int i = 0; i < halfImg.Rows; i++)
            {
                for (int j = 0; j < halfImg.Cols - 1; j++)
                {
                    var cur = halfImg[i, j];
                    var next = halfImg[i, j + 1];
                    if (Math.Abs(cur.Intensity - next.Intensity) > 2)
                    {
                        var x = 2;
                        next = halfImg[i, j + x];
                        while (Math.Abs(cur.Intensity - next.Intensity) > 2)
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
            CvInvoke.Rectangle(halfImg, new Rectangle(topPoint, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);

            //这个顶点在原图中的位置
            var oldTopX = topPoint.X;
            if (!targetInLeft) oldTopX += imgWidthCenter;
            var oldTopY = topPoint.Y + imgHeightSplit;
            var oldTopPoint = new Point(oldTopX, oldTopY);
            CvInvoke.Rectangle(img, new Rectangle(oldTopPoint, new Size(1, 1)), new MCvScalar(0, 0, 255), 3);


            var nodePoint1 = new Point(oldTopX, startPoint.Y);
            CvInvoke.Line(img, oldTopPoint, nodePoint1, new MCvScalar(0, 0, 255), 3);
            CvInvoke.Line(img, startPoint, nodePoint1, new MCvScalar(0, 0, 255), 3);
            var lineWidth = Math.Abs(oldTopX - startPoint.X);
            var jumpWidth = lineWidth / Math.Cos(30);
        }
    }
}
