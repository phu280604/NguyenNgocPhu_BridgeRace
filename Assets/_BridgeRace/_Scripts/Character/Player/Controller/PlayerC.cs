using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a player controller that manages Player's handler.
/// </summary>
public class PlayerC : CharacterC
{
    #region --- Unity Methods ---

    void Start()
    {

    }

    void Update()
    {
        MoveHandle();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Handle move action.
    /// </summary>
    private void MoveHandle()
    {
        _action.GetDirection(_control.GetInput());

        Transform goTrans = gameObject.transform;
        _action.MoveH(ref goTrans, Time.deltaTime);
    }

    #endregion

    #region --- Fields ---

    [Header("Player handler")]
    [SerializeField] private PlayerInputH _control;
    [SerializeField] private PlayerActionH _action;

    #endregion
}
