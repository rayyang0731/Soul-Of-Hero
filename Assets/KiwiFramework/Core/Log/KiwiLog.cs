using System;
using GameFramework;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using XLua;
using Object = UnityEngine.Object;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 打印日志
    /// </summary>
    public static partial class KiwiLog
    {
        private static readonly string Tag = "[" + PlayerSettings.productName + "]";
        private static KiwiLogger Logger { get; } = new KiwiLogger(Debug.unityLogger.logHandler);

        /// <summary>
        /// 是否开启 Log
        /// </summary>
        public static bool LogEnabled
        {
            get => Logger.logEnabled;
            set => Logger.logEnabled = value;
        }

        /// <summary>
        /// 是否开启 Log 输出
        /// </summary>
        public static bool LogWriteEnabled
        {
            get => Logger.EnableWriteLog;
            set => Logger.EnableWriteLog = value;
        }

        /// <summary>
        /// 输出日志时是否输出堆栈信息
        /// </summary>
        public static bool OutputStackTraceEnabled
        {
            get => Logger.OutputStackTrace;
            set => Logger.OutputStackTrace = value;
        }

        #region Info

        public static void Info(string message)
        {
            Print(LogType.Log, message);
        }

        public static void Info(string message, Object context)
        {
            Print(LogType.Log, message, context);
        }

        public static void Info(params string[] messages)
        {
            Print(LogType.Log, messages);
        }

        public static void Info(Object context, params string[] messages)
        {
            Print(LogType.Log, context, messages);
        }

        public static void InfoFormat(string format, params string[] args)
        {
            PrintFormat(LogType.Log, format, args);
        }

        public static void InfoFormat(Object context, string format, params string[] args)
        {
            PrintFormat(LogType.Log, context, format, args);
        }

        #endregion

        #region Warning

        public static void Warning(string message)
        {
            Print(LogType.Warning, message);
        }

        public static void Warning(string message, Object context)
        {
            Print(LogType.Warning, message, context);
        }

        public static void Warning(params string[] messages)
        {
            Print(LogType.Warning, messages);
        }

        public static void Warning(Object context, params string[] messages)
        {
            Print(LogType.Warning, context, messages);
        }

        public static void WarningFormat(string format, params string[] args)
        {
            PrintFormat(LogType.Warning, format, args);
        }

        public static void WarningFormat(Object context, string format, params string[] args)
        {
            PrintFormat(LogType.Warning, context, format, args);
        }

        #endregion

        #region Error

        public static void Error(string message)
        {
            Print(LogType.Error, message);
        }

        public static void Error(string message, Object context)
        {
            Print(LogType.Error, message, context);
        }

        public static void Error(params string[] messages)
        {
            Print(LogType.Error, messages);
        }

        public static void Error(Object context, params string[] messages)
        {
            Print(LogType.Error, context, messages);
        }

        public static void ErrorFormat(string format, params string[] args)
        {
            PrintFormat(LogType.Error, format, args);
        }

        public static void ErrorFormat(Object context, string format, params string[] args)
        {
            PrintFormat(LogType.Error, context, format, args);
        }

        #endregion

        #region Exception

        public static void Exception(Exception e)
        {
            Logger.LogException(e);
        }

        public static void Exception(Exception e, Object context)
        {
            Logger.LogException(e, context);
        }

        public static void Exception(string message)
        {
            Logger.LogException(new Exception(message));
        }

        public static void Exception(string message, Object context)
        {
            Logger.LogException(new Exception(message), context);
        }

        #endregion

        private static void Print(LogType logType, string message, Object context = null)
        {
            Logger.Log(logType, Tag, message, context);
        }

        private static void Print(LogType logType, Object context, [NotNull] params string[] messages)
        {
            switch (messages.Length)
            {
                case 0:
                    Logger.LogException(new Exception("没有要拼接的字符串,params 的 Length 为 0."));
                    return;
                case 1:
                    Print(logType, messages[0], context);
                    break;
                case 2:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1]);
                        Print(logType, message, context);
                    }

                    break;
                case 3:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2]);
                        Print(logType, message, context);
                    }

                    break;
                case 4:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3]);
                        Print(logType, message, context);
                    }

                    break;
                case 5:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4]);
                        Print(logType, message, context);
                    }

                    break;
                case 6:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4],
                            messages[5]);
                        Print(logType, message, context);
                    }

                    break;
                case 7:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4],
                            messages[5], messages[6]);
                        Print(logType, message, context);
                    }

                    break;
                case 8:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4],
                            messages[5], messages[6], messages[7]);
                        Print(logType, message, context);
                    }

                    break;
                case 9:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4],
                            messages[5], messages[6], messages[7], messages[8]);
                        Print(logType, message, context);
                    }

                    break;
                case 10:
                    using (zstring.Block())
                    {
                        var message = zstring.Concat(messages[0], messages[1], messages[2], messages[3], messages[4],
                            messages[5], messages[6], messages[7], messages[8], messages[9]);
                        Print(logType, message, context);
                    }

                    break;
            }
        }

        private static void Print(LogType logType, [NotNull] params string[] messages)
        {
            Print(logType, null, messages);
        }

        private static void PrintFormat(LogType logType, string format, params string[] args)
        {
            PrintFormat(logType, null, format, args);
        }

        private static void PrintFormat(LogType logType, Object context, string format, params string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Print(logType, format, context);
                    break;
                case 1:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0]);
                        Print(logType, message, context);
                    }

                    break;
                case 2:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1]);
                        Print(logType, message, context);
                    }

                    break;
                case 3:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2]);
                        Print(logType, message, context);
                    }

                    break;
                case 4:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3]);
                        Print(logType, message, context);
                    }

                    break;
                case 5:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4]);
                        Print(logType, message, context);
                    }

                    break;
                case 6:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4], args[5]);
                        Print(logType, message, context);
                    }

                    break;
                case 7:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4], args[5], args[6]);
                        Print(logType, message, context);
                    }

                    break;
                case 8:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4], args[5], args[6], args[7]);
                        Print(logType, message, context);
                    }

                    break;
                case 9:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4], args[5], args[6], args[7], args[8]);
                        Print(logType, message, context);
                    }

                    break;
                case 10:
                    using (zstring.Block())
                    {
                        var message = zstring.Format(format, args[0], args[1], args[2],
                            args[3], args[4], args[5], args[6], args[7], args[8]
                            , args[9]);
                        Print(logType, message, context);
                    }

                    break;
            }
        }
    }
}