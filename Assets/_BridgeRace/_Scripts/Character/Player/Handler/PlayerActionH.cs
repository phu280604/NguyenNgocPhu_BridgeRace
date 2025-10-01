using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

/// <summary>
/// Represents a player action handler that manages action updates for a player character.
/// </summary>
/// <remarks>This class extends <see cref="CharacterActionH{TState, TStats}"/> to provide player-specific function
/// logic. It allows updating and handling action.</remarks>
public class PlayerActionH : CharacterActionH<PlayerStateM, CharStatsSO>
{
    #region --- Overrides ---

    /// <summary>
    /// Handle move for Character.
    /// </summary>
    /// <param name="objTrans">reference to Character's transform.</param>
    /// <param name="time">is a time in Update function.</param>
    public override void MoveH(ref Transform objTrans, float time)
    {
        if (!_canMove) return;

        objTrans.position = Vector3.Lerp(objTrans.position, objTrans.position + _state.Direction, _statsSO.speed * time);
    }

    #endregion

    #region --- Methods ---
    
    /// <summary>
    /// Updates the movement direction and determines whether movement is allowed.
    /// </summary>
    /// <remarks>If <paramref name="dir"/> is not <see cref="Vector2.zero"/>, the movement direction is
    /// updated to a 3D vector with the Y component set to 0. Otherwise, the direction is reset to <see
    /// cref="Vector3.zero"/>. The ability to move is determined based on whether <paramref name="dir"/> is
    /// non-zero.</remarks>
    /// <param name="dir">The direction of movement as a 2D vector. A value of <see cref="Vector2.zero"/> indicates no movement.</param>
    public void GetDirection(Vector2 dir)
    {
       _state.Direction = dir != Vector2.zero ? new Vector3(dir.x, 0, dir.y) : Vector3.zero;

       _canMove = dir != Vector2.zero;
    }

    #endregion

    #region --- Fields ---

    private bool _canMove = false;

    #endregion
}
