using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }

    public void RestartButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();

        LevelManagerIns.Instance.RestartLevel();

        GameManager.ChangeState(EGameState.GamePlay);

        Time.timeScale = 1f;

        Close(0);
    }
}
