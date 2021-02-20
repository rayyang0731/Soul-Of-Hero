using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using GameFramework;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace KiwiFramework.Core
{
    public static partial class KiwiLog
    {
        private class KiwiLogHandler : ILogHandler
        {
            private const string LOG_NAME = "Game.log";

            private readonly string _filePath;
            private FileStream _fileStream;
            private StreamWriter _streamWriter;
            private Thread _logWriterThread;
            private Queue<string> _logQueue;

            private ILogHandler _defaultLogHandler;

            private volatile bool _stopThreadSign = false;

            private bool _enableWriteLog = true;

            /// <summary>
            /// 是否开启 Log 本地输出
            /// </summary>
            public bool EnableWriteLog
            {
                get => _enableWriteLog;
                set
                {
                    _enableWriteLog = value;
                    if (value)
                        EnableWrite();
                    else
                        DisableWrite();
                }
            }

            public bool needOutputStackTrace = true;

            public KiwiLogHandler()
            {
                using (zstring.Block())
                {
#if UNITY_EDITOR
                    _filePath = zstring.Concat(Application.dataPath, "/", LOG_NAME).Intern();
#else
                _filePath = zstring.Concat(Application.persistentDataPath, "/", LOG_NAME).Intern();
#endif
                }

                _defaultLogHandler = Debug.unityLogger.logHandler;
            }

            /// <summary>
            /// 打开 Log 本地输出
            /// </summary>
            private void EnableWrite()
            {
                _fileStream = new FileStream(_filePath, FileMode.Create, FileAccess.ReadWrite);
                _streamWriter = new StreamWriter(_fileStream) {AutoFlush = true};

                _logQueue = new Queue<string>();

                _stopThreadSign = false;

                _logWriterThread = new Thread(WriteLog);
                _logWriterThread.Start();

                Application.wantsToQuit += Application_wantsToQuit;

                Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
            }

            /// <summary>
            /// 关闭 Log 本地输出
            /// </summary>
            private void DisableWrite()
            {
                Application.logMessageReceivedThreaded -= Application_logMessageReceivedThreaded;

                _stopThreadSign = true;

                if (_logWriterThread != null && _logWriterThread.IsAlive)
                    _logWriterThread.Join();

                if (_streamWriter != null)
                {
                    _streamWriter.Close();
                    _streamWriter = null;
                }

                if (_fileStream != null)
                {
                    _fileStream.Close();
                    _fileStream = null;
                }

                if (_logQueue != null)
                {
                    _logQueue.Clear();
                    _logQueue = null;
                }

                Application.wantsToQuit -= Application_wantsToQuit;
            }

            private bool Application_wantsToQuit()
            {
                DisableWrite();
                return true;
            }

            private void Application_logMessageReceivedThreaded(string condition, string stacktrace, LogType type)
            {
                if (!_enableWriteLog && type == LogType.Warning)
                    return;

                using (zstring.Block())
                {
                    _logQueue.Enqueue(needOutputStackTrace
                        ? zstring.Concat(condition, "\n", stacktrace, "\n")
                        : zstring.Concat(condition, "\n\n"));
                }
            }

            public void LogFormat(LogType logType, Object context, string format, params object[] args)
            {
                _defaultLogHandler.LogFormat(logType, context, format, args);
            }

            public void LogException(Exception exception, Object context)
            {
                _defaultLogHandler.LogException(exception, context);
            }

            /// <summary>
            /// 写入本地 Log
            /// </summary>
            private void WriteLog()
            {
                while (true)
                {
                    if (_logQueue.Count > 0)
                        _streamWriter.Write(_logQueue.Dequeue());

                    if (_logQueue.Count == 0 && _stopThreadSign)
                        break;
                    Thread.Sleep(10);
                }
            }
        }
    }
}