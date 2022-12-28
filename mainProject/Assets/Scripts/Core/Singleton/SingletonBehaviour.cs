using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviourRoot : SingletonBehaviour<SingletonBehaviourRoot>
{
    
}

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;
    private static readonly object _lock = new object();

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
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
                        obj.transform.SetParent(SingletonBehaviourRoot.Instance.transform);
                    }
                }
            }
            return _instance;
        }
    }

    public virtual void Initialize() { }
    
    public virtual void Release()
    {
        GameDebug.Log("[Release] " + gameObject.name);
    }
}

public abstract class Singleton<T> where T : new()
{
    protected static T _instance;
    private static readonly object _lock;

    static Singleton()
    {
        _lock = new object();
    }

    protected Singleton() { }

    public static T Instance
    {
        get
        {
            // Double-Checked Locking
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = default(T) == null ? Activator.CreateInstance<T>() : default;
                    }
                }
            }

            return _instance;
        }
    }

    public virtual void Initialize() { }
    public virtual void Release() { }
}