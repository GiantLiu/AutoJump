using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WeChat.AutoJump.IService;
using System.Diagnostics;
using WeChat.AutoJump.Domain;

namespace WeChat.AutoJump.AndroidService
{
    public class ActionService : IActionService
    {
        public Random Rand { get; set; }
        public ActionService()
        {
            this.Rand = new Random();
        }
        public void Action(WidthHeight img, int time)
        {
            var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
            var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");

            var widthSplit = (int)(img.Width / 2.0);
            var heightSplit = (int)(img.Height / 2.0);

            var point1 = new Point();
            point1.X = this.Rand.Next(widthSplit, img.Width - 100);
            point1.Y = this.Rand.Next(heightSplit, img.Height - 100);

            var point2 = new Point();
            point2.X = this.Rand.Next(widthSplit, img.Width - 100);
            point2.Y = this.Rand.Next(heightSplit, img.Height - 100);

            using (Process process = new Process())
            {
                //process.StartInfo.WorkingDirectory = adbDirectoryPath;
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = String.Format("shell input swipe {0} {1} {2} {3} {4}", point1.X, point1.Y, point2.X, point2.Y, time);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
                process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
                process.StartInfo.RedirectStandardError = true;   //重定向错误输出
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                var result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
        }

        public Bitmap GetScreenshots()
        {
            //var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
            //var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");
            //if (!File.Exists(adbPath)) throw new NotImplementedException();
            //var imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download", DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png");
            //using (Process process = new Process())
            //{
            //    //process.StartInfo.WorkingDirectory = adbDirectoryPath;
            //    process.StartInfo.FileName = adbPath;
            //    process.StartInfo.Arguments = "shell screencap -p | base64";
            //    process.StartInfo.UseShellExecute = false;
            //    process.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
            //    process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
            //    process.StartInfo.RedirectStandardError = true;   //重定向错误输出
            //    process.StartInfo.CreateNoWindow = true;  
            //    process.Start();
            //    var memoStream = new MemoryStream();
            //    var result= process.StandardOutput.ReadToEnd();
            //    process.WaitForExit();
            //    byte[] b = Convert.FromBase64String(result);
            //    MemoryStream ms = new MemoryStream(b);
            //    Bitmap bitmap = new Bitmap(ms);
            //    return bitmap;
            //}

            var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
            var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");
            if (!File.Exists(adbPath)) throw new NotImplementedException();
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
            var imgFileDicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download");
            var createFileArg= String.Format("shell screencap -p /sdcard/{0}", fileName);
            AdbCommand(createFileArg);
            var downLoadArg = String.Format("pull /sdcard/{0} {1}", fileName, imgFileDicPath);
            AdbCommand(downLoadArg);
            var delFileArg = String.Format("shell rm /sdcard/{0}", fileName);
            AdbCommand(delFileArg);
            var imgFilePath = Path.Combine(imgFileDicPath, fileName);
            if (!File.Exists(imgFilePath)) return null;
            return new Bitmap(imgFilePath);
        }
        public string AdbCommand(string arg)
        {
            using (Process process = new Process())
            {
                var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
                var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = arg;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
                process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
                process.StartInfo.RedirectStandardError = true;   //重定向错误输出
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                var result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
                return result;
            }
        }

        public string GetDeciveID()
        {
            var devicesArg = "devices";
            var result = AdbCommand(devicesArg);
            var lineArray = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (lineArray.Length <= 1) return null;
            var deviceInfo = lineArray[1].Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            return deviceInfo[0];
        }
    }
}
