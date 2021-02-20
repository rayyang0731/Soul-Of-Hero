using UnityEditor;

namespace KiwiFramework.Editor
{
    public static class KiwiMenu
    {
        [MenuItem("Kiwi/场景/UI 编辑场景", false, 101)]
        private static void OpenUiBuilderScene()
        {
            KiwiSceneManager.OpenUiBuilderScene();
        }

        [MenuItem("Kiwi/场景/游戏入口场景", false, 101)]
        private static void OpenGameMainScene()
        {
            KiwiSceneManager.OpenGameMainScene();
        }

        [MenuItem("Kiwi/场景/自动切换/打开", false, 103)]
        private static void UseAutoEnterMainScene()
        {
            KiwiSceneManager.UseAutoEnterMainScene();
        }

        [MenuItem("Kiwi/场景/自动切换/打开", true, 103)]
        private static bool ValidateUseAutoEnterMainScene()
        {
            return !EditorPrefs.GetBool("AutoEnterMainScene", true);
        }

        [MenuItem("Kiwi/场景/自动切换/关闭", false, 104)]
        private static void NoUseAutoEnterMainScene()
        {
            KiwiSceneManager.NoUseAutoEnterMainScene();
        }

        [MenuItem("Kiwi/场景/自动切换/关闭", true, 104)]
        private static bool ValidateNoUseAutoEnterMainScene()
        {
            return EditorPrefs.GetBool("AutoEnterMainScene", true);
        }

        [MenuItem("Kiwi/配置文件", false, 1001)]
        private static void OpenIniSettingWindow()
        {
            IniSettingWindow.ShowWindow();
        }

        private const string LuaSymbol = "UseLua";
        private const string XLuaHotfixSymbol = "HOTFIX_ENABLE";

        [MenuItem("Kiwi/Lua/使用 Lua", false, 1002)]
        private static void UseXLua()
        {
            string defaultDefineSymbols;

            string GetDefineSymbols()
            {
                var result = $"{defaultDefineSymbols};{LuaSymbol};{XLuaHotfixSymbol};";
                if (result.Contains(";;"))
                    result = result.Replace(";;", ";");

                return result;
            }

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
            if (!defaultDefineSymbols.Contains(LuaSymbol))
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, GetDefineSymbols());

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
            if (!defaultDefineSymbols.Contains(LuaSymbol))
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, GetDefineSymbols());

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            if (!defaultDefineSymbols.Contains(LuaSymbol))
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, GetDefineSymbols());
        }

        [MenuItem("Kiwi/Lua/使用 Lua", true, 1002)]
        private static bool ValidateUseXLua()
        {
            return !IsUsingXLua();
        }

        [MenuItem("Kiwi/Lua/不使用 Lua", false, 1003)]
        private static void NoUseXLua()
        {
            string defaultDefineSymbols;

            string GetDefineSymbols()
            {
                var result = defaultDefineSymbols.Replace(LuaSymbol, string.Empty)
                    .Replace(XLuaHotfixSymbol, string.Empty);
                if (result.Contains(";;"))
                    result = result.Replace(";;", ";");

                return result;
            }

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, GetDefineSymbols());

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, GetDefineSymbols());

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, GetDefineSymbols());
        }

        [MenuItem("Kiwi/Lua/不使用 Lua", true, 1003)]
        private static bool ValidateNoUseXLua()
        {
            return IsUsingXLua();
        }

        /// <summary>
        /// 是否正在使用 Lua
        /// </summary>
        /// <returns></returns>
        private static bool IsUsingXLua()
        {
            bool result;
            var defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
            result = defaultDefineSymbols.Contains(LuaSymbol) && defaultDefineSymbols.Contains(XLuaHotfixSymbol);

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
            result = result && defaultDefineSymbols.Contains(LuaSymbol) &&
                     defaultDefineSymbols.Contains(XLuaHotfixSymbol);

            defaultDefineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            result = result && defaultDefineSymbols.Contains(LuaSymbol) &&
                     defaultDefineSymbols.Contains(XLuaHotfixSymbol);

            return result;
        }
    }
}