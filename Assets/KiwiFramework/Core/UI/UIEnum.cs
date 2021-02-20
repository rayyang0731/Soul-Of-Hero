using Sirenix.OdinInspector;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 界面类型
    /// </summary>
    public enum VIEW_TYPE : byte
    {
        [LabelText("全屏界面")] FULL_SCREEN = 0,

        [LabelText("模态界面(透明遮罩)")] MODAL_TRANSPARENT = 1,

        [LabelText("模态界面(半透灰遮罩)")] MODAL_BLACK = 2
    }

    /// <summary>
    /// 界面逻辑类型
    /// </summary>
    public enum VIEW_LOGIC_TYPE : byte
    {
        [LabelText("可回退界面")] ROLLBACK = 0,
        [LabelText("普通界面")] NORMAL = 1,
    }
    
    /// <summary>
    /// 点击类型
    /// </summary>
    public enum POINTER_TYPE : byte
    {
        /// <summary>
        /// 按下
        /// </summary>
        DOWN,

        /// <summary>
        /// 抬起
        /// </summary>
        UP,

        /// <summary>
        /// 点击
        /// </summary>
        CLICK,

        /// <summary>
        /// 重复响应
        /// </summary>
        REPEAT_RESPONE,
    }
}