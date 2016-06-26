using UnityEngine;
using System.Collections;


public class ShowFps : MonoBehaviour {

    public float updateInterval = 0.5f;//更新间隔时间
    double lastInterval;//最后更新间隔
    int frames = 0;//帧
    float currFPS;//当前fps
	void Start () {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
	}
	

	void Update () {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow>lastInterval+updateInterval)
        {
            currFPS = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
#if UNITY_EDITOR
    void OnGUI()
    {
        if (currFPS>60)
        {
            currFPS = 60;
            GUILayout.Label("FPS:" + currFPS.ToString("f2"));
        }
        else { GUILayout.Label("FPS:" + currFPS.ToString("f2")); }
    }
#endif
}
