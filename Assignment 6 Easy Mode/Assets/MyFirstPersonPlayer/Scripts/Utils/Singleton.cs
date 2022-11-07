/*
 * CIS 350 
 * Simfara Ranjit
 * Assignment6
 * Script that consits Singelton generic template
 */
using System.Collections;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsInitilaized
    {
        get { return instance != null; }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a" +
                "second instance of a singleton class");
        }
        else
        {
            instance = (T)this;
        }
    }


protected virtual void onDestroy()
    {
        //if this object is destroyed , make instance null so another can be created
        if(instance == this)
        {
            instance = null;
        }
    }
}
