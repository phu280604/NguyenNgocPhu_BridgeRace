using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrickH : MonoBehaviour
{
    #region --- Methods ---

    public abstract void OnAction(ref List<GameObject> bricks, EColor colorType);

    public abstract void OnVisual(EColor colorType);


    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] protected GameObject goMeshBrick;

    [Header("Custom components")]
    [SerializeField] protected BrickStateM stateM;

    #endregion
}
