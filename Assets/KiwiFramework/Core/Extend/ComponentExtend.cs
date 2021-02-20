using UnityEngine;

namespace KiwiFramework.Core
{
    public static partial class Extend
    {
        public static RectTransform rectTransform(this Component cp)
        {
            return cp.transform as RectTransform;
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <typeparam name="T">目标组件必须继承自Component</typeparam>
        /// <returns>目标组件</returns>
        public static T ForceGetComponent<T>(this Component cp) where T : Component
        {
            return cp.ForceGetComponent<T>(out bool exist);
        }

        /// <summary>
        /// 强制获得对象组件,如果对象未挂载目标组件,则为该对象添加组件
        /// </summary>
        /// <param name="exist">想要获取的组件是否存在</param>
        /// <typeparam name="T">目标组件必须继承自Component</typeparam>
        /// <returns>目标组件</returns>
        public static T ForceGetComponent<T>(this Component cp, out bool exist) where T : Component
        {
            exist = cp.TryGetComponent(out T result);
            if (!exist)
                result = cp.gameObject.AddComponent<T>();

            return result;
        }
    }
}