using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void FixedUpdate()
    {
        OnCheckBridgeBrick();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Handle move action.
    /// </summary>
    private void MoveHandle()
    {
        _stateM.Direction = _control.GetInput();

        if (Mathf.Sign(_stateM.Direction.y) < 0)
            _stateM.CanMoving = true;

        if(!_stateM.CanMoving) return;

        float movingParam = _action.CalculateMovingParameter(_statsM.speed, Time.deltaTime);
        Vector3 curPos = this.gameObject.transform.position;

        this.gameObject.transform.position = _action.MoveH(_stateM.Direction, movingParam, curPos);
    }

    private void OnCheckBridgeBrick()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, Vector3.forward, out hit, 0.5f);

        if (hit.collider == null || !hit.collider.gameObject.CompareTag(TagCollection.BRIDGE_BRICK))
            return;

        if (_stateM.Bricks.Count <= 0)
            _stateM.CanMoving = false;

    }

    #endregion

    #region --- Fields ---

    [Header("Handler components")]
    [SerializeField] private PlayerInputH _control;
    [SerializeField] private PlayerActionH _action;

    #endregion
}
