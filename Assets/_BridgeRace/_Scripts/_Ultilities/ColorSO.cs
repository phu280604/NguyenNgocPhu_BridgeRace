using System;
using System.Collections.Generic;
using System.Linq;
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

    public void SetListColor()
    {
        _availableColors = System.Enum.GetValues(typeof(EColor))
            .Cast<EColor>()
            .ToList();

        if(_availableColors.Count > 0 ) 
            _availableColors.RemoveAt(0);
    }

    public EColor GetRandomColor()
    {
        if(_availableColors.Count == 0)
            SetListColor();

        int randomIndex = UnityEngine.Random.Range(0, _availableColors.Count);
        EColor color = _availableColors[randomIndex];
        _availableColors.RemoveAt(randomIndex);
        return color;
    }

    #endregion

    #region --- Fields ---

    public List<Material> materials = new List<Material>(); 
    private List<EColor> _availableColors = new List<EColor>();

    #endregion
}
