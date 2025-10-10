using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeC : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnGenerateBrick();
    }

    #endregion

    #region --- Methods ---

    public void OnGenerateBrick()
    {
        Vector3 spawnPos = _bridgeM.AnchorStart.position;

        while(spawnPos.z < _bridgeM.AnchorEnd.position.z)
        {
            _bridgeActionH.GenerateBridgeBrick(
                _bridgeM.BrickPrefab,
                _bridgeM.ParBrick,
                spawnPos
            );

            spawnPos = new Vector3(
                spawnPos.x,
                spawnPos.y + _bridgeM.Height,
                spawnPos.z + 1f
            );
        }

        _bridgeActionH.GenerateBridgeBrick(
            _bridgeM.BrickPrefab,
            _bridgeM.ParBrick,
            spawnPos
        );
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private BridgeActionH _bridgeActionH;
    [SerializeField] private BridgeM _bridgeM;

    #endregion
}
