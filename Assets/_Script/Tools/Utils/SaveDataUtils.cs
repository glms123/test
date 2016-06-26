using UnityEngine;
using System.Collections;
using Valkyrie;
using System.Text;
using System.Collections.Generic;

public class DataDefine
{
    /// <summary>
    /// 音乐开关本地索引
    /// </summary>
    public const string Music = "Music";
    /// <summary>
    /// 音效开关本地索引
    /// </summary>
    public const string Sound = "Sound";

    public const string GuideEnd = "guideEnd";

    public const string isGuide = "isGuide";

    //UpdateTimeModel 脚本用
    public const string noticeTime = "noticeTime";
    public const string bossLogTime = "bossLogTime";

    public const string ImageQuality = "ImageQuality";

}
/// <summary>
/// 保存数据
/// </summary>
public class SaveDataUtils 
{
    static public void SetBoolUserDefault(string _key, bool _vlaue)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            PlayerPrefs.DeleteKey(_key);
        }
        PlayerPrefs.SetInt(_key, _vlaue ? 1 : 0);
        PlayerPrefs.Save();
    }


    static public void SetIntUserDefault(string _key, int _vlaue)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            PlayerPrefs.DeleteKey(_key);
        }
        PlayerPrefs.SetInt(_key, _vlaue);
        PlayerPrefs.Save();
    }


    static public void SetFloatUserDefault(string _key, float _value)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            PlayerPrefs.DeleteKey(_key);
        }
        PlayerPrefs.SetFloat(_key, _value);
        PlayerPrefs.Save();
    }


    static public void SetStringUserDefault(string _key, string _value)
    {
        if (PlayerPrefs.HasKey(_key))
        {
            PlayerPrefs.DeleteKey(_key);
        }
        PlayerPrefs.SetString(_key, _value);
        PlayerPrefs.Save();
    }




    static public bool GetBoolUserDefault(string _key, bool defVlaue)
    {
        int tmp = defVlaue ? 1 : 0;


        if (PlayerPrefs.GetInt(_key, tmp) == 1)
            return true;


        return false;
    }


    static public int GetIntUserDefault(string _key, int defVlaue)
    {
        return PlayerPrefs.GetInt(_key, defVlaue);
    }


    static public float GetFloatUserDefault(string _key, float defVlaue)
    {
        return PlayerPrefs.GetFloat(_key, defVlaue);
    }


    static public string GetStringUserDefault(string _key, string defVlaue)
    {
        return PlayerPrefs.GetString(_key, defVlaue);
    }

}
