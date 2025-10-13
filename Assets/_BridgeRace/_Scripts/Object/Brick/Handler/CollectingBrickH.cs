using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingBrickH : BrickH
{
    #region --- Overrides ---

    public override void OnAction(List<GameObject> bricks, Transform parentBrick, EColor colorType)
    {
        if (!canCollect || _ctrl.ColorType != colorType) return;

        canCollect = false;

        GameObject newBrick = Instantiate(selfObj, parentBrick);

        newBrick.GetComponent<Collider>().enabled = false;

        newBrick.transform.localPosition = new Vector3(0, bricks.Count == 0 ? height : height * bricks.Count, 0);

        bricks.Add(newBrick);

        OnVisual(colorType);
    }

    public override void OnVisual(EColor colorType)
    {
        if (colorType == _ctrl.ColorType)
        {
            HideBrick();

            StartCoroutine(ShowBrick());
        }
    }

    #endregion

    #region --- Methods ---

    private void HideBrick()
    {
        _ctrl.GetBrickM.GetMeshRender.enabled = false;
        _ctrl.GetBrickM.GetCollider.enabled = false;
    }

    private IEnumerator ShowBrick()
    {
        yield return new WaitForSeconds(3f);

        _ctrl.GetBrickM.GetMeshRender.enabled = true;
        _ctrl.GetBrickM.GetCollider.enabled = true;

        canCollect = true;
    }

    #endregion

    #region --- Fields ---

    [SerializeField] protected GameObject selfObj;

    [SerializeField] private bool canCollect = true;

    private float height = 0.5f;

    #endregion
}
