using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManagerIns : MySingleton<LevelManagerIns>
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    #endregion

    #region --- Methods ---

    private void OnInit()
    {
        _model.BotMatchBrickPos.Clear();
        GenerateObject();
    }

    private void GenerateObject()
    {
        _model.ColorType.SetListColor();

        #region -- Spawn Map --
        Vector3 spawnPos = Vector3.zero;
        _handler.GeneratePrefab(_model.GOMapPrefab, _model.MapParent, Vector3.zero, (newGo) =>
        {
            newGo.name = "Map #0";
            MapC _ctrl = newGo.GetComponent<MapC>();

            if (_ctrl == null)
            {
                Debug.LogError("Can't get MapC");
                return;
            }
            
            spawnPos = _ctrl.MapM().SpawnPos;
        });
        #endregion

        #region -- Spawn Player --
        _handler.GeneratePrefab(_model.GOPlayer, _model.ObjParent, new Vector3(spawnPos.x, spawnPos.y, spawnPos.z), (newGo) =>
        {
            newGo.name = "Player #0";
            PlayerC ctrl = newGo.GetComponent<PlayerC>();

            if(ctrl == null)
            {
                Debug.LogError("Can't get PlayerC");
                return;
            }

            SetUpColorTypeForObject(ctrl);
            _model.PlayerColorType = ctrl.GetColorType;
        });
        #endregion

        #region -- Spawn Bots --
        if (_model.BotMatchBrickPos.Count > _model.NpcLimit)
        {
            foreach(List<Vector3> positions in _model.BotMatchBrickPos.Values)
                positions.Clear();
        }
        else
        {
            int curBot = _model.BotMatchBrickPos.Count;

            for (int i = 1; i <= _model.NpcLimit - curBot; i++)
            {
                _handler.GeneratePrefab(_model.GOBot, _model.ObjParent, new Vector3(spawnPos.x + i, spawnPos.y, spawnPos.z + i), (newGo) =>
                {
                    newGo.name = $"Bot #{i}";
                    BotC ctrl = newGo.GetComponent<BotC>();

                    if (ctrl == null)
                    {
                        Debug.LogError("Can't get BotC");
                        return;
                    }

                    SetUpColorTypeForObject(ctrl);

                    if (!_model.BotMatchBrickPos.ContainsKey(ctrl))
                    {
                        _model.BotMatchBrickPos[ctrl] = new List<Vector3>();
                    }
                });
            }
        }
        #endregion

        _model.TransPosFinish = GameObject.FindWithTag(TagCollection.FINISH_POSITION).transform.position;
    }

    private void SetUpColorTypeForObject<TStateM, TStatsM>(CharacterC<TStateM, TStatsM> ctrl)
    {
        EColor newColorType = _model.ColorType.GetRandomColor();

        ctrl.SetColorType(newColorType);
        ctrl.ChangeColor(_model.ColorType.GetColor(newColorType));
    }

    public void nextLevel()
    {
        Debug.Log("next level!");
    }

    public void NextFloor()
    {
        _model.Floor++;
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
