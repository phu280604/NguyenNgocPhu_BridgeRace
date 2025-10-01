using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent Character
/// </summary>
/// <typeparam name="T">DataType is State</typeparam>
/// <typeparam name="U">DataType is Stats</typeparam>
public class CharacterC<T, U> : MonoBehaviour
{
    #region --- Methods ---



    #endregion

    #region --- Properties ---

    public T State => state;
    public U Stats => stats;

    #endregion

    #region --- Fields ---

    [Header("Unity components")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider capCol;

    [Header("Character components")]
    [SerializeField] protected T state;
    [SerializeField] protected U stats;

    #endregion
}
