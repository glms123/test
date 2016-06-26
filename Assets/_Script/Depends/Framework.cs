using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Valkyrie;


public class Framework : MonoBehaviour
{
    static GameObject rootObject_;
    static Framework instance_ = null;

    public static bool HasInstance
    {
        get { return instance_ != null; }
    }

    public static Framework Instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = new GameObject("GameRoot").AddComponent<Framework>();
            }

            return instance_;
        }
    }

    static Dictionary<string, List<System.Action<object>>> eventRegistry_ = new Dictionary<string, List<System.Action<object>>>();

    public static void RegisterEvent(string eventName, System.Action<object> eventHandle)
    {
        List<System.Action<object> >evt;
        if (eventRegistry_.TryGetValue(eventName, out evt))
        {
            evt.Add(eventHandle);
        }
        else
        {
            evt = new List<System.Action<object>>();
            evt.Add(eventHandle);
            eventRegistry_[eventName] = evt;
        }
    }

    public static void UnregisterEvent(string eventName, System.Action<object> eventHandle)
    {
        List<System.Action<object>> evtList;
        if (eventRegistry_.TryGetValue(eventName, out evtList))
        {
            evtList.Remove(eventHandle);
        }
    }
    /// <summary>
    /// ÑÓ³Ù·¢ËÍÏûÏ¢
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="time"></param>
    /// <param name="param"></param>
    public void SendEventDelay(string eventName, float time, object param = null)
    {

        StartCoroutine(SendEventDelayHelper(eventName, time, param));
    }

    public IEnumerator SendEventDelayHelper(string eventName, float time, object param = null)
    {
        yield return new WaitForSeconds(time);
        SendEvent(eventName, param);
    }
    public static void SendEvent(string eventName, object param = null)
    {
        List<System.Action<object>> evtList;
        if (eventRegistry_.TryGetValue(eventName, out evtList))
        {
            for (int i = 0; i < evtList.Count; i++ )
            {
                evtList[i](param);
            }
               

        }
    }

    public static T AddComponent<T>() where T : Component
    {
        return rootObject_.AddComponent<T>();
    }

    public static T Get<T>() where T : MonoBehaviour
    {
        if (rootObject_ != null)
            return rootObject_.GetComponent<T>();
        else
            return null;
    }

    private int scaleWidth = 0;
    private int scaleHeight = 0;
    public void setDesignContentScale()
    {
#if UNITY_ANDROID
        if (scaleWidth == 0 && scaleHeight == 0)
        {
            int width = Screen.currentResolution.width;
            int height = Screen.currentResolution.height;
            int designWidth = 1280;
            int designHeight = 720;
            float s1 = (float)designWidth / (float)designHeight;
            float s2 = (float)width / (float)height;
            if (s1 < s2)
            {
                designWidth = (int)Mathf.FloorToInt(designHeight * s2);
            }
            else if (s1 > s2)
            {
                designHeight = (int)Mathf.FloorToInt(designWidth / s2);
            }
            float contentScale = (float)designWidth / (float)width;
            if (contentScale < 1.0f)
            {
                scaleWidth = designWidth;
                scaleHeight = designHeight;
            }
        }
        if (scaleWidth > 0 && scaleHeight > 0)
        {
            if (scaleWidth % 2 == 0)
            {
                scaleWidth += 1;
            }
            else
            {
                scaleWidth -= 1;
            }
            Screen.SetResolution(scaleWidth, scaleHeight, true);
        }
#endif
    }

    void OnApplicationPause(bool paused)
    {
#if UNITY_ANDROID
        if (paused)
        {
        }
        else
        {
            setDesignContentScale();
        }
#endif
    }

    void Awake()
    {

        instance_ = this;
        rootObject_ = gameObject;
        DontDestroyOnLoad(rootObject_);
         ConfigComponents();
#if UNITY_ANDROID
         setDesignContentScale();
#endif

#if UNITY_ANDROID || UNITY_IPHONE
        Application.targetFrameRate = 30;
#endif
         Application.targetFrameRate = 30;

         //Screen.orientation = ScreenOrientation.AutoRotation;
         //Screen.autorotateToLandscapeLeft = true;
         //Screen.autorotateToLandscapeRight = true;
         //Screen.autorotateToPortrait = false;
         Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    protected virtual void ConfigComponents()
    {
    }
    
    // Use this for initialization
    protected virtual void Start()
    {
//         Debug.Log("Framework Start!");
// 
//         blackBoard = new Blackboard();
//         battleBoard = new BattleBoard();
    }

    // Update is called once per frame


}
