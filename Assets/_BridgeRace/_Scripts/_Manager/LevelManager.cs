using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MySingleton<LevelManager>
{
    #region --- Methods ---

    public void nextLevel()
    {
        Debug.Log("next level!");
    }

    public void NextFloor()
    {
        _floor++;
    }

    #endregion

    #region --- Properties ---

    public int Floor => _floor;

    #endregion

    #region --- Fields ---

    private int _level = 0;
    private int _floor = 0;


    #endregion
}
