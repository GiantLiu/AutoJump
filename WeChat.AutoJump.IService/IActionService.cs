using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeChat.AutoJump.IService
{
    public interface IActionService
    {
        /// <summary>
        /// 拿到屏幕截图
        /// </summary>
        /// <returns></returns>
        Bitmap GetScreenshots();

        /// <summary>
        /// 发送按压命令
        /// </summary>
        /// <param name="time">按住屏幕时间（毫秒）</param>
        void Action(int time);
    }
}
