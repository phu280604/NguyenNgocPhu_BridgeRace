using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles player input by retrieving directional input from a joystick control.
/// </summary>
/// <remarks>This class is responsible for managing player input through a joystick component. It initializes the
/// joystick control, retrieves its directional input, and provides it as a 2D vector. The class is designed to be used
/// in Unity-based projects and assumes that the joystick control is associated with a GameObject tagged with a specific
/// identifier.</remarks>
public class PlayerInputH : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Initializes the component and performs necessary setup operations.
    /// </summary>
    /// <remarks>This method is called to prepare the component for use. It ensures that required controls 
    /// are located and ready for interaction. Call this method during the initialization phase  of the component
    /// lifecycle.</remarks>
    private void OnInit()
    {
        FindControl();
    }

    /// <summary>
    /// Finds and initializes the control associated with the specified tag, if it has not already been initialized.
    /// </summary>
    /// <remarks>This method searches for a GameObject with the specified tag and retrieves its <see
    /// cref="Joystick"/> component.  If the control has already been initialized, the method does nothing.</remarks>
    private void FindControl()
    {
        if (_control == null)
            _control = GameObject.FindWithTag(_tag).GetComponent<Joystick>();
    }

    /// <summary>
    /// Retrieves the current input direction as a 2D vector.
    /// </summary>
    /// <returns>A <see cref="Vector2"/> representing the direction of input, where the X and Y components indicate the
    /// horizontal and vertical input values, respectively.</returns>
    public Vector2 GetInput() => _control.Direction;

    #endregion

    #region --- Fields ---

    [SerializeField] private Joystick _control;

    [SerializeField] private string _tag;

    #endregion
}
