using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActionH : MonoBehaviour
{
    #region --- Methods ---

    public void GenerateBridgeBrick(
        GameObject brick,
        Transform parentBrick,
        Vector3 spawnPos
    )
    {
        GameObject newBrick = Instantiate(brick, parentBrick);
        newBrick.transform.position = spawnPos;
    }

    #endregion
}
