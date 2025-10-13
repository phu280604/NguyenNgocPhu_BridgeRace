using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerM : MonoBehaviour
{
    #region --- Properties ---

    public Transform ObjParent => _objParent;

    public GameObject GOPlayer => _goPlayerPrefab;
    public GameObject GOBot => _goBotPrefab;

    public Transform MapParent => _mapParent;

    public GameObject GOMapPrefab => _goMapPrefab;

    public MapC MapC { get; set; }

    public ColorSO ColorType => _colorType;

    public int NpcLimit => _npcLimit;

    public int Level { get; set; } = 1;
    public int Floor { get; set; } = 0;

    public bool IsReseting { get; set; } = false;

    public Dictionary<BotC, List<Vector3>> BotMatchBrickPos { get; set; } = new Dictionary<BotC, List<Vector3>>();
    public EColor PlayerColorType { get; set; } = EColor.DEFAULT;

    #endregion

    #region --- Fields ---

    [Header("Object components")]
    [SerializeField] private Transform _objParent;
    [SerializeField] private GameObject _goPlayerPrefab;
    [SerializeField] private GameObject _goBotPrefab;

    [Header("Map components")]
    [SerializeField] private Transform _mapParent;
    [SerializeField] private GameObject _goMapPrefab;

    [Header("Scriptable objects")]
    [SerializeField] private ColorSO _colorType;

    [Header("Parameters")]
    [SerializeField] private int _npcLimit;

    #endregion
}
