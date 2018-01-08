using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using WeChat.AutoJump.IService;

namespace WeChat.AutoJump.Utility
{
    /// <summary>
    /// IOC Service Provider
    /// IocContainer.Resolve＜InterfaceType＞
    /// </summary>
    public class IocContainer
    {
        #region IOC Init
        private static readonly Lazy<IocContainer> Provider = new Lazy<IocContainer>(() => new IocContainer());
        private string DeviceType { get; set; }
        private ContainerBuilder Builder { get; set; }
        public IContainer Container { get; set; }
        private IocContainer()
        {
            this.DeviceType = AppSettingHelper.Get("DeviceType");
            this.Builder = new ContainerBuilder();
            this.Register(this.Builder);
            this.Container = this.Builder.Build();
        }
        #endregion
        /// <summary>
        /// 类型注册
        /// </summary>
        public void Register(ContainerBuilder builder)
        {
            if (this.DeviceType == "Android")
                this.Builder.RegisterType<AndroidService.ActionService>().As<IActionService>().SingleInstance();
            else
                this.Builder.RegisterType<IOSService.ActionService>().As<IActionService>().SingleInstance();
        }
        /// <summary>
        /// 
        /// </summary>
        public static IocContainer Instance { get { return Provider.Value; } }
        /// <summary>
        /// 解悉类型实例
        /// IocContainer.Resolve＜InterfaceType＞
        /// </summary>
        /// <typeparam name="T">要解悉的接口类型</typeparam>
        /// <returns>对应的接口实例</returns>
        public static T Resolve<T>()
        {
            var provider = Provider.Value;
            return provider.Container.Resolve<T>();
        }
    }
}
