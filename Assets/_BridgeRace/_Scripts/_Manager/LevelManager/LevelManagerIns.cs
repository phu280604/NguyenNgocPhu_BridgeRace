using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManagerIns : MySingleton<LevelManagerIns>
{

    #region --- Methods ---

    public void OnInit()
    {
        _model.BotMatchBrickPos.Clear();
        GenerateObject();
    }

    private void GenerateObject()
    {
        _model.ColorType.SetListColor();

        SpawnMap();

        SpawnPlayer();

        SpawnBot();

        SetPosition(2);
    }

    #region -- Spawn Prefab --
    private void SpawnMap()
    {
        #region -- Spawn Map --
        _handler.GeneratePrefab(_model.GOMapPrefab, _model.MapParent, Vector3.zero, (newGo) =>
        {
            newGo.name = "Map #0";
            MapC ctrl = newGo.GetComponent<MapC>();

            if (ctrl == null)
            {
                Debug.LogError("Can't get MapC");
                return;
            }

            _model.MapC = ctrl;
        });
        #endregion
    }

    private void SpawnPlayer()
    {
        #region -- Spawn Player --
        Vector3 SpawnPos = _model.MapC.MapM().SpawnPos;
        _handler.GeneratePrefab(_model.GOPlayer, _model.ObjParent, new Vector3(SpawnPos.x, SpawnPos.y, SpawnPos.z), (newGo) =>
        {
            newGo.name = "Player #0";
            PlayerC ctrl = newGo.GetComponent<PlayerC>();

            if (ctrl == null)
            {
                Debug.LogError("Can't get PlayerC");
                return;
            }

            SetUpColorTypeForObject(ctrl);
            _model.PlayerColorType = ctrl.GetColorType;
        });
        #endregion
    }

    private void SpawnBot()
    {
        #region -- Spawn Bots --
        Vector3 SpawnPos = _model.MapC.MapM().SpawnPos;
        if (_model.BotMatchBrickPos.Count > _model.NpcLimit)
        {
            foreach (List<Vector3> positions in _model.BotMatchBrickPos.Values)
                positions.Clear();
        }
        else
        {
            int curBot = _model.BotMatchBrickPos.Count;

            for (int i = 1; i <= _model.NpcLimit - curBot; i++)
            {
                _handler.GeneratePrefab(_model.GOBot, _model.ObjParent, new Vector3(SpawnPos.x + i, SpawnPos.y, SpawnPos.z + i), (newGo) =>
                {
                    newGo.name = $"Bot #{i}";
                    BotC ctrl = newGo.GetComponent<BotC>();

                    if (ctrl == null)
                    {
                        Debug.LogError("Can't get BotC");
                        return;
                    }

                    // Set Color.
                    SetUpColorTypeForObject(ctrl);

                    // Set Finish Pos.
                    int index = UnityEngine.Random.Range(0, _model.MapC.MapM().Floors[0].State.TransDoors.Count);
                    ctrl.SetFinishPos(_model.MapC.MapM().Floors[0].State.TransDoors[index].position);

                    if (!_model.BotMatchBrickPos.ContainsKey(ctrl))
                        _model.BotMatchBrickPos[ctrl] = new List<Vector3>();
                });
            }
        }
        #endregion
    }
    #endregion

    // Set color for player and bot
    private void SetUpColorTypeForObject<TStateM, TStatsM>(CharacterC<TStateM, TStatsM> ctrl)
    {
        EColor newColorType = _model.ColorType.GetRandomColor();

        ctrl.SetColorType(newColorType);
        ctrl.ChangeColor(_model.ColorType.GetColor(newColorType));
    }

    private void SetPosition(int gap)
    {
        List<Transform> transPrefab = new List<Transform>();

        // Thêm player
        transPrefab.Add(GameObject.FindWithTag(TagCollection.PLAYER).transform);

        // Thêm tất cả BotC
        transPrefab.AddRange(
            GameObject.FindObjectsByType<BotC>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .Select(x => x.transform)
        );

        transPrefab.Shuffle();

        Vector3 newPos = new Vector3(_model.MapC.MapM().SpawnPos.x + gap, _model.MapC.MapM().SpawnPos.y, _model.MapC.MapM().SpawnPos.z);
        for (int i = 0; i < transPrefab.Count / 2; i++)
        {
            transPrefab[i].position = newPos;
            transPrefab[transPrefab.Count - i - 1].position = new Vector3(newPos.x * -1, newPos.y, newPos.z);

            newPos += new Vector3(gap, 0, 0);
        }
    }

    public void NextLevel()
    {
        SetPosition(2);

        ResetCharacter();

        _model.Floor = 0;
    }

    public void RestartLevel()
    {
        SetPosition(2);

        ResetCharacter();

        _model.Floor = 0;
        _model.IsReseting = true;
    }

    private void ResetCharacter()
    {
        GameObject.FindObjectOfType<PlayerC>()?.ResetListBrick();

        List<BotC> bots = GameObject.FindObjectsByType<BotC>(sortMode: FindObjectsSortMode.None).ToList();
        foreach(BotC bot in bots)
        {
            bot.ResetListBrick();
            bot.ResetFinishPos(_model.MapC.MapM().Floors[0].State.TransDoors);
        }
    }

    public void NextFloor(FloorC floorCtrl, EColor colorType, BotC bot = null)
    {
        if(!_model.MapC.MapM().DetailFloors[floorCtrl].Contains(colorType))
        {
            _model.MapC.MapM().DetailFloors[floorCtrl].Add(colorType);
            _model.MapC.MapM().IsTriggered = true;
        }

        if(!floorCtrl.State.IsAutoGenerate)
            _model.Floor++;

        if (bot != null)
        {
            int index = UnityEngine.Random.Range(0, _model.MapC.MapM().Floors[_model.Floor].State.TransDoors.Count);
            bot.SetFinishPos(_model.MapC.MapM().Floors[_model.Floor].State.TransDoors[index].position);
        }
    }

    #endregion

    #region --- Properties ---

    public LevelManagerH LevelH => _handler;
    public LevelManagerM LevelM => _model;

    #endregion

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private LevelManagerH _handler;
    [SerializeField] private LevelManagerM _model;

    #endregion
}
