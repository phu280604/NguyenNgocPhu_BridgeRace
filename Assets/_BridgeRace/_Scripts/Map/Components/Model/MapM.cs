using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MapM : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        for(int i = 1; i < _floors.Count; i++)
        {
            if (!DetailFloors.ContainsKey(_floors[i]))
                DetailFloors.Add(_floors[i], new List<EColor>());
        }
    }

    #endregion

    #region --- Properties ---

    public Vector3 SpawnPos => _spawnPos.position;

    public Dictionary<int, List<Transform>> FloorDoors { get; set; } = new Dictionary<int, List<Transform>>();

    public Dictionary<FloorC, List<EColor>> DetailFloors { get; set; } = new Dictionary<FloorC, List<EColor>>();

    public List<FloorC> Floors => _floors;

    public List<LevelMapSO> MapData => _mapData;

    public bool IsTriggered { get; set; } = false;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _spawnPos;

    [SerializeField] private List<FloorC> _floors = new List<FloorC>();

    [SerializeField] private List<LevelMapSO> _mapData = new List<LevelMapSO>();

    #endregion
}
