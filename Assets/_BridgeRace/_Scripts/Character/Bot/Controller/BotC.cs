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
        // If no bricks and is building, stop building => Build -> Collect
        if (_stateM.Bricks.Count <= 0 && _stateM.IsBuilding)
        {
            _stateM.IsBuilding = false;
            SetTarget();
            return;
        }

        // If brick slot is full, go to finish position and start building => Collect -> Build
        if (_stateM.Bricks.Count >= _stateM.MaxBrickSlot && !_stateM.IsBuilding)
        {
            _stateM.NavMeshAgent.SetDestination(LevelManagerIns.Instance.LevelM.TransPosFinish);
            _stateM.IsBuilding = true;
            return;
        }

        // Collect brick if not building
        if (!_stateM.NavMeshAgent.pathPending && _stateM.NavMeshAgent.remainingDistance <= _stateM.NavMeshAgent.stoppingDistance)
            SetTarget();
    }

    #endregion

    #region --- Unity Methods ---

    private void Start()
    {
        ResetBrickPos();
        SetTarget();
    }

    private void Update()
    {
        OnMoveC();
    }

    #endregion

    #region --- Methods ---

    private void ResetBrickPos()
    {
        if (_stateM.TargetPositions.Count > 0) return;

        _handler.SetTargetPos(this, (targets) =>
        {
            _stateM.TargetPositions = targets;
        });
    }

    private void SetTarget()
    {
        _handler.SetTarget(_stateM.TargetPositions, (target, index) =>
        {
            _stateM.NavMeshAgent.SetDestination(target);
        });
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private BotActionH _handler;

    #endregion
}
