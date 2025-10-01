using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component parent controller for character.
/// </summary>
public class CharacterC : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Set up Character Information.
    /// </summary>
    protected void OnInit()
    {
        // Set up Color.
        _setUpH.ChangeColorType(ref meshRend, _type);
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capCol;
    [SerializeField] protected MeshRenderer meshRend;

    [Header("Character Handler")]
    [SerializeField] private CharacterSetUpH _setUpH;

    [Header("Character color types")]
    [SerializeField] protected EColor _type;

    #endregion
}
