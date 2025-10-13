using UnityEditor;
using UnityEngine;

/// <summary>
/// Custom editor for <see cref="FloorMSO"/> ScriptableObject.
/// Allows editing the column, row, and shapeBricks array directly in the Inspector.
/// </summary>
[CustomEditor(typeof(FloorMSO))]
public class FloorMEditor : Editor
{
    #region --- Unity Methods ---

    /// <summary>
    /// Overrides the default Inspector GUI for <see cref="FloorMSO"/>.
    /// Displays fields for column, row, and the grid of shape bricks with color coding.
    /// Automatically resizes the shapeBricks array and saves changes when edited.
    /// </summary>
    public override void OnInspectorGUI()
    {
        FloorMSO floorSO = (FloorMSO)target;

        EditorGUI.BeginChangeCheck();

        floorSO.nextLevel = (FloorMSO)EditorGUILayout.ObjectField(
            "Next level", 
            floorSO.nextLevel,
            typeof(FloorMSO),
            false
        );

        // Edit column and row
        floorSO.column = EditorGUILayout.IntField("Column", floorSO.column);
        floorSO.row = EditorGUILayout.IntField("Row", floorSO.row);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Shape Bricks");

        // Ensure the array size matches current column * row
        floorSO.ResizeArray();

        // Display the bricks in a grid with colors
        for (int i = 0; i < floorSO.row; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < floorSO.column; j++)
            {
                int index = i * floorSO.column + j;
                int value = floorSO.shapeBricks[index];

                if (value == 0) GUI.backgroundColor = Color.gray;
                else if (value == 1) GUI.backgroundColor = new Color(1f, 0.5f, 0f); // orange
                else GUI.backgroundColor = Color.green;

                floorSO.shapeBricks[index] = EditorGUILayout.IntField(floorSO.shapeBricks[index], GUILayout.Width(30));

                GUI.backgroundColor = Color.white;
            }
            EditorGUILayout.EndHorizontal();
        }

        // Save changes if any field was modified
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(floorSO);
        }
    }

    #endregion
}
