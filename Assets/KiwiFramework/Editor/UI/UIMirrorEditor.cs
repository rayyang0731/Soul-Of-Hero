using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace KiwiFramework.UI
{
    [CustomEditor(typeof(UIMirror))]
    [CanEditMultipleObjects]
    public class UIMirrorEditor : ImageEditor
    {
        private SerializedProperty m_offset;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_offset = this.serializedObject.FindProperty("_offset");
        }

        public override void OnInspectorGUI()
        {
            UIMirror mirror = target as UIMirror;
            if (mirror == null)
                return;

            this.serializedObject.Update();
            mirror.MirrorType =
                (UIMirror.MIRROR_TYPE) SirenixEditorFields.EnumDropdown(new GUIContent("Mirror Type"),
                    mirror.MirrorType);
            this.serializedObject.ApplyModifiedProperties();
            
            base.OnInspectorGUI();
        }
    }
}