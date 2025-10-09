using System.Collections;
using System.Collections.Generic;
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
        GenerateObject();
    }

    private void GenerateObject()
    {
        Vector3 spawnPos = Vector3.zero;
        _handler.GeneratePrefab(_model.GOMapPrefab(), _model.MapParent(), Vector3.zero, (newGo) =>
        {
            newGo.name = "Map #0";
            MapC _ctrl = newGo.GetComponent<MapC>();

            if (_ctrl != null)
                spawnPos = _ctrl.MapM().SpawnPos();
        });

        _handler.GeneratePrefab(_model.GOPlayer(), _model.ObjParent(), new Vector3(spawnPos.x, spawnPos.y, spawnPos.z), (newGo) =>
        {
            newGo.name = "Player #0";
        });

        for(int i = 1; i <= _model.NpcLimit(); i++)
        {

            _handler.GeneratePrefab(_model.GOBot(), _model.ObjParent(), new Vector3(spawnPos.x + i, spawnPos.y, spawnPos.z + i), (newGo) =>
            {
                newGo.name = $"Bot #{i}";
            });
        }
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
