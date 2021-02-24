using System.Collections.Generic;
using System.IO;
using Sirenix.Utilities;
using UnityEditor;
using UnityEngine;

namespace KiwiFramework.Core
{
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly BaseAssetLoader _assetLoader;

        public AssetManager()
        {
#if UNITY_EDITOR
            _assetLoader = new AssetLoaderForEditor();
#endif
        }

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns></returns>
        public T Load<T>(string name) where T : Object
        {
            return _assetLoader.Load<T>(name);
        }
    }
}