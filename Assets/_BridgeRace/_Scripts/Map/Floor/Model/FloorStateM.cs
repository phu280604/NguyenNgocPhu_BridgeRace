using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorStateM : MonoBehaviour
{
    #region --- Properties ---

    public bool IsAutoGenerate { get; set; } = false;

    public List<Transform> TransDoors => _transDoors;

    #endregion

    #region --- Fields ---

    [SerializeField] private List<Transform> _transDoors = new List<Transform>();

    #endregion
}
