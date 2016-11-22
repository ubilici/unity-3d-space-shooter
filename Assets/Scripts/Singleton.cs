using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get
        {
            _instance = FindObjectOfType<T>();

            if(_instance == null)
            {
                Debug.LogError("Can't find " + typeof(T) + "!");
            }

            return _instance;
        }
    }
}
