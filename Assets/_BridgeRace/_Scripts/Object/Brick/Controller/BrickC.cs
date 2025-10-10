using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickC : MonoBehaviour, ISetUpH
{
    #region --- Overrides ---

    public void SetColorType(EColor newColorType)
    {
        ColorType = newColorType;
    }

    public void ChangeColor(Material newMat)
    {
        meshBrick.SetMaterials(new List<Material> { newMat });
    }

    #endregion

    #region --- Unity Methods ---

    public void OnActionC<TStateM, TStatsM>(CharacterC<TStateM, TStatsM> ctrl)
    {
        if(ctrl.GetStateM is CharacterM)
        {
            CharacterM charM = ctrl.GetStateM as CharacterM;

            _brickActionH.OnAction(charM.Bricks, charM.TransformParentBrick, ctrl.GetColorType);
            _brickActionH.OnVisual(ctrl.GetColorType);
        }
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.CompareTag(TagCollection.PLAYER)) return;

    //    CharacterC<CharacterM, CharStatsSO> charCtrl = other.GetComponent<CharacterC<CharacterM, CharStatsSO>>();

    //    _brickActionH.OnAction(charCtrl.GetStateM.Bricks, charCtrl.GetStateM.TransformParentBrick, ctrl.GetColorType);
    //    _brickActionH.OnVisual(ctrl.GetColorType);
    //}

    #endregion

    #region --- Properties ---

    public EColor ColorType { get; set; }

    public BrickM GetBrickM => _brickM;

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private MeshRenderer meshBrick;

    [Header("Handler components")]
    [SerializeField] private BrickH _brickActionH;

    [Header("Model components")]
    [SerializeField] private BrickM _brickM;

    #endregion
}
