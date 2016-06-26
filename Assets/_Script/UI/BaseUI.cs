using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour
{
    /// <summary>
    /// 窗口类型
    /// </summary>
    public WindowType WinType;
    
    void Awake()
    {

    }
        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    protected virtual void  OnBack(GameObject btn)
    {
        WindowManager.ManageWinwodClose(gameObject);
    }
}
