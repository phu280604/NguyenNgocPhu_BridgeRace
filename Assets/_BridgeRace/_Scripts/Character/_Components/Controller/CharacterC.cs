using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component parent controller for character.
/// </summary>
public abstract class CharacterC<TStateM, TStatsM> : MonoBehaviour, ISetUpH
{
    #region --- Unity Methods ---

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(TagCollection.BRICK) && !other.CompareTag(TagCollection.BRIDGE_BRICK)) return;

        BrickC brickCtrl = other.GetComponent<BrickC>();
        brickCtrl.OnActionC(this);
    }

    #endregion

    #region --- Methods ---

    public abstract void OnMoveC();

    public void SetColorType(EColor newColorType)
    {
        _type = newColorType;
    }

    public void ChangeColor(Material newMat)
    {
        meshRend.SetMaterials(new List<Material> { newMat });
    }

    #endregion

    #region --- Properties ---

    public EColor GetColorType => _type;

    public TStateM GetStateM => _stateM;

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capCol;
    [SerializeField] protected MeshRenderer meshRend;

    [Header("Custom components")]
    [SerializeField] protected TStateM _stateM;
    [SerializeField] protected TStatsM _statsM;

    [Header("Character color types")]
    [SerializeField] protected EColor _type;

    #endregion
}
