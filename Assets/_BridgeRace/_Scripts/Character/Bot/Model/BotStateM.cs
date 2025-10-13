using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotStateM : CharacterM
{
    #region --- Properties ---

    public List<Vector3> TargetPositions { get; set; } = new List<Vector3>();
    public NavMeshAgent NavMeshAgent  => _navMeshAgent;

    public Vector3 FinishPos { get; set; }

    public bool IsBuilding { get; set; } = false;

    public int MaxBrickSlot => UnityEngine.Random.Range(8, 12);

    #endregion

    #region --- Fields ---

    [SerializeField] private NavMeshAgent _navMeshAgent;

    #endregion
}
