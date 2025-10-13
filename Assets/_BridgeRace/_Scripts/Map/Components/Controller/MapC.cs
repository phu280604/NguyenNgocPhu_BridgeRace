using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapC : MonoBehaviour
{
    #region --- Unity methods ---

    private void Start()
    {
        OnInit();
    }

    private void Update()
    {
        if(GameManager.GetState() == EGameState.GamePlay)
            CallSpawnBrickBaseOnFloor();
    }

    #endregion

    #region --- Methods --- 

    private void OnInit()
    { 
        List<EColor> colors = new List<EColor> { LevelManagerIns.Instance.LevelM.PlayerColorType };

        foreach (KeyValuePair<BotC, List<Vector3>> item in LevelManagerIns.Instance.LevelM.BotMatchBrickPos)
        {
            if (!colors.Contains(item.Key.GetColorType))
            {
                colors.Add(item.Key.GetColorType);
            }
        }

        _model.Floors[0].GenerateBrick(colors);
        _model.Floors[0].State.IsAutoGenerate = true;
    }

    private void CallSpawnBrickBaseOnFloor()
    {
        if (LevelManagerIns.Instance.LevelM.Floor == count && !_model.IsTriggered) return;

        if(LevelManagerIns.Instance.LevelM.Floor >= _model.DetailFloors.Count || LevelManagerIns.Instance.LevelM.IsReseting)
        {
            ResetMap();

            OnInit();

            count = 0;
            _model.IsTriggered = false;

            if (!LevelManagerIns.Instance.LevelM.IsReseting)
            {
                
                UIManager.Ins.OpenUI<Win>();

                GameManager.ChangeState(EGameState.Win);

                LevelManagerIns.Instance.NextLevel();

                Time.timeScale = 0f;
            }
            else
            {
                LevelManagerIns.Instance.LevelM.IsReseting = false;
            }

            

            return;
        }

        count = LevelManagerIns.Instance.LevelM.Floor;

        FloorC floorCtrl = _model.Floors[count];

        _model.Floors[count].GenerateBrick(_model.DetailFloors[floorCtrl]);
        _model.IsTriggered = false;
    }

    public void ResetMap()
    {
        foreach (FloorC item in _model.Floors)
        {
            item.NextLevel();
        }

        foreach(KeyValuePair<FloorC, List<EColor>> item in _model.DetailFloors)
        {
            item.Value.Clear();
        } 
    }

    #endregion

    #region --- Properties ---

    public MapM MapM() => _model; 

    #endregion

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private MapM _model;

    private int count = 0;

    #endregion
}
