using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickC : MonoBehaviour, ISetUpH
{
    #region --- Overrides ---

    public void SetColorType(EColor newColorType)
    {
        _type = newColorType;
    }

    public void ChangeColor(Material newMat)
    {
        meshBrick.SetMaterials(new List<Material> { newMat });
    }

    #endregion

    #region --- Unity Methods ---

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || !other.gameObject.CompareTag("Player")) return;

        PlayerC ctrl = other.GetComponent<PlayerC>();

        if (ctrl == null)
        {
            Debug.Log("Can't get");
            return;
        }

        _brickActionH.OnAction(ref ctrl._bricks, ctrl.GetColorType);
        _brickActionH.OnVisual(ctrl.GetColorType);
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private MeshRenderer meshBrick;

    [Header("Handler components")]
    [SerializeField] private BrickH _brickActionH;

    [Header("Model components")]
    [SerializeField] private BrickStateM _brickStateM;

    private EColor _type;

    #endregion
}
