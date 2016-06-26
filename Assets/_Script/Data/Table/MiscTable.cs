using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    [System.Serializable]
    public class MiscInfo
    {
        public int id;
        public string key;
        public string value;
    }

    [System.Serializable]
    public class MiscTable : DataCollection<int, MiscInfo>
    {
        public Dictionary<string, string> lookUp = new Dictionary<string, string>();

        public void Init()
        {
            lookUp.Clear();
            for (int i = 0; i < elements.Count; i++)
            {
                MiscInfo ele = elements[i];
                lookUp.Add(ele.key, ele.value);
            }
        }

        public string GetPropStr(string key)
        {
            if (lookUp.ContainsKey(key))
            {
                return lookUp[key];
            }
            else
            {
                return null;
            }
        }

        public int GetPropInt(string key)
        {
            return int.Parse(lookUp[key]);
        }

        public float GetPropFloat(string key)
        {
            return float.Parse(lookUp[key]);
        }

        public List<int> GetPropIntList(string key)
        {
            return BattleCompute.ParseString2IntList(lookUp[key]);
        }

        //货币处理
        public EnumMoneyType GetMoneyType()
        {
            return (EnumMoneyType)(int.Parse(GetPropStr("RMB_NT").Split(';')[0]));
        }
        //货币相对于人民币比率
        public float GetMoneyRatio()
        {
            return float.Parse(GetPropStr("RMB_NT").Split(';')[1]);
        }

        //符文价格绿蓝紫
        public int GetRunePrice(int index)
        {
            int result;
            try
            {
                result = int.Parse(GetPropStr("PRICE_RUNE").Split(';')[index]);
            }
            catch (Exception)
            {

                result = (index + 1)*10;
            }
            return result;
        }
    }

    public enum EnumMoneyType
    {
        RMB = 1, //人民币
        US = 2, //美元
        NTD = 3, //新台币
    }

