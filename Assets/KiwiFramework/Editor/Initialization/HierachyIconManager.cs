using System;
using System.Collections;
using System.Collections.Generic;
using KiwiFramework.UI;
using UnityEditor;
using UnityEngine;

namespace KiwiFramework.Editor
{
    /// <summary>
    /// Hierarchy内容扩展
    /// </summary>
    [InitializeOnLoad]
    public static class HierachyIconManager
    {
        private static GUIContent UIObjectIcon =
            new GUIContent(EditorGUIUtility.IconContent("Icons/UIObject.png", "UI"));

        private static GUIContent UIViewStaticIcon =
            new GUIContent(EditorGUIUtility.IconContent("Icons/UIView.png", "UI"));

        private static GUIContent UIViewDynamicIcon =
            new GUIContent(EditorGUIUtility.IconContent("Icons/DynamicView.png", "UI"));

        private static GUIContent SubCanvasDisplayOpenIcon =
            new GUIContent(EditorGUIUtility.IconContent("Icons/CanvasDisplay_Open.png", "UI"));

        private static GUIContent SubCanvasDisplayCloseIcon =
            new GUIContent(EditorGUIUtility.IconContent("Icons/CanvasDisplay_Close.png", "UI"));

        static HierachyIconManager()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGui;
        }

        private static void HierarchyWindowItemOnGui(int instanceId, Rect selectionRect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
            if (obj == null)
                return;

            var index = 0;
            DrawIcon_UIObject(obj, selectionRect, ref index);
            DrawIcon_UIView(obj, selectionRect, ref index);
            DrawIcon_UIObjType(obj, selectionRect, ref index);
            DrawIcon_CanvasDisplay(obj, selectionRect, ref index);
        }

        private static Rect GetRect(Rect selectionRect, int index)
        {
            selectionRect.x += selectionRect.width - 20 - 20 * index;
            selectionRect.width = 20;
            return selectionRect;
        }

        private static void DrawIcon_UIObject(GameObject obj, Rect selectionRect, ref int index)
        {
            if (!obj.CompareTag(UITagDefine.UIObjectTag)) return;
            var rect = GetRect(selectionRect, index);
            GUI.Label(rect, UIObjectIcon);
            index++;
        }

        private static void DrawIcon_UIObjType(GameObject obj, Rect selectionRect, ref int index)
        {
            if (!obj.CompareTag(UITagDefine.UIObjectTag)) return;
            foreach (var type in ExportTypeDefine.UIObjectTyps)
            {
                var comp = obj.GetComponent(type);
                if (!comp) continue;

                var rect = GetRect(selectionRect, index);
                var icon = (Texture) AssetPreview.GetMiniThumbnail(comp);
                GUI.Label(rect, icon);
                break;
            }

            index++;
        }

        private static void DrawIcon_UIView(GameObject obj, Rect selectionRect, ref int index)
        {
            if (!obj.CompareTag(UITagDefine.UIViewTag)) return;
            var rect = GetRect(selectionRect, index);
            GUI.Label(rect, obj.GetComponent<Canvas>() ? UIViewDynamicIcon : UIViewStaticIcon);
            index++;
        }

        private static void DrawIcon_CanvasDisplay(GameObject obj, Rect selectionRect, ref int index)
        {
            var canvasGroup = obj.GetComponent<CanvasGroup>();
            if (!obj.GetComponent<Canvas>() || !canvasGroup) return;
            var rect = GetRect(selectionRect, index);
            GUI.Label(rect, canvasGroup.alpha > 0 ? SubCanvasDisplayOpenIcon : SubCanvasDisplayCloseIcon);
            index++;
        }
    }
}