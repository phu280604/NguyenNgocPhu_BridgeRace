using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an object that follows a target in the scene based on specified parameters.
/// </summary>
/// <remarks>This class is designed to be used in Unity and requires the target object to be identified by a
/// specific tag. The object will move towards the target's position, applying an optional offset and smoothing the
/// movement based on the configured distance factor. Ensure that the target object exists in the scene and is tagged
/// appropriately for the behavior to function correctly.</remarks>
public class FollowingObject : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Awake()
    {
        OnInit();
    }

    private void Update()
    {
        FollowTarget();
    }

    #endregion

    #region --- Methods ---

    /// <summary>
    /// Performs initialization logic for the object, including locating the target element.
    /// </summary>
    /// <remarks>This method is called to set up the necessary state or dependencies required for the object
    /// to function correctly. It invokes the <see cref="FindTarget"/> method to locate and prepare the target
    /// element.</remarks>
    private void OnInit()
    {
        FindTarget();
    }

    /// <summary>
    /// Locates the first GameObject in the scene with the specified tag and assigns its transform to the target.
    /// </summary>
    /// <remarks>This method searches for a GameObject using the tag specified by the <c>_tag</c> field.  If
    /// no GameObject with the specified tag is found, the target will remain <c>null</c>. Ensure that the <c>_tag</c>
    /// field is set to a valid tag before calling this method.</remarks>
    private void FindTarget()
    {
        _target = GameObject.FindWithTag(_tag).transform;
    }

    /// <summary>
    /// Moves the object toward the target's position, maintaining a specified offset.
    /// </summary>
    /// <remarks>The method interpolates the object's position toward the target's position plus the offset
    /// using linear interpolation.  If the target is not set, an error is logged, and the method exits. The movement
    /// stops when the object is within a  small threshold distance of the target's position.</remarks>
    private void FollowTarget()
    {
        if(_target == null)
        {
            Debug.LogError("Target isn't found!");
            return;
        }

        float distance = ((_target.transform.position + _offset) - gameObject.transform.position).magnitude;
        if (distance <= 0.1f) return;

        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, _target.transform.position + _offset, _distance * Time.deltaTime);
    }

    #endregion

    #region --- Fields ---

    private Transform _target;

    [Header("Tag & Layer")]
    [SerializeField] private string _tag;

    [Header("Custom stats")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _distance;

    #endregion
}
