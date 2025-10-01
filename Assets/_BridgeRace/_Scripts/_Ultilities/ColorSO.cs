using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Presentation color colection and Getting color from collection.
/// </summary>
[CreateAssetMenu(fileName ="ColorType", menuName ="Character/ColorType")]
public class ColorSO : ScriptableObject
{
    #region --- Methods ---

    /// <summary>
    /// Get color from Enum color parameter.
    /// </summary>
    /// <param name="colorType">is a Enum color.</param>
    /// <returns>Material with same color.</returns>
    public Material GetColor(EColor colorType)
    {
        for(int i = 1; i < materials.Count; i++)
        {
            if(i == (int)colorType)
                return materials[i];
        }

        return materials[0];
    }

    #endregion

    #region --- Fields ---

    public List<Material> materials = new List<Material>();

    #endregion
}
