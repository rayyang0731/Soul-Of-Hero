using UnityEngine;

namespace KiwiFramework.Core
{
    public static partial class Extend
    {
        /// <summary>
        /// 设置Transform的父物体,并对相对坐标赋值
        /// </summary>
        /// <param name="parent">父物体目标</param>
        /// <param name="localPosition">父物体下的相对坐标</param>
        public static void SetParent(this Transform transform, Transform parent, Vector3 localPosition)
        {
            transform.SetParent(parent, true);
            transform.localPosition = localPosition;
        }
    }
}