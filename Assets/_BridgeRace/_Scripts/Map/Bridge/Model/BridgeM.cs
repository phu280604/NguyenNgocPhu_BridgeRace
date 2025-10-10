using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeM : MonoBehaviour
{
    #region --- Properties ---

    public Transform ParBrick => _parBrick;
    public GameObject BrickPrefab => _brickPrefab;
    public Transform AnchorStart => _anchorStart;
    public Transform AnchorEnd => _anchorEnd;
    public int Amount => _amount;
    public float Height => _height;


    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _parBrick;
    [SerializeField] private GameObject _brickPrefab;

    [SerializeField] private Transform _anchorStart;
    [SerializeField] private Transform _anchorEnd;

    [SerializeField] private int _amount;

    [SerializeField] private float _height;

    #endregion
}
