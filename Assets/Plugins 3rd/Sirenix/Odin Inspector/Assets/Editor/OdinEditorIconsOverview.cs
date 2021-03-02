using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

public class OdinEditorIconsOverview
{
    [MenuItem("Tools/Odin Inspector/Editor Icons Overview")]
    private static void OpenWindow()
    {
        EditorIconsOverview.OpenEditorIconsOverview();
    }
}
