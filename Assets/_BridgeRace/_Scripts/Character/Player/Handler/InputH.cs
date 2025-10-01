using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputH : MonoBehaviour
{
    #region --- Methods ---

    public Vector2 GetInput() => _control.Direction;

    #endregion

    #region --- Fields ---

    [SerializeField] private Joystick _control;

    #endregion
}
