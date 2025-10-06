using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloorActionH is responsible for generating brick GameObjects on a floor
/// based on the configuration stored in a FloorMSO instance.
/// </summary>
public class FloorActionH : MonoBehaviour
{
    #region --- Methods ---

    /// <summary>
    /// Generates bricks at the specified floor position.
    /// Iterates through the <see cref="_mapM"/> shapeBricks array, instantiates
    /// bricks where the value is 1, and positions them relative to <paramref name="floorPos"/>.
    /// </summary>
    /// <param name="floorPos">The world position of the floor's origin for brick placement.</param>
    public void GenerateBricks(Vector3 floorPos)
    {
        _col = (_mapM.column / 2);
        _row = (_mapM.row / 2);
        Vector3 curPos = new Vector3(-_col + floorPos.x, 0.4f + floorPos.y, _row + floorPos.z);

        for (int i = 0; i < _mapM.row; i++)
        {
            Vector3 tmp = curPos;
            for (int j = 0; j < _mapM.column; j++)
            {
                int index = i * _mapM.column + j;

                if (i != 0 || j != 0)
                {
                    tmp = new Vector3(curPos.x + j, curPos.y, curPos.z - i);
                }

                if (_mapM.shapeBricks[index] != 1)
                    continue;

                GameObject newBrick = Instantiate(_goBrick, tmp, Quaternion.identity, _goParBrick);
                newBrick.name = $"Brick #{index}";
            }
        }
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private GameObject _goBrick;
    [SerializeField] private Transform _goParBrick;

    [Header("Custom components")]
    [SerializeField] private FloorMSO _mapM;

    private int _col = 0;
    private int _row = 0;

    #endregion
}
