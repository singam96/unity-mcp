using MCPForUnity.Editor.Constants;
using MCPForUnity.Editor.Setup;
using MCPForUnity.Editor.Tools;
using MCPForUnity.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace MCPForUnity.Editor.MenuItems
{
    public static class MCPForUnityMenu
    {
        [MenuItem(ProductInfo.MenuRoot + "/Toggle MCP Window %#m", priority = 1)]
        public static void ToggleMCPWindow()
        {
            MCPForUnityEditorWindow.ShowWindow();
        }

        [MenuItem(ProductInfo.MenuRoot + "/Local Setup Window", priority = 2)]
        public static void ShowSetupWindow()
        {
            SetupWindowService.ShowSetupWindow();
        }

        [MenuItem(ProductInfo.MenuRoot + "/Edit EditorPrefs", priority = 3)]
        public static void ShowEditorPrefsWindow()
        {
            EditorPrefsWindow.ShowWindow();
        }

        /// <summary>
        /// Emergency flush: cancels all queued/running MCP commands and clears stuck test jobs.
        /// Use when the editor appears frozen due to a stuck MCP queue.
        /// Shortcut: Ctrl+Shift+F5 (Cmd+Shift+F5 on Mac)
        /// </summary>
        [MenuItem("Window/MCP For Unity/Emergency Flush Queue %#&F5", priority = 100)]
        public static void EmergencyFlushQueue()
        {
            CommandGatewayState.EmergencyFlush();
            Debug.LogWarning("[MCP] Emergency flush completed. Queue cleared, stuck test jobs removed.");
        }
    }
}
