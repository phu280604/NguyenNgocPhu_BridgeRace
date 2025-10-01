using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    #region --- Unity Methods ---

    private void Update()
    {
        FollowTarget();
    }

    #endregion

    #region --- Methods ---

    private void FollowTarget()
    {
        float distance = ((_target.transform.position + _offset) - gameObject.transform.position).magnitude;
        if (distance <= 0.1f) return;

        this.gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, _target.transform.position + _offset, _distance * Time.deltaTime);
    }

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] private Transform _target;

    [Header("Custom stats")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _distance;

    #endregion
}
