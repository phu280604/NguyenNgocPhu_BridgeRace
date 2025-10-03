using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CustomEditor(typeof(MapMSO))]
public class MapMEditor : Editor
{
    #region --- Unity Methods ---

    public override void OnInspectorGUI()
    {
        MapMSO mapSO = (MapMSO)target;

        EditorGUI.BeginChangeCheck();

        mapSO.column = EditorGUILayout.IntField("Column", mapSO.column);
        mapSO.row = EditorGUILayout.IntField("Row", mapSO.row);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Shape Bricks");

        mapSO.ResizeArray();

        
        for(int i = 0; i < mapSO.row; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < mapSO.column; j++) 
            {
                int index = i * mapSO.column + j;
                int value = mapSO.shapeBricks[index];

                if (value == 0) GUI.backgroundColor = Color.gray;
                else if (value == 1) GUI.backgroundColor = new Color(1f, 0.5f, 0f); // cam
                else GUI.backgroundColor = Color.green;

                mapSO.shapeBricks[index] = EditorGUILayout.IntField(mapSO.shapeBricks[index], GUILayout.Width(30));

                GUI.backgroundColor = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(mapSO); // Lưu thay đổi
        }

    }

    #endregion
}
