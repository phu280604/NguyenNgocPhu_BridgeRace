using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public void GenerateBricks(
        int[] shapeBricks,
        Vector2Int sizeShape,
        Vector3 floorPos, 
        Action<List<BrickC>> bricks)
    {
        _col = sizeShape.y / 2;
        _row = sizeShape.x / 2;

        Vector3 curPos = new Vector3(-_col + floorPos.x, 0.4f + floorPos.y, _row + floorPos.z);

        List<BrickC> listBricks = new List<BrickC>();

        for (int i = 0; i < sizeShape.x; i++)
        {
            Vector3 tmp = curPos;
            for (int j = 0; j < sizeShape.y; j++)
            {
                int index = i * sizeShape.y + j;

                if (i != 0 || j != 0)
                {
                    tmp = new Vector3(curPos.x + j, curPos.y, curPos.z - i);
                }

                if (shapeBricks[index] != 1)
                    continue;

                GameObject newBrick = Instantiate(_goBrick, tmp, Quaternion.identity, _goParBrick);
                newBrick.name = $"Brick #{index}";

                BrickC ctrl = newBrick.GetComponent<BrickC>();

                if(ctrl == null)
                {
                    Debug.LogError("Can't get BrickC");
                    return;
                }

                if (!listBricks.Contains(ctrl))
                    listBricks.Add(ctrl);
            }
        }

        bricks?.Invoke(listBricks);
    }

    public void SplitBricks(
        List<BrickC> bricks,
        ref Vector2Int index,
        EColor colorType,
        Action<Vector3>? getPos)
    {
        for (int i = index.x; i < index.y; i++)
        {
            bricks[i].SetColorType(colorType);

            Material mat = LevelManagerIns.Instance.LevelM.ColorType.GetColor(colorType);
            bricks[i].ChangeColor(mat);

            getPos?.Invoke(bricks[i].transform.position);
        }

        
        int amount = index.y - index.x;
        index = new Vector2Int(index.x + amount, index.y + amount); 
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private GameObject _goBrick;
    [SerializeField] private Transform _goParBrick;

    private int _col = 0;
    private int _row = 0;

    #endregion
}
