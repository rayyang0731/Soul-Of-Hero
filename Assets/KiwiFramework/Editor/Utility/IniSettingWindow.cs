using System.Collections.Generic;
using System.IO;
using System.Linq;
using KiwiFramework.Core;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace KiwiFramework.Editor
{
    public class IniSettingWindow : OdinEditorWindow
    {
        public static IniSettingWindow ShowWindow()
        {
            var window = GetWindowWithRect<IniSettingWindow>(GUIHelper.GetEditorWindowRect().AlignCenter(500, 500),
                true, "配置文件", true);
            window.maxSize = window.minSize = new Vector2(800, 500);
            window.UseScrollView = true;

            GetProjectIniData();
            GetRuntimeIniData();

            window.OnClose += () =>
            {
                _projectIniParser.Close();
                _runtimeIniParser.Close();
                _projectIniData = null;
                _runtimeIniData = null;
            };

            return window;
        }

        private readonly struct DataStruct
        {
            public readonly string SectionName;
            public readonly string Key;
            [TableColumnWidth(450)] public readonly string Value;

            public DataStruct(string sectionName, string key, string value)
            {
                SectionName = sectionName;
                Key = key;
                Value = value;
            }
        }

        private static INIParser _projectIniParser;
        private static INIParser _runtimeIniParser;

        #region 项目配置文件

        /// <summary>
        /// 项目配置文件地址
        /// </summary>
        private static string ProjectIniFilePath => Application.dataPath + "/KiwiFramework/ProjectConfig.ini";

        /// <summary>
        /// 项目配置模板文件地址
        /// </summary>
        private static string ProjectIniTemplateFilePath =>
            Application.dataPath + "/KiwiFramework/Templates/ProjectIniTemplate.txt";

        private static void GetProjectIniData()
        {
            _projectIniData.Clear();

            if (_projectIniParser == null)
                _projectIniParser = new INIParser();

            _projectIniParser.Close();
            _projectIniParser.Open(ProjectIniFilePath, true);

            foreach (var section in _projectIniParser.All)
            {
                var sectionName = section.Key;
                foreach (var data in section.Value)
                {
                    var key = data.Key;
                    var val = data.Value;
                    _projectIniData.Add(new DataStruct(sectionName, key, val));
                }
            }
        }

        [ShowInInspector, HideLabel, TableList(AlwaysExpanded = true), TabGroup("Tab", "项目配置文件")]
        private static List<DataStruct> _projectIniData = new List<DataStruct>();

        [ResponsiveButtonGroup("Tab/项目配置文件/Button"), Button("默认数据", ButtonSizes.Gigantic),
         GUIColor(1, 0, 0)]
        private void UseProjectDefaultIniFile()
        {
            if (!EditorUtility.DisplayDialog("重置配置文件", "是否要清除当前数据,使用默认配置文件?", "确定", "取消")) return;

            _projectIniParser.Close();

            using (var streamWriter = new StreamWriter(ProjectIniFilePath, false))
            {
                using (var streamReader = File.OpenText(ProjectIniTemplateFilePath))
                {
                    streamWriter.Write(streamReader.ReadToEnd());
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            GetProjectIniData();
        }

        [ResponsiveButtonGroup("Tab/项目配置文件/Button"), Button("当前数据", ButtonSizes.Gigantic),
         GUIColor(0, 1, 1)]
        private void LoadCurrentProjectIniFile()
        {
            if (!EditorUtility.DisplayDialog("重置配置文件", "是否要清除当前数据,使用当前配置文件?", "确定", "取消")) return;
            GetProjectIniData();
        }

        [ResponsiveButtonGroup("Tab/项目配置文件/Button"), Button("保存", ButtonSizes.Gigantic),
         GUIColor(0, 1, 0)]
        private void SaveProjectIniFile()
        {
            if (!EditorUtility.DisplayDialog("保存配置文件", "是否要保存当前配置信息?", "确定", "取消")) return;

            var originData = new Dictionary<string, Dictionary<string, string>>(_projectIniParser.All);
            var wannaDelete = new List<KV<string, string>>();
            foreach (var section in originData)
            {
                var sectionName = section.Key;
                if (!_projectIniData.Any((data => data.SectionName == sectionName)))
                {
                    _projectIniParser.SectionDelete(sectionName);
                }
                else
                {
                    foreach (var iniData in section.Value)
                    {
                        if (!_projectIniData.Any(data => data.SectionName == sectionName && data.Key == iniData.Key))
                        {
                            wannaDelete.Add(new KV<string, string>(sectionName, iniData.Key));
                        }
                    }

                    wannaDelete.ForEach(action => _projectIniParser.KeyDelete(action.Key, action.Value));
                }
            }

            _projectIniData.Where(data => !string.IsNullOrEmpty(data.SectionName) && !string.IsNullOrEmpty(data.Key))
                .ForEach(data => { _projectIniParser.WriteValue(data.SectionName, data.Key, data.Value); });

            AssetDatabase.Refresh();

            ShowNotification(new GUIContent("保存成功"), 1);
        }

        #endregion

        #region 运行时配置文件

        /// <summary>
        /// 运行时配置文件地址
        /// </summary>
        private static string RuntimeIniFilePath => Application.streamingAssetsPath + "/RuntimeConfig.ini";

        /// <summary>
        /// 运行时配置模板文件地址
        /// </summary>
        private static string RuntimeIniTemplateFilePath =>
            Application.dataPath + "/KiwiFramework/Templates/RuntimeIniTemplate.txt";

        private static void GetRuntimeIniData()
        {
            _runtimeIniData.Clear();

            if (_runtimeIniParser == null)
                _runtimeIniParser = new INIParser();

            _runtimeIniParser.Close();

            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                CreateDefaultIniFile();
            }

            _runtimeIniParser.Open(RuntimeIniFilePath, true);

            foreach (var section in _runtimeIniParser.All)
            {
                var sectionName = section.Key;
                foreach (var data in section.Value)
                {
                    var key = data.Key;
                    var val = data.Value;
                    _runtimeIniData.Add(new DataStruct(sectionName, key, val));
                }
            }
        }

        [ShowInInspector, HideLabel, TableList(AlwaysExpanded = true), TabGroup("Tab", "运行时配置文件")]
        private static List<DataStruct> _runtimeIniData = new List<DataStruct>();

        [ResponsiveButtonGroup("Tab/运行时配置文件/Button"), Button("默认数据", ButtonSizes.Gigantic),
         GUIColor(1, 0, 0)]
        private void UseRuntimeDefaultIniFile()
        {
            if (!EditorUtility.DisplayDialog("重置配置文件", "是否要清除当前数据,使用默认配置文件?", "确定", "取消")) return;

            _runtimeIniParser.Close();

            CreateDefaultIniFile();

            GetProjectIniData();
        }

        private static void CreateDefaultIniFile()
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
                Directory.CreateDirectory(Application.streamingAssetsPath);

            using (var streamWriter = new StreamWriter(RuntimeIniFilePath, false))
            {
                using (var streamReader = File.OpenText(RuntimeIniTemplateFilePath))
                {
                    streamWriter.Write(streamReader.ReadToEnd());
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            AssetDatabase.Refresh();
        }

        [ResponsiveButtonGroup("Tab/运行时配置文件/Button"), Button("当前数据", ButtonSizes.Gigantic),
         GUIColor(0, 1, 1)]
        private void LoadCurrentRuntimeIniFile()
        {
            if (!EditorUtility.DisplayDialog("重置配置文件", "是否要清除当前数据,使用当前配置文件?", "确定", "取消")) return;
            GetRuntimeIniData();
        }

        [ResponsiveButtonGroup("Tab/运行时配置文件/Button"), Button("保存", ButtonSizes.Gigantic),
         GUIColor(0, 1, 0)]
        private void SaveRuntimeIniFile()
        {
            if (!EditorUtility.DisplayDialog("保存配置文件", "是否要保存当前配置信息?", "确定", "取消")) return;

            var originData = new Dictionary<string, Dictionary<string, string>>(_runtimeIniParser.All);
            var wannaDelete = new List<KV<string, string>>();
            foreach (var section in originData)
            {
                var sectionName = section.Key;
                if (!_runtimeIniData.Any((data => data.SectionName == sectionName)))
                {
                    _runtimeIniParser.SectionDelete(sectionName);
                }
                else
                {
                    foreach (var iniData in section.Value)
                    {
                        if (!_runtimeIniData.Any(data => data.SectionName == sectionName && data.Key == iniData.Key))
                        {
                            wannaDelete.Add(new KV<string, string>(sectionName, iniData.Key));
                        }
                    }

                    wannaDelete.ForEach(action => _runtimeIniParser.KeyDelete(action.Key, action.Value));
                }
            }

            _runtimeIniData.Where(data => !string.IsNullOrEmpty(data.SectionName) && !string.IsNullOrEmpty(data.Key))
                .ForEach(data => { _runtimeIniParser.WriteValue(data.SectionName, data.Key, data.Value); });

            AssetDatabase.Refresh();

            ShowNotification(new GUIContent("保存成功"), 1);
        }

        #endregion
    }
}