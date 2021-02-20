using UnityEngine;

namespace KiwiFramework.Core
{
    public partial class KiwiLog
    {
        private class KiwiLogger : Logger
        {
            public bool EnableWriteLog
            {
                get => ((KiwiLogHandler) logHandler).EnableWriteLog;
                set => ((KiwiLogHandler) logHandler).EnableWriteLog = value;
            }

            public bool OutputStackTrace
            {
                get => ((KiwiLogHandler) logHandler).needOutputStackTrace;
                set => ((KiwiLogHandler) logHandler).needOutputStackTrace = value;
            }

            private const string const_IniSectionName = "Log";
            private const string const_EnableLog_IniKey = "EnableLog";
            private const string const_EnableLogOutput_IniKey = "EnableLogOutput";
            private const string const_OutputStackTrace_IniKey = "OutputStackTrace";

            public KiwiLogger(ILogHandler logHandler) : base(logHandler)
            {
                this.logHandler = new KiwiLogHandler();
                logEnabled = RuntimeIniSetting.GetBool(const_IniSectionName, const_EnableLog_IniKey);
                ((KiwiLogHandler) this.logHandler).EnableWriteLog =
                    RuntimeIniSetting.GetBool(const_IniSectionName, const_EnableLogOutput_IniKey);
                OutputStackTrace = RuntimeIniSetting.GetBool(const_IniSectionName, const_OutputStackTrace_IniKey);
            }
        }
    }
}