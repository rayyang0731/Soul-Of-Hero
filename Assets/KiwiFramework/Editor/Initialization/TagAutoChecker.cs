using System.Linq;
using KiwiFramework.UI;
using UnityEditor;
using UnityEditorInternal;

namespace KiwiFramework.Editor
{
    /// <summary>
    /// 为项目自动添加 Tag
    /// </summary>
    [InitializeOnLoad]
    public class TagAutoChecker
    {
        static TagAutoChecker()
        {
            TryToAddTag(UITagDefine.MainCanvasTag);
            TryToAddTag(UITagDefine.UIViewTag);
            TryToAddTag(UITagDefine.UIObjectTag);
        }

        /// <summary>
        /// 检测当前工程是否存在此 Tag
        /// </summary>
        /// <param name="tag">目标 Tag</param>
        /// <returns></returns>
        private static bool IsExistTag(string tag)
        {
            return InternalEditorUtility.tags.Any(tags => tags.Contains(tag));
        }

        /// <summary>
        /// 尝试为工程添加 Tag
        /// </summary>
        /// <param name="tag">目标 Tag</param>
        private static void TryToAddTag(string tag)
        {
            if (IsExistTag(tag)) return;
            InternalEditorUtility.AddTag(tag);
        }
    }
}