using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class NewSingleton<T> where T : new()
{
    static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();

                if (instance == null)
                {
                    Debug.LogError("instance" + typeof(T) +     " is null.");
                }
            }

            return instance;
        }
    }

}

public class Singleton<T> : UnityEngine.Object where T : UnityEngine.Object
{
    static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) +
                       " is needed in the scene, but there is none.");
                }
            }

            return instance;
        }
    }

}


public class SingletonBehaviour<T> : UnityEngine.MonoBehaviour where T : UnityEngine.MonoBehaviour
{
    static T instance;
    
    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                /*
                if (instance == null)
                {

                    Debug.LogError("An instance of " + typeof(T) +
                       " is needed in the scene, but there is none.");
                }*/
            }
  
            return instance; 
        }
    }
}

public class SingletonFSM<T1, T2> : SingletonBehaviour<T1> where T1 : UnityEngine.MonoBehaviour 
{
    T2 m_currentState;
    protected float stateStartTime;

    public float stateTime
    {
        get
        {
            return Time.time - stateStartTime;
        }
    }

    public T2 prevState;
    public T2 currentState
    {
        get
        {
            return m_currentState;
        }
        set
        {
            ExitState(m_currentState);
           prevState = m_currentState;
            m_currentState = value;
            stateStartTime = Time.time;
            EnterState(m_currentState);
        }
    }

    protected virtual void EnterState(T2 state)
    {
    }

    protected virtual void ExitState(T2 state)
    {
    }

    protected virtual void UpdateState(T2 state)
    {
    }

    protected virtual void Update()
    {
        UpdateState(m_currentState);
    }
}
