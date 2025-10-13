using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// FloorMSO represents the shape of bricks that are built on the floor.
/// It stores the number of columns and rows, and the array of bricks for this floor.
/// </summary>
[CreateAssetMenu(fileName = "MapData", menuName = "Map")]
public class FloorMSO : ScriptableObject
{
    #region --- Methods ---

    /// <summary>
    /// Resizes the <see cref="shapeBricks"/> array based on the current <see cref="column"/> and <see cref="row"/> values.
    /// If the array is null or its length does not match column * row, a new array is created.
    /// </summary>
    public void ResizeArray()
    {
        int size = column * row;
        if (shapeBricks == null || shapeBricks.Length != size)
        {
            shapeBricks = new int[size];
        }
    }

    #endregion

    #region --- Fields ---

    public int column;
    public int row;

    public int[] shapeBricks;

    public FloorMSO nextLevel;

    #endregion
}

