using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An abstact handler class for Character.
/// </summary>
/// <typeparam name="T">is a State datatype.</typeparam>
/// <typeparam name="U">is a StatsSO datatype.</typeparam>
public abstract class CharacterActionH<TState, TStats> : MonoBehaviour
{
    #region --- Methods ---

    /// <summary>
    /// Handle move for Character.
    /// </summary>
    /// <param name="objTrans">reference to Character's transform.</param>
    /// <param name="time">is a time in Update function.</param>
    public abstract void MoveH(ref Transform objTrans, float time);

    #endregion

    #region --- Fields ---

    [SerializeField] protected TState _state;
    [SerializeField] protected TStats _statsSO;

    #endregion
}
