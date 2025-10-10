using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBrickH : BrickH
{
    #region --- Overrides ---

    public override void OnAction(List<GameObject> bricks, Transform parentBrick, EColor colorType)
    {
        if(!canCollect || stateM.ColorType != colorType) return;

        GameObject newBrick = Instantiate(selfObj, parentBrick);

        newBrick.GetComponent<Collider>().enabled = false;

        newBrick.transform.localPosition = new Vector3(0, bricks.Count == 0 ? height : height * bricks.Count, 0);

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

    private float height = 0.5f;

    #endregion
}
