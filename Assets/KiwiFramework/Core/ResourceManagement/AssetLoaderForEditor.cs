using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameFramework;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace KiwiFramework.Core
{
#if UNITY_EDITOR
    /// <summary>
    /// 编辑器下使用的资源加载器
    /// </summary>
    public class AssetLoaderForEditor : BaseAssetLoader
    {
        private bool _initialized = false;

        private string[] _assetSearchPaths = null;

        /// <summary>
        /// 工程内搜索全部的搜索路径,在 ProjectConfig 中配置
        /// </summary>
        private string[] AssetSearchPaths
        {
            get
            {
                if (_assetSearchPaths != null) return _assetSearchPaths;

                var path = new List<string>();
                ProjectIniSetting.All["GameAssetsPath"]
                    .ForEach(pair => path.Add("Assets/GameAssets/" + pair.Value));
                _assetSearchPaths = path.ToArray();

                return _assetSearchPaths;
            }
        }

        /// <summary>
        /// 全部资源的路径
        /// </summary>
        private readonly Dictionary<string, string> _allAssetPaths = new Dictionary<string, string>();

        /// <summary>
        /// 获取资源对象路径
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <returns></returns>
        private string GetAssetPath(string name)
        {
            _allAssetPaths.TryGetValue(name, out var assetPath);
            if (assetPath != null) return assetPath;

            var assetGUIDs = AssetDatabase.FindAssets(name + " t:Object", AssetSearchPaths);
            if (assetGUIDs.Length >= 1)
            {
                var repeatAssets = new List<string>();
                foreach (var guid in assetGUIDs)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var fileName = Path.GetFileNameWithoutExtension(path);
                    if (fileName != name)
                        continue;
                    repeatAssets.Add(path);
                    if (_allAssetPaths.ContainsKey(name))
                        _allAssetPaths[name] = path;
                    else
                        _allAssetPaths.Add(name, path);
                }

                if (repeatAssets.Count <= 1) return _allAssetPaths[name];

                var sb = new StringBuilder();
                sb.AppendLine("不应该有重名的的资源 : ");
                sb.AppendFormat("资源名称[{0}]的数量有{1}个,应当修改资源的名称,保证资源名称没有重复.", name, repeatAssets.Count);
                sb.AppendLine("重名资源地址如下 : ");
                repeatAssets.ForEach(p => sb.AppendLine(p));
                KiwiLog.Exception(sb.ToString());
            }
            else
            {
                _allAssetPaths[name] = string.Empty;
            }

            return _allAssetPaths[name];
        }

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="name">资源类型</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T Load<T>(string name)
        {
            var path = GetAssetPath(name);
            return AssetDatabase.LoadAssetAtPath<T>(path);
        }
    }
#endif
}