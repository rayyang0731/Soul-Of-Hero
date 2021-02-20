using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KiwiFramework.Core;
using KiwiFramework.UI;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KiwiFramework.Editor.UI
{
    [CustomEditor(typeof(ViewDefine))]
    public class ViewDefineEditor : OdinEditor
    {
#if UNITY_EDITOR
        public struct MemberFieldInfo
        {
            public readonly Object Obj;
            public readonly string OriginName;
            private readonly int _index;
            public readonly string TypeName;
            public readonly string Path;

            public string ObjectName
            {
                get
                {
                    var result = OriginName.Replace(" ", "")
                        .Replace("(", "_")
                        .Replace(")", "_");
                    if (_index > 0)
                        result += "_" + _index;
                    return result;
                }
            }

            public MemberFieldInfo(Object obj, string originName, int index, string typeName, string path)
            {
                Obj = obj;
                OriginName = originName;
                _index = index;
                TypeName = typeName;
                Path = path;
            }
        }

        private SerializedProperty viewObjectBinder;

        protected override void OnEnable()
        {
            base.OnEnable();
            viewObjectBinder = serializedObject.FindProperty("viewObjectBinder");
        }

        public override void OnInspectorGUI()
        {
            SirenixEditorGUI.BeginHorizontalToolbar();
            GUIHelper.PushColor(Color.cyan);
            if (GUILayout.Button("收集界面对象", GUILayoutOptions.Height(35)))
            {
                GetAllObjects();
            }

            GUIHelper.PopColor();

            GUIHelper.PushColor(Color.green);
            if (GUILayout.Button("导出界面", GUILayoutOptions.Height(35)))
            {
                ExportView();
            }

            GUIHelper.PopColor();

            SirenixEditorGUI.EndHorizontalToolbar();
            base.OnInspectorGUI();
        }

        private const string BaseViewTemplatePath = "Assets/KiwiFramework/Templates/BaseViewTemplate.txt";
        private const string UIViewTemplatePath = "Assets/KiwiFramework/Templates/UIViewTemplate.txt";

        public List<MemberFieldInfo> GetAllObjects()
        {
            var define = target as ViewDefine;

            define.viewObjectBinder = new ViewObjectBinder();
            var memberFieldInfos = new List<MemberFieldInfo>();
            GetUIObject(ref memberFieldInfos, define.transform, name);

            foreach (var fieldInfo in memberFieldInfos)
            {
                define.viewObjectBinder.Add(fieldInfo.Obj);
            }

            return memberFieldInfos;
        }

        public void ExportView()
        {
            InternalExportView();
        }

        private void InternalExportView()
        {
            var viewScriptName = target.name;
            if (!viewScriptName.StartsWith("UI"))
                viewScriptName = "UI" + viewScriptName;
            if (!viewScriptName.EndsWith("View"))
                viewScriptName += "View";
            var baseViewScriptName = "Base" + viewScriptName;

            CreateBaseViewScript(baseViewScriptName);
            CreateUIViewScript(viewScriptName, baseViewScriptName);

            CreatePrefab(viewScriptName);
            AssetDatabase.Refresh();
        }

        private static void GetUIObject(ref List<MemberFieldInfo> infos, Transform parent, string path)
        {
            foreach (Transform child in parent)
            {
                if (!child.CompareTag(UITagDefine.UIObjectTag)) continue;
                var childPath = path + "/" + child.name;
                foreach (var type in ExportTypeDefine.UIObjectTyps)
                {
                    var uiObj = child.GetComponent(type);
                    if (!uiObj) continue;
                    if (infos.Any(fieldInfo => fieldInfo.Obj == uiObj))
                        throw new Exception("存在重复的 UIObject 要导出 : " + child.name);
                    var index = infos.Count(fieldInfo => fieldInfo.OriginName == child.name);
                    infos.Add(new MemberFieldInfo(uiObj, child.name, index, type.Name, childPath));
                    break;
                }

                GetUIObject(ref infos, child, childPath);
            }
        }

        private void CreateBaseViewScript(string baseViewScriptName)
        {
            var allMemberFields = GetAllMemberFieldsString();

            var baseViewTemplate = AssetDatabase.LoadAssetAtPath<TextAsset>(BaseViewTemplatePath).text;
            var baseViewString = baseViewTemplate.Replace("&ViewName&", baseViewScriptName)
                .Replace("&UIObjectField&", allMemberFields);

            var configPath = ProjectIniSetting.GetString("UI", "BaseViewPath", "/Scripts/UI/BaseView/");
            var baseViewPath = Directory.CreateDirectory(
                Application.dataPath + configPath).FullName;
            baseViewPath += baseViewScriptName + ".cs";

            if (File.Exists(baseViewPath))
                File.Delete(baseViewPath);

            using (var sw = new StreamWriter(File.OpenWrite(baseViewPath)))
            {
                sw.Write(baseViewString);
                sw.Flush();
            }

            AssetDatabase.ImportAsset("Assets" + configPath);
        }

        private void CreateUIViewScript(string uiViewScriptName, string baseViewScriptName)
        {
            var uiViewTemplate = AssetDatabase.LoadAssetAtPath<TextAsset>(UIViewTemplatePath).text;
            var uiViewString = uiViewTemplate.Replace("&ViewName&", uiViewScriptName)
                .Replace("&BaseViewName&", baseViewScriptName);

            var configPath = ProjectIniSetting.GetString("UI", "UIViewPath", "/Scripts/UI/UIView/");
            var uiViewPath = Directory.CreateDirectory(
                Application.dataPath + configPath).FullName;
            uiViewPath += uiViewScriptName + ".cs";

            if (File.Exists(uiViewPath)) return;

            using (var sw = new StreamWriter(File.Create(uiViewPath)))
            {
                sw.Write(uiViewString);
                sw.Flush();
            }

            AssetDatabase.ImportAsset("Assets" + configPath);
        }

        private void CreatePrefab(string viewName)
        {
            var define = target as ViewDefine;

            var viewPrefabPath =
                $"Assets/GameAssets/{ProjectIniSetting.GetString("GameAssetsPath", "ViewPrefabPath")}/";
            if (!Directory.Exists(viewPrefabPath))
                Directory.CreateDirectory(viewPrefabPath);
            viewPrefabPath += viewName + ".prefab";
            PrefabUtility.SaveAsPrefabAssetAndConnect(define.gameObject, viewPrefabPath,
                InteractionMode.AutomatedAction, out
                var isSuccessful);
            if (isSuccessful)
                AssetDatabase.Refresh();
        }

        private string GetAllMemberFieldsString()
        {
            var result = new StringBuilder();

            var fieldInfos = GetAllObjects();
            for (var i = 0; i < fieldInfos.Count; i++)
            {
                var typeName = fieldInfos[i].TypeName;
                var publicObjectName = fieldInfos[i].ObjectName.Substring(0, 1).ToLower() +
                                       fieldInfos[i].ObjectName.Substring(1);
                var privateObjName = "_" + fieldInfos[i].ObjectName.Substring(0, 1).ToLower() +
                                     fieldInfos[i].ObjectName.Substring(1);
                result.AppendLine($"        private {typeName} {privateObjName};");
                result.AppendLine($"        //{fieldInfos[i].Path}");
                result.AppendLine($"        public {typeName} {publicObjectName}");
                result.AppendLine("        {");
                result.AppendLine("            get");
                result.AppendLine("            {");
                result.AppendLine($"                if(!{privateObjName})");
                result.AppendLine(
                    $"                    {privateObjName} = define.viewObjectBinder.Get({i}) as {typeName};");
                result.AppendLine($"                return {privateObjName};");
                result.AppendLine("            }");
                result.AppendLine("        }");
                result.AppendLine();
            }

            return result.ToString();
        }

#endif
    }
}