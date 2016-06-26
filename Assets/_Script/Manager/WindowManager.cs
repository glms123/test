using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILayer : int
{
    Default = 0,  //默认自动累加
    Max = 25,     //最大层
}

public enum WindowType : int
{
    None = 0,
    Full, //全屏
    Popup,//弹出
    Other,
}
public enum WindowAction : int
{
    None = 0,   //没有
    Open_UICombatReadiness = 1,  //打开站前准备
    Open_UIBattle,  //打开战斗
}

public class WindowActionParameter
{
    public WindowAction type;
    public GameObject go;       //需要传出去的窗口对象
    public object param;      //根据界面不同传入不同参数

    public WindowActionParameter(WindowAction type, object param = null, GameObject go = null)
    {
        this.type = type;
        this.go = go;
        this.param = param;
    }
}
public class WindowManager : NewSingleton<WindowManager>
{
    public const int UIDepthFactor = 30;
    public static GameObject m_go_UIRoot;
    public static List<GameObject> m_WindowList = new List<GameObject>();

    public WindowManager()
    {

    }
    ~WindowManager()
    {

    }

    static T OpenWindow<T>(string uiPath, WindowType type, UILayer layer = UILayer.Default) where T : BaseUI
    {
        if (m_go_UIRoot == null)
        {
            m_go_UIRoot = GameObject.FindGameObjectWithTag("UIRoot");
        }

        T com = null;
        ResManager.Instance.LoadObject<GameObject>(uiPath, true, (obj) => {

            obj.SetActive(true);
            obj.transform.SetParent(m_go_UIRoot.transform);
            obj.transform.localScale = Vector3.one;
            obj.transform.localPosition = Vector3.zero;

            m_WindowList.Add(obj);
            com = ComponentTools.AddComponent<T>(obj);
            com.WinType = type;

            int nLayer = (int)layer;
            if (layer == UILayer.Default)
            {
                nLayer = CurUILayer;
            }
          
            UIPanel[] panels =  obj.GetComponentsInChildren<UIPanel>();
            if (panels != null)
            {
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].depth += nLayer * UIDepthFactor;
                }
            }

        });
        return com;
    }
    static void CloseWindow(GameObject go,float fTime = 0f)
    {
        if (m_WindowList.Contains(go))
        {
            m_WindowList.Remove(go);
        }
        UnityEngine.Object.Destroy(go, fTime);
    }
    public static void ClearWindow()
    {
        m_WindowList.Clear();
    }
    /// <summary>
    /// 获得当前UI层
    /// </summary>
    static int CurUILayer
    {
        get
        {
            int count = 0;
            for (int i = 0; i < m_WindowList.Count; i++)
            {
                BaseUI baseui = m_WindowList[i].GetComponent<BaseUI>();
                if (baseui != null && (baseui.WinType == WindowType.Full || baseui.WinType == WindowType.Popup))
                {
                    count++;
                }
            }
            return count;
        }
    }
    /// <summary>
    /// 打开界面对外接口
    /// </summary>
    /// <param name="type"></param>
    /// <param name="param"></param>
    /// <param name="go"></param>
    public static void ManageWinwodOpen(WindowAction type, object param = null, GameObject go = null)
    {
        WindowActionParameter para = new WindowActionParameter(type, param, go);
        switch (para.type)
        {
            case WindowAction.Open_UICombatReadiness:
                OpenWindow<UICombatReadiness>(UIFilePath.UICombatReadiness, WindowType.Full);
                break;
            case WindowAction.Open_UIBattle:
                UIBattle ub = OpenWindow<UIBattle>(UIFilePath.UIBattle, WindowType.Full);
                para.go = ub.gameObject;
                break; ;
        }
    }
    /// <summary>
    /// 关闭界面对外接口
    /// </summary>
    /// <param name="go"></param>
    /// <param name="fTime"></param>
    public static void ManageWinwodClose(GameObject go, float fTime = 0f)
    {
        CloseWindow(go, fTime);
    }
}

