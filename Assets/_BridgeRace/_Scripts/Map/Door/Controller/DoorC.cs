using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorC : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(TagCollection.PLAYER) && !other.gameObject.CompareTag(TagCollection.BOT)) return;

        if(gameObject.CompareTag(TagCollection.FINISH) && other.gameObject.CompareTag(TagCollection.BOT))
        {
            UIManager.Ins.OpenUI<Lose>();
            GameManager.ChangeState(EGameState.Lose);

            Time.timeScale = 0f;

            return;
        }

        GetController(other.GetComponent<PlayerC>());

        GetController(other.GetComponent<BotC>());
    }

    #endregion

    private void GetController<TStateM, TStatsM>(CharacterC<TStateM, TStatsM> ctrl)
    {
        if (ctrl == null) return;

        BotC botCtrl = null;
        if (ctrl is BotC)
        {
            botCtrl = ctrl as BotC;
        }

        LevelManagerIns.Instance.NextFloor(_floorC, ctrl.GetColorType, botCtrl);
        _floorC.State.IsAutoGenerate = true;
    }

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private FloorC _floorC;

    #endregion
}
