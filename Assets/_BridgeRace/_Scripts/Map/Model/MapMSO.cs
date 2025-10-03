using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "MapData", menuName ="Map")]
public class MapMSO : ScriptableObject
{
    #region --- Methods ---

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

    public int column, row;
    public int[] shapeBricks;

    #endregion
}
