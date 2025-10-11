using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotActionH : CharacterActionH
{
    #region --- Methods ---

    public void SetTargetPos(BotC ctrl, Action<List<Vector3>> onSetTargetPositions)
    {
        List<Vector3> targets = new List<Vector3>();
        LevelManagerIns.Instance.LevelM.BotMatchBrickPos.TryGetValue(ctrl, out targets);

        if (targets == null || targets.Count == 0) return;

        onSetTargetPositions?.Invoke(targets);
    }

    public void SetTarget(List<Vector3> targetPositions, Action<Vector3, int> onSetTarget)
    {
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, targetPositions.Count);

        Vector3 tarPos = targetPositions[index];

        onSetTarget?.Invoke(tarPos,index);
    }

    #endregion
}
