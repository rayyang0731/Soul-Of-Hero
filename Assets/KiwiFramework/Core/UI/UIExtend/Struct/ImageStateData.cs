using UnityEngine;
using Sirenix.OdinInspector;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 图片状态数据
    /// </summary>
    [System.Serializable]
    public struct ImageStateData
    {
#if UNITY_EDITOR
        /// <summary>
        /// 状态名称
        /// </summary>
        [LabelText("状态名称"), LabelWidth(60), VerticalGroup("Data/Label")] [PropertyTooltip("仅为了在Editor中备注状态名称,代码中无实际调用")]
        public string name;
#endif
        /// <summary>
        /// 状态所用图片
        /// </summary>
        [HideLabel, HorizontalGroup("Data", 50), VerticalGroup("Data/Sprite")]
        [PreviewField(50, ObjectFieldAlignment.Right)]
        public Sprite sprite;

        /// <summary>
        /// 是否重载颜色
        /// </summary>
        [LabelText("重载颜色"), PropertyTooltip("Override color"), LabelWidth(60), HorizontalGroup("Data/Label/Color")]
        public bool overrideColor;

        /// <summary>
        /// 状态所用颜色
        /// </summary>
        [HideLabel, ShowIf("overrideColor"), HorizontalGroup("Data/Label/Color")]
        public Color color;

        /// <summary>
        /// 是否自动设置为图片原大小
        /// </summary>
        [LabelText("原图大小"), PropertyTooltip("Native size"), LabelWidth(60), VerticalGroup("Data/Label")]
        public bool autoUseNativeSize;

        /// <summary>
        /// 是否重载尺寸
        /// </summary>
        [LabelText("重载尺寸"), PropertyTooltip("Override size"), LabelWidth(60), HorizontalGroup("Data/Label/Size"),
         DisableIf("autoUseNativeSize"),]
        public bool overrideSize;

        /// <summary>
        /// Sprite的显示尺寸
        /// </summary>
        [HideLabel, LabelWidth(60), HorizontalGroup("Data/Label/Size"), ShowIf("overrideSize")]
        public Vector2 size;
#if UNITY_EDITOR
        /// <summary>
        /// 默认数据
        /// </summary>
        public static ImageStateData Default
        {
            get { return new ImageStateData("State Name", null, false, Color.white, false, false, Vector2.one * 100); }
        }

        public ImageStateData(string _name, Sprite _sprite, bool _overrideColor, Color _color, bool _autoUseNativeSize,
            bool _overrideSize, Vector2 _size)
        {
            name = _name;
            sprite = _sprite;
            overrideColor = _overrideColor;
            color = _color;
            autoUseNativeSize = _autoUseNativeSize;
            overrideSize = _overrideSize;
            size = _size;
        }
#else
        public static ImageStateData Default
        {
            get
            {
                return new ImageStateData(null, false, Color.white, false, false, Vector2.one * 100);
            }
        }

        public ImageStateData(Sprite _sprite, bool _overrideColor, Color _color, bool _autoUseNativeSize, bool _overrideSize, Vector2 _size)
        {
            sprite = _sprite;
            color = _color;
            overrideColor = _overrideColor;
            autoUseNativeSize = _autoUseNativeSize;
            overrideSize = _overrideSize;
            size = _size;
        }
#endif
    }
}