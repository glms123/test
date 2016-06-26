using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class LanguageUtils 
{
	/// <summary>
	/// 读语言包(读的是localizationTable)
	/// </summary>
	/// <param name="wordId">Word identifier.</param>
	public static string UIWord(int wordId)
	{
		LocalizationInfo lan = ResManager.Instance.localizationTable.GetById (wordId);
        if (lan != null && lan.localizedText != null)
		{
			return lan.localizedText.Replace ("\\n", "\n");
		}
		return "";
	}
	/// <summary>
	/// 读语言包(读的是languageTable)
	/// </summary>
	/// <param name="wordId">Word identifier.</param>
    public static string LanguageWord(int wordId)
    {
        //LanguageInfo lan = ResManager.Instance.languageTable.GetById (wordId);
        //if (lan != null && lan.memo != null)
        //{
        //    return lan.memo.Replace ("\\n", "\n");
        //}
        return "";
	}
    /// <summary>
    /// 刷新文字描述中的...
    /// </summary>
    /// <param name="desc"></param>
    /// <param name="dotNum"></param>
    /// <returns></returns>
    public static string UpdateTextDot(string desc,int dotNum)
    {
		for (int i = 0; i < dotNum; i++)
		{
			desc = string.Format ("{0}{1}", desc, ".");
		}
		return desc;
	}

    /// <summary>
    /// 合成文字
    /// </summary>
    /// <param name="_num"></param>
    /// <param name="_prefix"></param>
    /// <returns></returns>
    public static string ConvertNumber(string _num, string _prefix)
    {
        char[] numberChar = _num.ToCharArray();
        string str = "";
        for (int i = 0; i < numberChar.Length; i++)
        {
            str += _prefix;
            str += (numberChar[i]);
        }

        return str.ToString();
    }

    /// <summary>
    /// 返回等级
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int GetLevel(int level)
    {
        level = level > CommonDefine.MaxLevelLimit ? CommonDefine.MaxLevelLimit : level;
        return level;
    }
    /// <summary>
    /// 返回等级字符串
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static string GetLevelString(int level)
    {
        return GetLevel(level).ToString();
    }

    static Dictionary<int,string> staticLangDic = null;




}
