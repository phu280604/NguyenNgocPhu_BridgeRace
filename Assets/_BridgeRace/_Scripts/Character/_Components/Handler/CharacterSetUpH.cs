using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides functionality to configure and modify the appearance of a character in the scene.
/// </summary>
/// <remarks>This class is responsible for updating the materials of character components based on specified color
/// types. It interacts with a <see cref="ColorSO"/> scriptable object to retrieve the appropriate materials.</remarks>
public class CharacterSetUpH : MonoBehaviour
{
    #region --- Methods ---

    /// <summary>
    /// Changes the material of the specified <see cref="MeshRenderer"/> to match the given color type.
    /// </summary>
    /// <remarks>The method retrieves the material corresponding to the specified color type and applies it to
    /// the provided <see cref="MeshRenderer"/>.</remarks>
    /// <param name="meshRend">The <see cref="MeshRenderer"/> whose material will be updated. Must not be null.</param>
    /// <param name="type">The color type used to determine the new material.</param>
    public void ChangeColorType(ref MeshRenderer meshRend, EColor type)
    {
        Material color = _colorSO.GetColor(type);
        meshRend.SetMaterials(new List<Material> { color });
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private ColorSO _colorSO;

    #endregion
}
