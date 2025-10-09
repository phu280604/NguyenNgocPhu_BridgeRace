using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorC : MonoBehaviour
{
    #region --- Unity Methods ---

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(TagCollection.PLAYER)) return;

        if (_floorC.State.IsAutoGenerate) return;

        LevelManagerIns.Instance.NextFloor();
        _floorC.State.IsAutoGenerate = true;
    }

    #endregion

    #region --- Fields ---

    [Header("Custom components")]
    [SerializeField] private FloorC _floorC;

    #endregion
}
