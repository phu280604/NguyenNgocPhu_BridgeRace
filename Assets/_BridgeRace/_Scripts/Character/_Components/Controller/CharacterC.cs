using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component parent controller for character.
/// </summary>
public class CharacterC<TStateM, TStatsM> : MonoBehaviour
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

    #region --- Properties ---

    public EColor GetColorType() => _type;

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capCol;
    [SerializeField] protected MeshRenderer meshRend;

    [Header("Custom components")]
    [SerializeField] private CharacterSetUpH _setUpH;
    [SerializeField] protected TStateM _stateM;
    [SerializeField] protected TStatsM _statsM;

    [Header("Character color types")]
    [SerializeField] protected EColor _type;

    #endregion
}
