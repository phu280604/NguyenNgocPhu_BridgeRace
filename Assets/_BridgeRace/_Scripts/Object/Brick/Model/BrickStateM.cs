using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickM : MonoBehaviour
{
    #region --- Properties ---

    public MeshRenderer GetMeshRender => meshBrick;
    public Collider GetCollider => colBrick;

    #endregion

    #region --- Fields ---

    [SerializeField] private MeshRenderer meshBrick;
    [SerializeField] private Collider colBrick;

    #endregion
}
