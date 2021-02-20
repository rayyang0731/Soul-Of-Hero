using UnityEngine;
using Sirenix.OdinInspector;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 图片状态数据
    /// </summary>
    [System.Serializable]
    public struct TextStateData
    {
#if UNITY_EDITOR
        /// <summary>
        /// 状态名称
        /// </summary>
        [LabelText("状态名称"), LabelWidth(60), HorizontalGroup("Data"), VerticalGroup("Data/Label")]
        [PropertyTooltip("仅为了在Editor中备注状态名称,代码中无实际调用")]
        public string name;
#endif
        [LabelText("使用i18n"), LabelWidth(60), ToggleGroup("Data/Label/use_i18n", "国际化配置")]
        public bool use_i18n;
        [LabelText("配置表名称"), ToggleGroup("Data/Label/use_i18n")]
        public string tableName;
        [LabelText("配置表ID"), ToggleGroup("Data/Label/use_i18n")]
        public int tableID;

        [LabelText("重载字体"), LabelWidth(60), HorizontalGroup("Data/Label/Font")]
        public bool overrideFont;
        /// <summary>
        /// 状态所用图片
        /// </summary>
        [HideLabel, HorizontalGroup("Data/Label/Font")]
        [ShowIf("overrideFont")]
        public Font font;
        /// <summary>
        /// 是否重载颜色
        /// </summary>
        [LabelText("重载颜色"), LabelWidth(60), HorizontalGroup("Data/Label/Color")]
        public bool overrideColor;
        /// <summary>
        /// 状态所用颜色
        /// </summary>
        [HideLabel, ShowIf("overrideColor"), HorizontalGroup("Data/Label/Color"),PropertySpace(0,20)]
        public Color color;
#if UNITY_EDITOR
        /// <summary>
        /// 默认数据
        /// </summary>
        public static TextStateData Default
        {
            get
            {
                return new TextStateData("State Name", false, string.Empty, -1, false, null, false, Color.black);
            }
        }

        public TextStateData(string _name, bool _use_i18n, string _tableName, int _tableID, bool _overrideFont, Font _font, bool _overrideColor, Color _color)
        {
            name = _name;
            use_i18n = _use_i18n;
            tableName = _tableName;
            tableID = _tableID;
            overrideFont = _overrideFont;
            font = _font;
            overrideColor = _overrideColor;
            color = _color;
        }
#else
        /// <summary>
        /// 默认数据
        /// </summary>
        public static TextStateData Default
        {
            get
            {
                return new TextStateData(false, string.Empty, -1, false, null, false, Color.black);
            }
        }

        public TextStateData(bool _use_i18n, string _tableName, int _tableID, bool _overrideFont, Font _font, bool _overrideColor, Color _color)
        {
            use_i18n = _use_i18n;
            tableName = _tableName;
            tableID = _tableID;
            overrideFont = _overrideFont;
            font = _font;
            overrideColor = _overrideColor;
            color = _color;
        }
#endif
    }
}