using KiwiFramework.Core;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace KiwiFramework.UI
{
    /// <summary>
    /// 扩展 RectTransform 编辑器面板,添加重置位置,旋转,缩放的按钮和位置,宽高取整的按钮
    /// </summary>
    [CustomEditor(typeof(RectTransform), true)]
    public class RectTransformEditor : DecoratorEditor
    {
        public RectTransformEditor() : base("RectTransformEditor")
        {
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SirenixEditorGUI.BeginIndentedHorizontal("Box");
            GUILayout.Label(EditorIcons.Refresh.Active, GUILayoutOptions.Width(18).Height(18));
            ResetPos();
            ResetRot();
            ResetScale();
            SirenixEditorGUI.EndIndentedHorizontal();
            Rounding();
        }

        private void ResetPos()
        {
            GUIHelper.PushColor(Color.cyan, false);
            if (!GUILayout.Button("position")) return;
            var rt = target as RectTransform;
            if (rt != null) rt.localPosition = Vector3.zero;
            GUIHelper.PopColor();
        }

        private void ResetRot()
        {
            GUIHelper.PushColor(Color.green, false);
            if (!GUILayout.Button("rotation")) return;
            var rt = target as RectTransform;
            if (rt != null) rt.localEulerAngles = Vector3.zero;
            GUIHelper.PopColor();
        }

        private void ResetScale()
        {
            GUIHelper.PushColor(Color.yellow, false);
            if (!GUILayout.Button("scale")) return;
            var rt = target as RectTransform;
            if (rt != null) rt.localScale = Vector3.one;
            GUIHelper.PopColor();
        }

        private void Rounding()
        {
            GUIHelper.PushColor(new Color(1, 0.5f, 0f), false);
            if (!GUILayout.Button("Round")) return;
            var rt = target as RectTransform;
            if (rt != null)
            {
                var pos = Vector3Int.RoundToInt(rt.localPosition);
                rt.localPosition = pos;
                var size = Vector2Int.RoundToInt(rt.rect.size);
                rt.SetSize(size);
            }

            GUIHelper.PopColor();
        }
    }
}