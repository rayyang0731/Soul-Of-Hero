using System.Collections;
using System.Collections.Generic;
using KiwiFramework.UI;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;

namespace KiwiFramework.Editor
{
    public class UICreater
    {
        private static GameObject MainCanvas()
        {
            var result = GameObject.FindWithTag(UITagDefine.MainCanvasTag);
            if (result == null)
                result = PrefabUtility.InstantiatePrefab(Resources.Load<GameObject>("UI/MainCanvas")) as GameObject;
            return result;
        }

        [MenuItem("GameObject/Kiwi UI/界面 UIView", false, priority = 11)]
        public static void CreateUIView()
        {
            CreateViewWindow.OpenWindow(MainCanvas());
        }

        [MenuItem("GameObject/Kiwi UI/文字 UIText", false)]
        public static void CreateUIText()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UIText.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "lab_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/文字 UITextMeshPro", false)]
        public static void CreateUITextMeshPro()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UITextMeshPro.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "tmp_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/图片 UIImage", false)]
        public static void CreateUIImage()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UIImage.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "img_[Name]";
            Selection.activeObject = go;
        }

        // TODO : UI Raw Image 还没写

        [MenuItem("GameObject/Kiwi UI/按钮 UIButton", false)]
        public static void CreateUIButton()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UIButton.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "btn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UIButton - TextMeshPro", false)]
        public static void CreateUIButtonWithTMP()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UIButtonWithTMP.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "btn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UIRepeatButton", false)]
        public static void CreateUIRepeatButton()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UIRepeatButton.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "repBtn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UIRepeatButton - TextMeshPro", false)]
        public static void CreateUIRepeatButtonWithTMP()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/KiwiFramework/Templates/UI/UIRepeatButtonWithTMP.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "repBtn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UILongPressButton", false)]
        public static void CreateUILongPressButton()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/UILongPressButton.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "longBtn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UILongPressButton - TextMeshPro", false)]
        public static void CreateUILongPressButtonWithTMP()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/KiwiFramework/Templates/UI/UILongPressButtonWithTMP.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "longBtn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UITransparentButton", false)]
        public static void CreateUITransparentButton()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/KiwiFramework/Templates/UI/UITransparentButton.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "transBtn_[Name]";
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Kiwi UI/按钮 UITransparentButton - TextMeshPro", false)]
        public static void CreateUITransparentButtonWithTMP()
        {
            var mainCanvas = MainCanvas();
            var template =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    "Assets/KiwiFramework/Templates/UI/UITransparentButtonWithTMP.prefab");
            var parent = Selection.activeTransform.root == mainCanvas.transform
                ? Selection.activeTransform
                : mainCanvas.transform;
            var go =
                Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            go.name = "transBtn_[Name]";
            Selection.activeObject = go;
        }
    }

    public class CreateViewWindow : OdinEditorWindow
    {
        private static GameObject _mainCanvas;

        public static void OpenWindow(GameObject mainCanvas)
        {
            var window = GetWindowWithRect<CreateViewWindow>(GUIHelper.GetEditorWindowRect().AlignCenter(300, 60),
                true, "创建界面", true);
            window.maxSize = window.minSize = new Vector2(300, 60);
            _mainCanvas = mainCanvas;
        }

        private string Name => "UI" + (string.IsNullOrEmpty(viewName) ? "XXX" : viewName) + "View";

        [LabelText("界面名称"), SuffixLabel("$Name", true), GUIColor(0.3f, 0.8f, 0.8f), ShowInInspector]
        private string viewName = string.Empty;

        [Button(ButtonSizes.Large, Name = "创建"), GUIColor(0, 1, 0)]
        public void Create()
        {
            if (string.IsNullOrEmpty(viewName))
            {
                EditorUtility.DisplayDialog("警告", "请填写界面名称", "确定");
                return;
            }

            var viewTemplate =
                AssetDatabase.LoadAssetAtPath<GameObject>("Assets/KiwiFramework/Templates/UI/TemplateView.prefab");
            var viewGo = Instantiate(viewTemplate, _mainCanvas.transform);
            viewName = viewName.Substring(0, 1).ToUpper() + viewName.Substring(1);
            viewGo.name = Name;
            Selection.activeObject = viewGo;

            Close();
        }
    }
}