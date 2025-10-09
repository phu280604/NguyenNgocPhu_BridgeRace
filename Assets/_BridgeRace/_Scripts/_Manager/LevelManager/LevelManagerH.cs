using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerH : MonoBehaviour
{
    #region --- Methods ---

    public void GeneratePrefab(GameObject prefab, Transform parent, Vector3 spawnPos, Action<GameObject> onChange)
    {
        GameObject newPrefab = Instantiate(prefab, spawnPos, Quaternion.identity, parent);
        onChange?.Invoke(newPrefab);
    }

    #endregion
}
