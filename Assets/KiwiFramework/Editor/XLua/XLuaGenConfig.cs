using System.Collections.Generic;
using XLua;
using System.Reflection;

//配置的详细介绍请看Doc下《XLua的配置.doc》
public static class XLuaGenConfig
{
#if UseLua

    [LuaCallCSharp] public static List<System.Type> LuaCallCSharp =
        new List<System.Type>()
        {
            #region System

            typeof(System.Object),
            typeof(System.Convert),

            #endregion

//----------------------------------------------------------------------

            #region UnityEngine

            typeof(UnityEngine.Object),
            typeof(UnityEngine.Vector2),
            typeof(UnityEngine.Vector3),
            typeof(UnityEngine.Vector4),
            typeof(UnityEngine.Quaternion),
            typeof(UnityEngine.Color),
            typeof(UnityEngine.Ray),
            typeof(UnityEngine.Bounds),
            typeof(UnityEngine.Ray2D),
            typeof(UnityEngine.Time),
            typeof(UnityEngine.GameObject),
            typeof(UnityEngine.Component),
            typeof(UnityEngine.Behaviour),
            typeof(UnityEngine.Transform),
            typeof(UnityEngine.Resources),
            typeof(UnityEngine.TextAsset),
            typeof(UnityEngine.Keyframe),
            typeof(UnityEngine.AnimationCurve),
            typeof(UnityEngine.AnimationClip),
            typeof(UnityEngine.MonoBehaviour),
            typeof(UnityEngine.ParticleSystem),
            typeof(UnityEngine.SkinnedMeshRenderer),
            typeof(UnityEngine.Renderer),
            typeof(UnityEngine.Debug),
            typeof(UnityEngine.Camera),
            typeof(UnityEngine.Screen),
            typeof(UnityEngine.PlayerPrefs),
            typeof(UnityEngine.RectTransform),
            typeof(UnityEngine.RenderTexture),
            typeof(UnityEngine.Animation),
            typeof(UnityEngine.Random),
            typeof(UnityEngine.Networking.UnityWebRequest),
            typeof(UnityEngine.SceneManagement.SceneManager),
            typeof(UnityEngine.SceneManagement.LoadSceneMode),

            #endregion

//----------------------------------------------------------------------

            #region DoTween

            typeof(DG.Tweening.DOTween),

            #endregion

//----------------------------------------------------------------------

            #region KiwiFramework

            typeof(KiwiFramework.Core.KiwiLog),
            typeof(KiwiFramework.Core.ViewManager),
            typeof(KiwiFramework.Core.MonoSingleton<>),
            typeof(KiwiFramework.Core.XLuaModule.LuaViewBehaviour),

            #endregion
        };

    [CSharpCallLua] public static List<System.Type> CSharpCallLua =
        new List<System.Type>()
        {
        };


    //黑名单
    [BlackList] public static List<List<string>> BlackList = new List<List<string>>()
    {
        new List<string>() {"System.Xml.XmlNodeList", "ItemOf"},
        new List<string>() {"UnityEngine.WWW", "movie"},
#if UNITY_WEBGL
                new List<string>(){"UnityEngine.WWW", "threadPriority"},
#endif
        new List<string>() {"UnityEngine.Texture2D", "alphaIsTransparency"},
        new List<string>() {"UnityEngine.Security", "GetChainOfTrustValue"},
        new List<string>() {"UnityEngine.CanvasRenderer", "onRequestRebuild"},
        new List<string>() {"UnityEngine.Light", "areaSize"},
        new List<string>() {"UnityEngine.Light", "lightmapBakeType"},
        new List<string>() {"UnityEngine.WWW", "MovieTexture"},
        new List<string>() {"UnityEngine.WWW", "GetMovieTexture"},
        new List<string>() {"UnityEngine.AnimatorOverrideController", "PerformOverrideClipListCleanup"},
#if !UNITY_WEBPLAYER
        new List<string>() {"UnityEngine.Application", "ExternalEval"},
#endif
        new List<string>() {"UnityEngine.GameObject", "networkView"}, //4.6.2 not support
        new List<string>() {"UnityEngine.Component", "networkView"}, //4.6.2 not support
        new List<string>()
            {"System.IO.FileInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>() {"System.IO.FileInfo", "SetAccessControl", "System.Security.AccessControl.FileSecurity"},
        new List<string>()
            {"System.IO.DirectoryInfo", "GetAccessControl", "System.Security.AccessControl.AccessControlSections"},
        new List<string>()
            {"System.IO.DirectoryInfo", "SetAccessControl", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>()
        {
            "System.IO.DirectoryInfo", "CreateSubdirectory", "System.String",
            "System.Security.AccessControl.DirectorySecurity"
        },
        new List<string>() {"System.IO.DirectoryInfo", "Create", "System.Security.AccessControl.DirectorySecurity"},
        new List<string>() {"UnityEngine.MonoBehaviour", "runInEditMode"},
    };

#if UNITY_2018_1_OR_NEWER
    [BlackList] public static System.Func<MemberInfo, bool> MethodFilter = (memberInfo) =>
    {
        if (memberInfo.DeclaringType.IsGenericType &&
            memberInfo.DeclaringType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            if (memberInfo.MemberType == MemberTypes.Constructor)
            {
                ConstructorInfo constructorInfo = memberInfo as ConstructorInfo;
                var parameterInfos = constructorInfo.GetParameters();
                if (parameterInfos.Length > 0)
                {
                    if (typeof(System.Collections.IEnumerable).IsAssignableFrom(parameterInfos[0].ParameterType))
                    {
                        return true;
                    }
                }
            }
            else if (memberInfo.MemberType == MemberTypes.Method)
            {
                var methodInfo = memberInfo as MethodInfo;
                if (methodInfo.Name == "TryAdd" ||
                    methodInfo.Name == "Remove" && methodInfo.GetParameters().Length == 2)
                {
                    return true;
                }
            }
        }

        return false;
    };
#endif

#endif
}