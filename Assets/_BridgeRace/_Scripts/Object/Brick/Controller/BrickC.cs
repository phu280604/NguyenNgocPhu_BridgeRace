using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickC : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null || !other.gameObject.CompareTag("Player")) return;

        PlayerC ctrl = other.GetComponent<PlayerC>();

        if (ctrl == null)
        {
            Debug.Log("Can't get");
            return;
        }

        _brickActionH.OnAction(ref ctrl._bricks, ctrl.GetColorType());
        _brickActionH.OnVisual(ctrl.GetColorType());
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _setUpH.ChangeColorType(ref meshBrick, _brickStateM.ColorType);
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private MeshRenderer meshBrick;

    [SerializeField] private BrickH _brickActionH;
    [SerializeField] private CharacterSetUpH _setUpH;

    [SerializeField] private BrickStateM _brickStateM;

    #endregion
}
