using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapC : MonoBehaviour
{
    #region --- Unity methods ---

    private void Start()
    {
        _floors[count].GenerateBrick();
    }

    private void Update()
    {
        CallSpawnBrickBaseOnFloor();
    }

    #endregion

    #region --- Methods --- 

    private void CallSpawnBrickBaseOnFloor()
    {
        if (LevelManager.Instance.Floor == count) return;

        if(LevelManager.Instance.Floor >= _floors.Count)
        {
            LevelManager.Instance.nextLevel();
            return;
        }

        count = LevelManager.Instance.Floor;
        _floors[count].GenerateBrick();
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private List<FloorC> _floors = new List<FloorC>();
    private int count = 0;

    #endregion
}
