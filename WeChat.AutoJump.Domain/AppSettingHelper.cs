using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChat.AutoJump.Domain
{
    /// <summary>
    /// 配置文件帮助类
    /// </summary>
    public class AppSettingHelper
    {
        private static readonly Lazy<AppSettingHelper> Provider = new Lazy<AppSettingHelper>(() => new AppSettingHelper());
        private NameValueCollection Settings { get; set; }
        private AppSettingHelper()
        {
            this.Settings = System.Configuration.ConfigurationManager.AppSettings;
        }
        /// <summary>
        /// 拿到配置文件AppSettings节点数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            var helper = Provider.Value;
            return helper.Settings[key];
        }
    }
}
