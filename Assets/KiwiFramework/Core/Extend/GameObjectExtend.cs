using UnityEngine;

namespace KiwiFramework.Core
{
    public static partial class Extend
    {
        public static RectTransform rectTransform(this GameObject go)
        {
            return go.transform as RectTransform;
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <typeparam name="T">目标组件必须继承自Component</typeparam>
        /// <returns>目标组件</returns>
        public static T ForceGetComponent<T>(this GameObject go) where T : Component
        {
            return go.ForceGetComponent<T>(out _);
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <param name="exist">想要获取的组件是否存在</param>
        /// <typeparam name="T">目标组件必须继承自Component</typeparam>
        /// <returns>目标组件</returns>
        public static T ForceGetComponent<T>(this GameObject go, out bool exist) where T : Component
        {
            exist = true;
            var result = go.GetComponent<T>();
            if (result != null) return result;
            result = go.AddComponent<T>();
            exist = false;

            return result;
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <param name="type">目标组件必须继承自Component</param>
        /// <returns>目标组件</returns>
        public static Component ForceGetComponent(this GameObject go, string type)
        {
            return go.ForceGetComponent(type, out _);
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <param name="exist">想要获取的组件是否存在</param>
        /// <typeparam name="T">目标组件必须继承自Component</typeparam>
        /// <returns>目标组件</returns>
        public static Component ForceGetComponent(this GameObject go, string type, out bool exist)
        {
            exist = true;
            var componentType = System.Type.GetType(type);
            var result = go.GetComponent(componentType);
            if (result != null) return result;
            result = go.AddComponent(componentType);
            exist = false;

            return result;
        }
    }
}