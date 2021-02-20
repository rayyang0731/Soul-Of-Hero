using KiwiFramework.Core;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KiwiFramework.Editor
{
    [InitializeOnLoad]
    public static class KiwiSceneManager
    {
        static KiwiSceneManager()
        {
            EditorApplication.playModeStateChanged += change =>
            {
                switch (change)
                {
                    case PlayModeStateChange.EnteredPlayMode:
                    {
                        if (EditorPrefs.GetBool("AutoEnterMainScene", true))
                        {
                            var scene = SceneManager.GetActiveScene();
                            if (scene.name == "UI Builder")
                                SceneManager.LoadScene("Main");
                        }

                        break;
                    }
                    case PlayModeStateChange.EnteredEditMode:
                    {
                        var scene = SceneManager.GetActiveScene();
                        if (scene.name == "UI Builder")
                        {
                            if (Object.FindObjectOfType<DisplayOutlineForRaycast>() == null)
                                new GameObject("[Raycast Outline]", typeof(DisplayOutlineForRaycast));
                        }

                        break;
                    }
                }
            };
        }

        public static void UseAutoEnterMainScene()
        {
            EditorPrefs.SetBool("AutoEnterMainScene", true);
        }

        public static void NoUseAutoEnterMainScene()
        {
            EditorPrefs.SetBool("AutoEnterMainScene", false);
        }

        public static void OpenUiBuilderScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/UI Builder.unity", OpenSceneMode.Single);
        }

        public static void OpenGameMainScene()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Main.unity", OpenSceneMode.Single);
        }
    }
}