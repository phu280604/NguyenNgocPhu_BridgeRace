using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStateM : MonoBehaviour
{
    #region --- Properties ---

    public EColor ColorType
    {
        get
        {
            return colorType;
        }
        set 
        {
            colorType = value;
        }
    }

    #endregion

    public EColor colorType;
}
