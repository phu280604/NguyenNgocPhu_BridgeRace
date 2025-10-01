using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// Represents a Character stats.
/// </summary>
[CreateAssetMenu(fileName ="Stats", menuName ="Character/Stats")]
public class CharStatsSO : ScriptableObject
{
    #region --- Fields ---

    public float speed;

    #endregion
}
