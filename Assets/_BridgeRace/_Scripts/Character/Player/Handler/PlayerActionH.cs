using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

/// <summary>
/// Represents a player action handler that manages action updates for a player character.
/// </summary>
/// <remarks>This class extends <see cref="CharacterActionH{TState, TStats}"/> to provide player-specific function
/// logic. It allows updating and handling action.</remarks>
public class PlayerActionH : CharacterActionH
{
    #region --- Overrides ---

    /// <summary>
    /// Handle move for Character.
    /// </summary>
    /// <param name="objTrans">reference to Character's transform.</param>
    /// <param name="time">is a time in Update function.</param>
    public override Vector3 MoveH(Vector2 dir2D, float movingParam, Vector3 curPos)
    {
        Vector3 dir3D = ConvertDirection2DTo3D(dir2D);

        return Vector3.Lerp(curPos, curPos + dir3D, movingParam);
    }

    #endregion

    #region --- Methods ---
    
    public void RotationH(Vector2 dir, Action<Quaternion> onRotation)
    {
        Quaternion targetRotation = Quaternion.LookRotation(ConvertDirection2DTo3D(dir), Vector3.up);
        onRotation.Invoke(targetRotation);
    }

    /// <summary>
    /// Updates the movement direction and determines whether movement is allowed.
    /// </summary>
    /// <remarks>If <paramref name="dir"/> is not <see cref="Vector2.zero"/>, the movement direction is
    /// updated to a 3D vector with the Y component set to 0. Otherwise, the direction is reset to <see
    /// cref="Vector3.zero"/>. The ability to move is determined based on whether <paramref name="dir"/> is
    /// non-zero.</remarks>
    /// <param name="dir">The direction of movement as a 2D vector. A value of <see cref="Vector2.zero"/> indicates no movement.</param>
    public Vector3 ConvertDirection2DTo3D(Vector2 dir2D)
    {
       if(dir2D == Vector2.zero) return Vector3.zero;

        return new Vector3(dir2D.x, 0, dir2D.y);
    }

    public float CalculateMovingParameter(float speed, float time) => speed * time;

    #endregion
}
