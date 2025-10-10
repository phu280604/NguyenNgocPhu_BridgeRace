using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecollectingBrickH : BrickH
{
    #region --- Overrides ---

    public override void OnAction(List<GameObject> bricks, Transform parentBricks, EColor colorType)
    {
        if(bricks.Count <= 0) return;

        if (isBuilt && colorType == stateM.ColorType) return;

        MeshRenderer mr = goMeshBrick.GetComponent<MeshRenderer>();

        // Not build yet
        // Clone.
        GameObject lastestBrick = bricks[bricks.Count - 1];

        // Remove from list and destroy.
        bricks.RemoveAt(bricks.Count - 1);
        Destroy(lastestBrick);

        // Change color type.
        _ctrl.ChangeColor(LevelManagerIns.Instance.LevelM.ColorType().GetColor(colorType));
        stateM.ColorType = colorType;

        isBuilt = true;
    }

    public override void OnVisual(EColor colorType)
    {
        if(isBuilt)
        {
            ShowBrick();
            HideBrick();
        }
    }

    #endregion

    #region --- Methods ---

    private void HideBrick()
    {
        gameObject.GetComponentInParent<Collider>().enabled = false;
    }

    private void ShowBrick()
    {
        goMeshBrick.SetActive(true);
    }

    #endregion

    #region --- Fields ---

    [SerializeField] private BrickC _ctrl;

    [SerializeField] private bool isBuilt = false;

    #endregion
}
