using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a bot controller that manages bot's handler.
/// </summary>
public class BotC : CharacterC<BotStateM, CharStatsSO>
{
    #region --- Overrides ---

    public override void OnMoveC()
    {
        // TODO: MoveHandle for bot!
        throw new System.NotImplementedException();
    }

    public override void OnRotationC()
    {
        // TODO: RotationHandle for bot!
        throw new System.NotImplementedException();
    }

    #endregion

    #region --- Unity Methods ---

    private void Update()
    {

    }

    #endregion

    #region --- Fields ---

    #endregion
}
