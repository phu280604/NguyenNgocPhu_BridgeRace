using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBrickH : BrickH
{
    #region --- Overrides ---

    public override void OnAction(ref List<GameObject> bricks, EColor colorType)
    {
        if(!canCollect || stateM.ColorType != colorType) return;

        GameObject newBrick = Instantiate(selfObj);
        newBrick.GetComponentInChildren<MeshRenderer>().enabled = false;
        newBrick.GetComponent<Collider>().enabled = false;

        bricks.Add(newBrick);
    }

    public override void OnVisual(EColor colorType)
    {
        if (colorType == stateM.ColorType)
        {
            HideBrick();

            Invoke("ShowBrick", 5f);
        }
    }

    #endregion

    #region --- Methods ---

    private void HideBrick()
    {
        goMeshBrick.SetActive(false);
        canCollect = false;
    }

    private void ShowBrick()
    {
        goMeshBrick.SetActive(true);
        canCollect = true;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] protected GameObject selfObj;

    [SerializeField] private bool canCollect = true;

    #endregion
}
