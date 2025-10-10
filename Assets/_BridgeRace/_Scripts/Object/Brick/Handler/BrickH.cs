using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BrickH : MonoBehaviour
{
    #region --- Methods ---

    public abstract void OnAction(List<GameObject> bricks, Transform parentBrick, EColor colorType);

    public abstract void OnVisual(EColor colorType);

    #endregion

    #region --- Fields ---

    [SerializeField] protected BrickC _ctrl;

    #endregion
}
