using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Represents a player controller that manages Player's handler.
/// </summary>
public class PlayerC : CharacterC<PlayerM, CharStatsSO>
{
    #region --- Overrides ---

    public override void OnMoveC()
    {
        _stateM.Direction = _control.GetInput();

        if (Mathf.Sign(_stateM.Direction.y) < 0)
            _stateM.CanMoving = true;

        if (!_stateM.CanMoving) return;

        float movingParam = _action.CalculateMovingParameter(_statsM.speed, Time.deltaTime);
        Vector3 curPos = this.gameObject.transform.position;

        this.gameObject.transform.position = _action.MoveH(_stateM.Direction, movingParam, curPos);
    }

    #endregion

    #region --- Unity Methods ---

    private void Update()
    {
        OnMoveC();
        OnRotationC();
    }

    private void FixedUpdate()
    {
        OnCheckBridgeBrick();
    }

    #endregion

    #region --- Methods ---

    private void OnCheckBridgeBrick()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, Vector3.forward, out hit, 0.5f);

        if (hit.collider == null || !hit.collider.gameObject.CompareTag(TagCollection.BRIDGE_BRICK))
            return;

        if (_stateM.Bricks.Count <= 0)
            _stateM.CanMoving = false;

    }

    public void OnRotationC()
    {
        if (_stateM.Direction == Vector3.zero) return;

        _action.RotationH(_stateM.Direction, (targetRotation) =>
        {
            this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, targetRotation, Time.deltaTime * _statsM.speed);
        });
    }

    public void ResetListBrick()
    {
        _stateM.Bricks.Clear();
    }

    #endregion

    #region --- Fields ---

    [Header("Handler components")]
    [SerializeField] private PlayerInputH _control;
    [SerializeField] private PlayerActionH _action;

    #endregion
}
