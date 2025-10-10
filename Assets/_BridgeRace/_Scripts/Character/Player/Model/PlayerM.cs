using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a character state that saves and reads information from states.
/// </summary>
public class PlayerM : MonoBehaviour
{
    #region --- Properties ---

    public Vector3 Direction { get; set; }

    public List<GameObject> Bricks { get; set; } = new List<GameObject>();

    public Transform TransformParentBrick => _transParBrickSlot;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _transParBrickSlot;

    #endregion
}
