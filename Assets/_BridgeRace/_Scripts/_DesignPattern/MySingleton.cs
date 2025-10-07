using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region --- Properties ---

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindAnyObjectByType<T>();

                if(instance == null)
                {
                    instance = new GameObject(nameof(T)).AddComponent<T>();
                }
            }

            return instance;
        }
    }

    #endregion

    #region --- Fields ---

    private static T instance;

    #endregion
}
