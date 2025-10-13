using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    #region --- Methods ---

    public void WinButton()
    {
        UIManager.Ins.OpenUI<Win>().score.text = Random.Range(100, 200).ToString();
        Close(0);
    }

    public void LoseButton()
    {
        UIManager.Ins.OpenUI<Lose>().score.text = Random.Range(0, 100).ToString(); 
        Close(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }

    public void SetLevel(int level)
    {
        levelText.text = "Level " + level;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private TMPro.TextMeshProUGUI levelText;

    #endregion
}
