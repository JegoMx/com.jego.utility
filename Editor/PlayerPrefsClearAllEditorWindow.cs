using UnityEngine;
using UnityEditor;

namespace Jego.Utility.Editor
{
    public class PlayerPrefsClearAllEditorWindow : EditorWindow
    {
        private static PlayerPrefsClearAllEditorWindow _activeWindow;

        public static void ShowWindow()
        {
            _activeWindow = GetWindow<PlayerPrefsClearAllEditorWindow>();
            _activeWindow.titleContent = new GUIContent("Clear All PlayerPrefs");
            _activeWindow.minSize = _activeWindow.maxSize = new Vector2(300, 100);
            _activeWindow.ShowModal();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            GUIStyle firstLabelStyle = new GUIStyle(EditorStyles.label);
            firstLabelStyle.alignment = TextAnchor.UpperCenter;
            EditorGUILayout.LabelField("Are you sure you want to clear all PlayerPrefs?", firstLabelStyle);
            GUIStyle secondLabelStyle = new GUIStyle(EditorStyles.label);
            secondLabelStyle.alignment = TextAnchor.UpperCenter;
            secondLabelStyle.fontStyle = FontStyle.Bold;
            EditorGUILayout.LabelField("This action cannot be undone!", secondLabelStyle);
            EditorGUILayout.Space();

            if (GUILayout.Button("Clear all Playerprefs"))
            {
                PlayerPrefs.DeleteAll();
                _activeWindow.Close();
                _activeWindow = null;
            }
            else if (GUILayout.Button("Cancel"))
            {
                _activeWindow.Close();
                _activeWindow = null;
            }
        }
    }
}