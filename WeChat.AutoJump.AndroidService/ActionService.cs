using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WeChat.AutoJump.IService;
using System.Diagnostics;

namespace WeChat.AutoJump.AndroidService
{
    public class ActionService : IActionService
    {
        public void Action(int time)
        {
            var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
            var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");
            using (Process process = new Process())
            {
                //process.StartInfo.WorkingDirectory = adbDirectoryPath;
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = String.Format("shell input swipe 100 100 200 200 {0}", time);
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
            var adbDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AndoridAdb");
            var adbPath = Path.Combine(adbDirectoryPath, "adb.exe");
            if (!File.Exists(adbPath)) throw new NotImplementedException();
            var imgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download", DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png");
            using (Process process = new Process())
            {
                //process.StartInfo.WorkingDirectory = adbDirectoryPath;
                process.StartInfo.FileName = adbPath;
                process.StartInfo.Arguments = "shell screencap -p | base64";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;   //重定向标准输入   
                process.StartInfo.RedirectStandardOutput = true;  //重定向标准输出   
                process.StartInfo.RedirectStandardError = true;   //重定向错误输出
                process.StartInfo.CreateNoWindow = true;  
                process.Start();
                var memoStream = new MemoryStream();
                var result= process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                byte[] b = Convert.FromBase64String(result);
                MemoryStream ms = new MemoryStream(b);
                Bitmap bitmap = new Bitmap(ms);
                return bitmap;
            }
        }
    }
}
