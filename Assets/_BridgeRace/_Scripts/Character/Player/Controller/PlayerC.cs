using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a player controller that manages Player's handler.
/// </summary>
public class PlayerC : CharacterC<PlayerM, CharStatsSO>
{
    #region --- Unity Methods ---

    private void Update()
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
        _stateM.Direction = _control.GetInput();

        float movingParam = _action.CalculateMovingParameter(_statsM.speed, Time.deltaTime);
        Vector3 curPos = this.gameObject.transform.position;

        this.gameObject.transform.position = _action.MoveH(_stateM.Direction, movingParam, curPos);
    }

    #endregion

    #region --- Fields ---

    [Header("Player handler")]
    [SerializeField] private PlayerInputH _control;
    [SerializeField] private PlayerActionH _action;

    [Header("Test properties")]
    public List<GameObject> _bricks = new List<GameObject>();

    #endregion
}
