using System.Text;
using GameFramework;
using UnityEngine;

namespace KiwiFramework.Core
{
    public static partial class Extend
    {
        /// <summary>
        /// 将字符串以常规 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        public static void LogInfo(this string str)
        {
            KiwiLog.Info(str);
        }

        /// <summary>
        /// 将字符串以常规 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        public static void LogInfo(this string str, Object context)
        {
            KiwiLog.Info(str, context);
        }

        /// <summary>
        /// 将字符串格式化后以常规 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogInfoFormat(this string str, params string[] args)
        {
            KiwiLog.InfoFormat(str, args);
        }

        /// <summary>
        /// 将字符串格式化后以常规 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogInfoFormat(this string str, Object context, params string[] args)
        {
            KiwiLog.InfoFormat(context, str, args);
        }

        /// <summary>
        /// 将字符串以警告 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        public static void LogWarning(this string str)
        {
            KiwiLog.Warning(str);
        }

        /// <summary>
        /// 将字符串以警告 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        public static void LogWarning(this string str, Object context)
        {
            KiwiLog.Warning(str, context);
        }

        /// <summary>
        /// 将字符串格式化后以警告 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogWarningFormat(this string str, params string[] args)
        {
            KiwiLog.WarningFormat(str, args);
        }

        /// <summary>
        /// 将字符串格式化后以警告 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogWarningFormat(this string str, Object context, params string[] args)
        {
            KiwiLog.WarningFormat(context, str, args);
        }

        /// <summary>
        /// 将字符串以错误 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        public static void LogError(this string str)
        {
            KiwiLog.Error(str);
        }

        /// <summary>
        /// 将字符串以错误 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        public static void LogError(this string str, Object context)
        {
            KiwiLog.Error(str, context);
        }

        /// <summary>
        /// 将字符串格式化后以错误 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogErrorFormat(this string str, params string[] args)
        {
            KiwiLog.ErrorFormat(str, args);
        }

        /// <summary>
        /// 将字符串格式化后以错误 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        /// <param name="args">格式化所用数据</param>
        public static void LogErrorFormat(this string str, Object context, params string[] args)
        {
            KiwiLog.ErrorFormat(context, str, args);
        }

        /// <summary>
        /// 将字符串以异常 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        public static void LogException(this string str)
        {
            KiwiLog.Exception(str);
        }

        /// <summary>
        /// 将字符串以异常 Log 输出到 Unity 控制台
        /// </summary>
        /// <param name="str">要输出的字符串</param>
        /// <param name="context">输出字符串的对象实例</param>
        public static void LogException(this string str, Object context)
        {
            KiwiLog.Exception(str, context);
        }
    }
}