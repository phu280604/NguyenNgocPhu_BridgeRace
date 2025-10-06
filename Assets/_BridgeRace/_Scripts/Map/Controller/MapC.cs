using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _mapH.GenerateBricks(this.gameObject.transform.position);
    }

    #region --- Fields ---

    [SerializeField] private MapActionH _mapH;

    #endregion
}
