using UnityEngine;
using System.Collections;

public enum CardTQualityType
{
    General = 1, //普通
    Rare = 2, //
    Epic = 3
}
public enum CardType
{
    Army = 1,  //军队
    Build = 2,  //建筑
    Magic = 3 //魔法
}

[System.Serializable]
public class CardInfo
{
    public int id;
    public int cardQualityType;
    public int cost;
    public string roleImage;
    public int cardType;
    public string iconPath;
    public string iconName;
    public int unitID;
    public int unitAmount;
    public int setupTime;


    public CardTQualityType CardQuality
    {
        get
        {
            return (CardTQualityType)cardQualityType;
        }
    }
    public CardType CardType
    {
        get
        {
            return (CardType)cardType;
        }
    }
}

[System.Serializable]
public class CardTable : DataCollection<int, CardInfo>
{

}