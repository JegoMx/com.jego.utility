using UnityEngine;
using UnityEditor;

namespace Jego.Utility.Editor
{
    public class PlayerPrefsEditorWindow : EditorWindow
    {
        private Vector2 _scrollPosition;

        private bool _showSetModule;
        private bool _showReadModule;
        private bool _showClearModule;

        private ValueType _setModuleSelectedValueType;
        private string _setModuleEnteredKey;
        private string _setModuleEnteredString;
        private int _setModuleEnteredInt;
        private float _setModuleEnteredFloat;

        private string _readModuleEnteredKey;
        private string _readModuleReadValue;

        private string _clearModuleEnteredKey;


        [MenuItem("Tools/Player Prefs Editor")]
        public static void ShowWindow()
        {
             GetWindow(typeof(PlayerPrefsEditorWindow), false, "Player Prefs Editor", true);
        }

        private void OnGUI()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            _showSetModule = EditorGUILayout.BeginFoldoutHeaderGroup(_showSetModule, "Set");
            if (_showSetModule) DrawSetModule();
            EditorGUILayout.EndFoldoutHeaderGroup();

            _showReadModule = EditorGUILayout.BeginFoldoutHeaderGroup(_showReadModule, "Read");
            if (_showReadModule) DrawReadModule();
            EditorGUILayout.EndFoldoutHeaderGroup();

            _showClearModule = EditorGUILayout.BeginFoldoutHeaderGroup(_showClearModule, "Clear");
            if (_showClearModule) DrawClearModule();
            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.EndScrollView();
        }

        private void DrawSetModule()
        {
            EditorGUILayout.Space();
            _setModuleSelectedValueType = (ValueType)EditorGUILayout.EnumPopup("Value Type: ", _setModuleSelectedValueType);
            _setModuleEnteredKey = EditorGUILayout.TextField("Key: ", _setModuleEnteredKey);

            switch (_setModuleSelectedValueType)
            {
                case ValueType.String:
                    _setModuleEnteredString = EditorGUILayout.TextField("Value: ", _setModuleEnteredString);
                    break;
                case ValueType.Integer:
                    _setModuleEnteredInt = EditorGUILayout.IntField("Value: ", _setModuleEnteredInt);
                    break;
                case ValueType.Float:
                    _setModuleEnteredFloat = EditorGUILayout.FloatField("Value: ", _setModuleEnteredFloat);
                    break;
                default: break;
            }

            if (GUILayout.Button("Set value"))
            {
                switch (_setModuleSelectedValueType)
                {
                    case ValueType.String:
                        PlayerPrefs.SetString(_setModuleEnteredKey, _setModuleEnteredString);
                        break;
                    case ValueType.Integer:
                        PlayerPrefs.SetInt(_setModuleEnteredKey, _setModuleEnteredInt);
                        break;
                    case ValueType.Float:
                        PlayerPrefs.SetFloat(_setModuleEnteredKey, _setModuleEnteredFloat);
                        break;
                    default: break;
                }
            }

            EditorGUILayout.Space();
        }
    
        private void DrawReadModule()
        {
            EditorGUILayout.Space();
            _readModuleEnteredKey = EditorGUILayout.TextField("Key: ", _readModuleEnteredKey);
            EditorGUILayout.LabelField("Value: ", _readModuleReadValue);

            if (GUILayout.Button("Read value"))
            {
                if (PlayerPrefs.HasKey(_readModuleEnteredKey))
                {
                    // There is no way of knowing what the type of a value belonging to a key is.
                    // It is impossible for a key to have 2 values of different types.
                    // Use dummy values as default return values, and based off of that decide whether the returned value is real or not.
                    int readInt = PlayerPrefs.GetInt(_readModuleEnteredKey, int.MaxValue);
                    if (readInt != int.MaxValue)
                    {
                        _readModuleReadValue = readInt.ToString();
                    }
                    else
                    {
                        float readFloat = PlayerPrefs.GetFloat(_readModuleEnteredKey, float.MaxValue);
                        if (!Mathf.Approximately(readFloat, float.MaxValue))
                        {
                            _readModuleReadValue = readFloat.ToString();
                        }
                        else
                        {
                            _readModuleReadValue = PlayerPrefs.GetString(_readModuleEnteredKey);
                        }
                    }
                }
                else
                {
                    _readModuleReadValue = "No value is assigned to this key";
                }
            }

            EditorGUILayout.Space();
        }
    
        private void DrawClearModule()
        {
            EditorGUILayout.Space();
            _clearModuleEnteredKey = EditorGUILayout.TextField("Key: ", _clearModuleEnteredKey);
            EditorGUILayout.Space();

            if (GUILayout.Button("Clear"))
            {
                PlayerPrefs.DeleteKey(_clearModuleEnteredKey);
            }

            if (GUILayout.Button("Clear All"))
            {
                PlayerPrefsClearAllEditorWindow.ShowWindow();
            }
        }
    }

    public enum ValueType { String, Integer, Float }
}