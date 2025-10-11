using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapM : MonoBehaviour
{
    #region --- Properties ---

    public Vector3 SpawnPos => _spawnPos.position;

    public Dictionary<int, List<Transform>> FloorDoors { get; set; } = new Dictionary<int, List<Transform>>();

    public List<FloorC> Floors => _floors;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _spawnPos;

    [SerializeField] private List<FloorC> _floors = new List<FloorC>();

    #endregion
}
