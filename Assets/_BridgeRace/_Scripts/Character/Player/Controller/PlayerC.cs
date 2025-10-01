using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : CharacterC<PStateM, CharStatsSO>
{
    #region --- Unity Methods ---

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetDirection();
        Move();
    }

    #endregion

    #region --- Methods ---

    private void GetDirection()
    {
        Vector2 dir = _control.GetInput();
        state.Direction = dir != Vector2.zero ? new Vector3(dir.x, 0, dir.y) : Vector3.zero;
    }

    private void Move()
    {
        gameObject.transform.Translate(state.Direction * stats.speed * Time.fixedDeltaTime, Space.World);
    }

    #endregion

    #region --- Fields ---

    [Header("Handler")]
    [SerializeField] private InputH _control;

    #endregion
}
