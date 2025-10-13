using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }

    public void NextButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();

        GameManager.ChangeState(EGameState.GamePlay);

        Time.timeScale = 1f;

        Close(0);
    }
}
