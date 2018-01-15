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
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;

namespace WeChat.AutoJump.OpenCVTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            ProcessImg();
        }
        public void ProcessImg()
        {
            var imgDic = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            var curImgPath = Path.Combine(imgDic, "20180109093048226.png");
            var tesssdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            Image<Bgr, Byte> img = new Image<Bgr, Byte>(curImgPath);

            //原图宽的1/2
            var imgWidthSplit = (int)(img.Width / 3.0);
            //原图高的1/3
            var imgHeightSplit = (int)(img.Height / 3.0);

            var grayImg = img.Convert<Gray, Byte>();

            mainImg.Image = grayImg;

            Rectangle rect = new Rectangle(0, 0, imgWidthSplit * 2, imgHeightSplit);
            CvInvoke.cvSetImageROI(grayImg, rect);
            var newImg = new Image<Gray, Byte>(imgWidthSplit * 2, imgHeightSplit);
            CvInvoke.cvCopy(grayImg, newImg, IntPtr.Zero);

            imgBox1.Image = newImg;

            var thresImg = newImg.ThresholdBinary(new Gray(78), new Gray(255));
           
            imgBox2.Image = thresImg;

            Tesseract ocr = new Tesseract("", "num", OcrEngineMode.TesseractOnly);
            ocr.SetImage(thresImg);
            ocr.SetVariable("tessedit_char_whitelist", "0123456789");
            var rr = ocr.Recognize();
            var val = ocr.GetUTF8Text();
            MessageBox.Show(val);
        }
    }
}
