# AutoJump
微信跳一跳辅助程序

全自动版本
WeChat.AutoJump.CMDApp
当手机连接好后，打开微信跳一跳
点击"开始游戏"后。运行此程序。就可以实现自动跳了

半自动版本
WeChat.AutoJump.WinApp
此版本需要鼠标左键点小黑人的底部，鼠标右键点目标位的中心
然后程序就会自动跳到相应的位置


注意事项：
1.现只支持Andorid
2.在用此版本的程序前，要先打开手机“开发者选项”
3.在“开发都选项”里面，打开"USB调试"


接口定义
WeChat.AutoJump.IService

安卓机器实现接口
WeChat.AutoJump.AndroidService
IOS设置实现接口（未实现）
WeChat.AutoJump.IOSService

APP中用到的相关实体
WeChat.AutoJump.Domain

用于图片识别相关的算法测试（OpenCV）
WeChat.AutoJump.OpenCVTest

相关辅助类
WeChat.AutoJump.Utility
