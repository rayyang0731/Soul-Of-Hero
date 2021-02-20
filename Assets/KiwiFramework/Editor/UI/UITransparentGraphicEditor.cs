using System.Collections;
using System.Collections.Generic;
using KiwiFramework.UI;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

namespace KiwiFramework.Editor.UI
{
    [CustomEditor(typeof(UITransparentGraphic))]
    [CanEditMultipleObjects]
    public class UITransparentGraphicEditor : OdinEditor
    {
        SerializedProperty mColor;

        protected override void OnEnable()
        {
            base.OnEnable();
            mColor = serializedObject.FindProperty("m_Color");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SirenixEditorGUI.MessageBox("仅用于检测射线碰撞", MessageType.Info, true);
            mColor.colorValue = SirenixEditorFields.ColorField(new GUIContent("预览区域颜色"), mColor.colorValue);

            serializedObject.ApplyModifiedProperties();
        }
    }
}