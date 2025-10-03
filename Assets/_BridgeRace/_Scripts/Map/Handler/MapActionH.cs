using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MapActionH : MonoBehaviour
{
    #region --- Methods ---

    public void GenerateBricks()
    {
        _col = (_mapM.column / 2);
        _row = (_mapM.row / 2);
        Vector3 curPos = new Vector3(-_col, 0.4f, _row);

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

    [SerializeField] private MapMSO _mapM;
    [SerializeField] private GameObject _goBrick;
    [SerializeField] private Transform _goParBrick;

    private int _col = 0, _row = 0;

    #endregion
}
