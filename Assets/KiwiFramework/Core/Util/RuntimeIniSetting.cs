using System;
using UnityEngine;

namespace KiwiFramework.Core
{
    /// <summary>
    /// 工程配置文件管理工具
    /// </summary>
    public static class RuntimeIniSetting
    {
        private static string IniPath => Application.dataPath + "/KiwiFramework/ProjectConfig.ini";

        private static INIParser _iniParser;

        private static INIParser IniParser
        {
            get
            {
                if (_iniParser != null) return _iniParser;

                _iniParser = new INIParser();
                _iniParser.Open(IniPath, true);

                Application.wantsToQuit += () =>
                {
                    _iniParser.Close();
                    return true;
                };
                return _iniParser;
            }
        }

        #region Get

        public static bool GetBool(string sectionName, string key, bool defaultValue = true)
        {
            return IniParser.ReadValue(sectionName, key, defaultValue);
        }

        public static int GetInt(string sectionName, string key, int defaultValue = 0)
        {
            return IniParser.ReadValue(sectionName, key, defaultValue);
        }

        public static long GetLong(string sectionName, string key, long defaultValue = 0L)
        {
            return IniParser.ReadValue(sectionName, key, defaultValue);
        }

        public static double GetDouble(string sectionName, string key, double defaultValue = 0d)
        {
            return IniParser.ReadValue(sectionName, key, defaultValue);
        }

        public static string GetString(string sectionName, string key, string defaultValue = "")
        {
            return IniParser.ReadValue(sectionName, key, defaultValue);
        }

        #region byte[]

        public static byte[] GetBytes(string sectionName, string key)
        {
            GetBytes(sectionName, key, out var result);
            return result;
        }

        public static bool GetBytes(string sectionName, string key, out byte[] returnValue)
        {
            return GetBytes(sectionName, key, null, out returnValue);
        }

        public static bool GetBytes(string sectionName, string key, byte[] defaultValue, out byte[] returnValue)
        {
            var isExist = IniParser.IsKeyExists(sectionName, key);
            returnValue = IniParser.ReadValue(sectionName, key, defaultValue);
            return isExist;
        }

        #endregion

        #region DateTime

        public static DateTime GetDateTime(string sectionName, string key)
        {
            GetDateTime(sectionName, key, out var result);
            return result;
        }

        public static bool GetDateTime(string sectionName, string key, out DateTime returnValue)
        {
            var defaultValue = DateTime.Now;
            return GetDateTime(sectionName, key, defaultValue, out returnValue);
        }

        public static bool GetDateTime(string sectionName, string key, DateTime defaultValue, out DateTime returnValue)
        {
            var isExist = IniParser.IsKeyExists(sectionName, key);
            returnValue = IniParser.ReadValue(sectionName, key, defaultValue);
            return isExist;
        }

        #endregion

        #endregion

        #region Set

        public static void SetBool(string sectionName, string key, bool value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetInt(string sectionName, string key, int value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetLong(string sectionName, string key, long value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetDouble(string sectionName, string key, double value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetString(string sectionName, string key, string value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetBytes(string sectionName, string key, byte[] value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        public static void SetDateTime(string sectionName, string key, DateTime value)
        {
            IniParser.WriteValue(sectionName, key, value);
        }

        #endregion
    }
}