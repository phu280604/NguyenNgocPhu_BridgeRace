using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorActionH : MonoBehaviour
{
    #region --- Methods ---

    public void HideHitBox()
    {
        _hitBox.enabled = false;
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private Collider _hitBox;

    #endregion
}
