using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerM : MonoBehaviour
{
    #region --- Properties ---

    public Transform ObjParent() => _objParent;

    public GameObject GOPlayer() => _goPlayerPrefab;
    public GameObject GOBot() => _goBotPrefab;

    public Transform MapParent() => _mapParent;

    public GameObject GOMapPrefab() => _goMapPrefab;


    public int Level { get; set; } = 0;
    public int Floor { get; set; } = 0;

    public int NpcLimit() => _npcLimit;

    public Dictionary<EColor, List<Vector3>> ObjsMatchWithKey { get; set; } = new Dictionary<EColor, List<Vector3>>();

    #endregion

    #region --- Fields ---

    [Header("Object components")]
    [SerializeField] private Transform _objParent;
    [SerializeField] private GameObject _goPlayerPrefab;
    [SerializeField] private GameObject _goBotPrefab;

    [Header("Map components")]
    [SerializeField] private Transform _mapParent;
    [SerializeField] private GameObject _goMapPrefab;

    [Header("Parameters")]
    [SerializeField] private int _npcLimit;

    #endregion
}
