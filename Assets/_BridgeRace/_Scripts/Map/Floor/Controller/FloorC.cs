using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloorC is responsible for triggering the brick generation on this floor
/// when the scene starts by calling the <see cref="_mapH"/> FloorActionH component.
/// </summary>
public class FloorC : MonoBehaviour
{
    #region --- Unity Methods ---



    #endregion

    #region --- Methods ---

    public void GenerateBrick()
    {
        _floorH.GenerateBricks(
            _floorM.shapeBricks,
            new Vector2Int(_floorM.row, _floorM.column),
            this.gameObject.transform.position,
            (Bricks) =>
            {
                Bricks.Shuffle();

                int amountChar = LevelManagerIns.Instance.LevelM.BotMatchBrickPos.Count + 1;

                int maxBrickPerChar = Bricks.Count / amountChar;
                int oddBrick = Bricks.Count % amountChar;

                #region -- Split bricks for Character --
                Vector2Int index = new Vector2Int(0, maxBrickPerChar + 1);
                oddBrick--;

                // For player.
                _floorH.SplitBricks(Bricks, ref index, LevelManagerIns.Instance.LevelM.PlayerColorType, null);

                // For bot.
                foreach(KeyValuePair<BotC, List<Vector3>> item in LevelManagerIns.Instance.LevelM.BotMatchBrickPos)
                {
                    
                    if(oddBrick == 0 && index.y - index.x > maxBrickPerChar)
                        index = new Vector2Int(index.x, index.y - 1);

                    _floorH.SplitBricks(Bricks, ref index, item.Key.GetColorType, (val) =>
                    {
                        if (item.Value.Contains(val))
                        {
                            Debug.LogError("Duplicate position for bot!");
                            return;
                        }

                        item.Value.Add(val);
                    });

                    if(oddBrick != 0) 
                        oddBrick--;
                }
                #endregion
            }
        );
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
