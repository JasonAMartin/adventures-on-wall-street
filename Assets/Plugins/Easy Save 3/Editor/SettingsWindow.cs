﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ES3Internal;

namespace ES3Editor
{
	public class SettingsWindow : SubWindow
	{
		public ES3DefaultSettings editorSettings = null;
		public ES3SerializableSettings settings = null;

		public SettingsWindow(EditorWindow window) : base("Settings", window){}

		public override void OnGUI()
		{
			if(settings == null || editorSettings == null)
				Init();

			var style = EditorStyle.Get;

			EditorGUI.BeginChangeCheck();

			EditorGUILayout.BeginVertical(style.area);

			GUILayout.Label("Runtime Settings", style.heading);

			EditorGUILayout.BeginVertical(style.area);

			ES3SettingsEditor.Draw(settings);

			EditorGUILayout.EndVertical();

			GUILayout.Label("Editor Settings", style.heading);

			EditorGUILayout.BeginVertical(style.area);

			EditorGUILayout.BeginHorizontal();
			var wideLabel = new GUIStyle();
			wideLabel.fixedWidth = 400;
			EditorGUILayout.PrefixLabel("Auto Add Manager to Scene", wideLabel);
			editorSettings.addMgrToSceneAutomatically = EditorGUILayout.Toggle(editorSettings.addMgrToSceneAutomatically);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.Space();


			// Show Assembly names array.
			SerializedObject so = new SerializedObject(editorSettings);
			SerializedProperty settingsProperty = so.FindProperty("settings");
			SerializedProperty assemblyNamesProperty = settingsProperty.FindPropertyRelative("assemblyNames");
			EditorGUILayout.PropertyField(assemblyNamesProperty, new GUIContent("Assemblies containing ES3Types", "The names of assemblies we want to load ES3Types from."), true); // True means show children
			so.ApplyModifiedProperties();

			EditorGUILayout.EndVertical();

			EditorGUILayout.EndVertical();


			if(EditorGUI.EndChangeCheck())
				EditorUtility.SetDirty(editorSettings);
		}

		public void Init()
		{
			editorSettings = ES3EditorUtility.GetDefaultSettings();
			settings = editorSettings.settings;
		}
	}

}
