using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// FloorC is responsible for triggering the brick generation on this floor
/// when the scene starts by calling the <see cref="_mapH"/> FloorActionH component.
/// </summary>
public class FloorC : MonoBehaviour
{

    #region --- Methods ---

    public void GenerateBrick(List<EColor> colors)
    {
        if(_floorStateM.BricksOnFloor.Count > 0)
        {
            ReplaceBrick(colors);
            return;
        }

        _floorH.GenerateBricks(
            _floorM.shapeBricks,
            new Vector2Int(_floorM.row, _floorM.column),
            this.gameObject.transform.position,
            (Bricks) =>
            {
                Bricks.Shuffle();

                _floorStateM.BricksOnFloor = Bricks;

                ReplaceBrick(colors);
            }
        );
    }

    public void NextLevel()
    {
        DestroyBrick();
        HideBridgeBrick();

        _floorStateM.BricksOnFloor.Clear();

        if(!LevelManagerIns.Instance.LevelM.IsReseting)
            _floorM = _floorM.nextLevel;

        _floorStateM.IsAutoGenerate = false;
    }

    private void DestroyBrick()
    {
        List<GameObject> bricks = GameObject.FindGameObjectsWithTag(TagCollection.BRICK).ToList();

        for(int i = 0; i < bricks.Count; i++)
        {
            Destroy(bricks[i]);
        }
    }

    private void HideBridgeBrick()
    {
        List<BrickC> bricks = GameObject.FindGameObjectsWithTag(TagCollection.BRIDGE_BRICK)
            .Select(s => s.GetComponent<BrickC>())
            .ToList();

        for (int i = 0; i < bricks.Count; i++)
        {
            bricks[i].ResetBrick();
        }
    }

    public void ReplaceBrick(List<EColor> colors)
    {
        int amountColor = colors.Count;

        int maxBrickPerColor = _floorStateM.BricksOnFloor.Count / amountColor;
        int oddBrick = _floorStateM.BricksOnFloor.Count % amountColor;

        Vector2Int index = new Vector2Int(0, maxBrickPerColor);
        if (oddBrick != 0)
        {
            index = new Vector2Int(0, maxBrickPerColor + 1);
            oddBrick--;
        }

        foreach (EColor item in colors)
        {
            if (item == LevelManagerIns.Instance.LevelM.PlayerColorType)
                _floorH.SplitBricks(_floorStateM.BricksOnFloor, ref index, LevelManagerIns.Instance.LevelM.PlayerColorType, null);
            else
            {
                if (oddBrick == 0 && index.y - index.x > maxBrickPerColor)
                    index = new Vector2Int(index.x, index.y - 1);

                foreach(KeyValuePair<BotC, List<Vector3>> botColor in LevelManagerIns.Instance.LevelM.BotMatchBrickPos)
                {
                    if(botColor.Key.GetColorType == item)
                    {
                        botColor.Value.Clear();

                        _floorH.SplitBricks(_floorStateM.BricksOnFloor, ref index, item, (val) =>
                        {
                            botColor.Value.Add(val);
                        });

                        if (oddBrick != 0)
                            oddBrick--;
                    }
                }
            }
        }
    }

    #endregion

    #region --- Properties ---

    public FloorStateM State => _floorStateM;

    #endregion

    #region --- Fields ---

    [Header("Handler components")]
    [SerializeField] private FloorActionH _floorH;

    [Header("Model components")]
    [SerializeField] private FloorStateM _floorStateM;
    [SerializeField] private FloorMSO _floorM;

    #endregion
}
