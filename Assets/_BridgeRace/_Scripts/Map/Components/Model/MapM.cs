using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapM : MonoBehaviour
{
    #region --- Properties ---

    public Vector3 SpawnPos() => _spawnPos.position;

    #endregion

    #region --- Fields ---

    [SerializeField] private Transform _spawnPos;

    #endregion
}
