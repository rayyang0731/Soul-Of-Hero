#if UNITY_EDITOR
using System;
using TMPro;
using UnityEngine.UI;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 导出类型定义
    /// </summary>
    public static class ExportTypeDefine
    {
        /// <summary>
        /// 界面对象可导出的类型
        /// </summary>
        public static readonly Type[] UIObjectTyps =
        {
            typeof(TMP_InputField), typeof(InputField), typeof(UIButton), typeof(InputField), typeof(UIText),
            typeof(UIImage), typeof(UITransparentGraphic),
            typeof(Button), typeof(Image), typeof(Text)
        };
    }
}
#endif