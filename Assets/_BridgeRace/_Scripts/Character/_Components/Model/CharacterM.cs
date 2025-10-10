using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterM : MonoBehaviour
{
    #region --- Properties ---

    public List<GameObject> Bricks { get; set; } = new List<GameObject>();

    public Transform TransformParentBrick => _transParBrickSlot;

    public bool CanMoving { get; set; } = true;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _transParBrickSlot;

    #endregion
}
