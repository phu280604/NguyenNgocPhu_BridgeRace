using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecollectingBrickH : BrickH
{
    #region --- Overrides ---

    public override void OnAction(List<GameObject> bricks, Transform parentBricks, EColor colorType)
    {
        Debug.Log($"Bricks count: {bricks.Count}");
        if (bricks.Count <= 0) return;

        Debug.Log($"Color: {colorType}");

        if (isBuilt && colorType == _ctrl.ColorType) return;

        // Not build yet
        // Clone.
        GameObject lastestBrick = bricks[bricks.Count - 1];

        // Remove from list and destroy.
        bricks.RemoveAt(bricks.Count - 1);
        Destroy(lastestBrick);

        // Change color type.
        _ctrl.ChangeColor(LevelManagerIns.Instance.LevelM.ColorType.GetColor(colorType));
        _ctrl.SetColorType(colorType);

        isBuilt = true;
    }

    public override void OnVisual(EColor colorType)
    {
        if(isBuilt)
            ShowBrick();
    }

    #endregion

    #region --- Methods ---

    private void ShowBrick()
    {
        _ctrl.GetBrickM.GetMeshRender.enabled = true;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private bool isBuilt = false;

    #endregion
}
