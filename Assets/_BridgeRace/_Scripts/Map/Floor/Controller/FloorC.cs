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

    /// <summary>
    /// Called by Unity before the first frame update.
    /// Generates bricks at the position of this GameObject using the <see cref="_floorH"/> component.
    /// </summary>
    void Start()
    {
        _floorH.GenerateBricks(this.gameObject.transform.position);
    }

    #endregion

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private FloorActionH _floorH;

    #endregion
}
