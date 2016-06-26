using UnityEngine;
using System.Collections;

public class ComponentTools 
{
    /// <summary>
    /// 查找组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public static T FindComponent<T>(GameObject parent, string path = "") where T:Component
    {
        T com = null;
        if (parent != null)
        {
            if (string.IsNullOrEmpty(path))
            {
                com = parent.GetComponent<T>();
            }
            else
            {
                parent = parent.FindChild(path);
                if (parent != null)
                {
                    com = parent.GetComponent<T>();
                }
            }
        }
        return com;
    }
    /// <summary>
    /// 添加脚本 唯一
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static T AddComponent<T>(GameObject parent) where T : Component
    {
        T com = null;
        if (parent != null)
        {
            com = parent.GetComponent<T>();
            if (com == null)
            {
                com = parent.AddComponent<T>();
            }
        }
        return com;
    }

    public static GameObject SetUIEventListener(GameObject parent, string path, UIEventListener.VoidDelegate onClick)
    {
        GameObject go = null;
        if (parent != null)
        {
            go = parent.FindChild(path);
            if (go == null)
            {
                go = parent;
            }
            UIEventListener.Get(go).onClick = onClick;
        }
        return go;
    }

    public static GameObject LoadUIObject(string fileName, bool resourcesLoad= true, bool instantiate = true) 
    {
        GameObject go = null;
        ResManager.Instance.LoadObject<GameObject>(fileName, resourcesLoad, (obj)=> {

            go = obj;
        }, instantiate);

        return go;
    }
    public static GameObject LoadUIObject(string fileName,Transform Parent)
    {
        GameObject go = null;
        go = LoadUIObject(fileName);
        go.transform.SetParent(Parent);
        go.transform.localPosition = UnityEngine.Vector3.zero;
        go.transform.localScale = UnityEngine.Vector3.one;

        return go;
    }
    public static void SetTextuer(GameObject go, string fileName)
    {
        SetTextuer(go.GetComponent<UITexture>(), fileName);
    }
    public static void SetTextuer(UITexture tex, string fileName)
    {
        if (tex == null) return;

        ResManager.Instance.LoadObject<Texture2D>(fileName, true, (obj) => {
            tex.mainTexture = obj;
        },false);
    }

    public static void SetUISprite(GameObject go, string fileName, string spriteName )
    {
        SetUISprite(go.GetComponent<UISprite>(), fileName, spriteName);
    }
    public static void SetUISprite(UISprite spr, string fileName, string spriteName)
    {
        if (spr == null) return;

        ResManager.Instance.LoadObject<UIAtlas>(fileName, true, (obj) =>
        {
            if (obj != null)
            {
                spr.atlas = obj ;
                spr.spriteName = spriteName;
            }
        }, false);
    }
    public static IEnumerator SetWaitTime(float fTime, System.Action action)
    {
        yield return new WaitForSeconds(fTime);
        action();
    }

    }
