using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a bot controller that manages bot's handler.
/// </summary>
public class BotC : CharacterC<BotStateM, CharStatsSO>
{
    #region --- Unity Methods ---

    private void Update()
    {
        //MoveHandle();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Handle move action.
    /// </summary>
    private void MoveHandle()
    {
       // TODO: MoveHandle for bot!
    }

    #endregion

    #region --- Fields ---

    [Header("Player handler")]
    //[SerializeField] private PlayerInputH _control;
    //[SerializeField] private PlayerActionH _action;

    [Header("Test properties")]
    public List<GameObject> _bricks = new List<GameObject>();

    #endregion
}
