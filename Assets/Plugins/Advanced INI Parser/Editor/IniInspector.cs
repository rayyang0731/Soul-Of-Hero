using System.IO;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DefaultAsset))]
public class IniInspector : OdinEditor
{
    public override void OnInspectorGUI()
    {
        var path = AssetDatabase.GetAssetPath(target);
        if (!path.EndsWith(".ini")) return;

        var content = File.ReadAllText(path);
        if (content.Length > 1024 * 20)
            content = content.Substring(0, 1024 * 20) + "...";

        var style = EditorStyles.helpBox;
        style.fontSize = 12;
        style.border = new RectOffset(2, 2, 2, 2);
        GUI.color = Color.white;
        GUILayout.TextArea(content, style);
    }
}