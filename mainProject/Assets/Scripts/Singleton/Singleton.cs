using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonRoot : Singleton<SingletonRoot>
{
    
}

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    private static T _instance;
    private static readonly object _lock = new object();
    
    protected static bool applicationIsQuitting = false;
    
    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
                return null;
            
            if ( _instance == null )
            {
                lock (_lock)
                {
                    _instance = FindObjectOfType<T> ();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        return _instance;
                    }

                    if ( _instance == null )
                    {
                        GameObject obj = new GameObject (typeof ( T ).Name);
                        _instance = obj.AddComponent<T> ();
                        DontDestroyOnLoad(obj);
                        obj.transform.SetParent(SingletonRoot.Instance.transform);
                    }
                }
            }
            return _instance;
        }
    }

    public void OnDestroy()
    {
        _instance = null;
        applicationIsQuitting = true;
    }
}