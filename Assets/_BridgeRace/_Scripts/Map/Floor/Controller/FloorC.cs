using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloorC is responsible for triggering the brick generation on this floor
/// when the scene starts by calling the <see cref="_mapH"/> FloorActionH component.
/// </summary>
public class FloorC : MonoBehaviour
{
    #region --- Unity Methods ---



    #endregion

    #region --- Methods ---

    public void GenerateBrick()
    {
        _floorH.GenerateBricks(this.gameObject.transform.position);
    }

    #endregion

    #region --- Properties ---

    public FloorStateM State => _floorStateM;

    #endregion

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private FloorActionH _floorH;
    [SerializeField] private FloorStateM _floorStateM;

    #endregion
}
