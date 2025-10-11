using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapC : MonoBehaviour
{
    #region --- Unity methods ---

    private void Start()
    {
        _model.Floors[count].GenerateBrick();
    }

    private void Update()
    {
        CallSpawnBrickBaseOnFloor();
    }

    #endregion

    #region --- Methods --- 

    private void CallSpawnBrickBaseOnFloor()
    {
        if (LevelManagerIns.Instance.LevelM.Floor == count) return;

        if(LevelManagerIns.Instance.LevelM.Floor >= _model.Floors.Count)
        {
            LevelManagerIns.Instance.nextLevel();
            return;
        }

        count = LevelManagerIns.Instance.LevelM.Floor;
        _model.Floors[count].GenerateBrick();
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
