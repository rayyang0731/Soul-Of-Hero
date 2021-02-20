using KiwiFramework.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditorInternal;
using UnityEngine.UI;

namespace KiwiFramework.Editor.UI
{
    public class ConvertToKiwiUI
    {
        [MenuItem("CONTEXT/Image/转换为 UITransparentGraphic")]
        private static void ConvertToUITransparentImage(MenuCommand command)
        {
            ConvertTo<UITransparentGraphic>(command.context);
        }
        
        private static void ConvertTo<T>(Object context) where T : UIBehaviour
        {
            var go = (context as Component)?.gameObject;
            if (go == null) return;
        
            Undo.RecordObject(go, "Convert To");
            ComponentUtility.CopyComponent((Component) context);
            Object.DestroyImmediate(context, true);
            var newComponent = go.AddComponent<T>();
            ComponentUtility.PasteComponentValues(newComponent);
        }
    }
}