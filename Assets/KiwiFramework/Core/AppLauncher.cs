using KiwiFramework.Core;
using KiwiFramework.Core.XLuaModule;
using UnityEngine;


namespace KiwiFramework.Core
{
    /// <summary>
    /// 应用启动器
    /// </summary>
    public class AppLauncher : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                InitializeSetting();
#if UseLua
                LuaVM.Instance.DoFile("GameMain");
#else
                AppFacade.Instance.Startup();
#endif
            }
            catch (System.Exception e)
            {
                KiwiLog.Exception(e);
#if !UNITY_EDITOR
                Application.Quit();
#endif
            }
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        private static void InitializeSetting()
        {
            Application.targetFrameRate = 30;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}