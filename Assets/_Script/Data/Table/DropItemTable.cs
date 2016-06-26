using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class DropItemInfo
{
    public int id;  /// 流水ID
    public int dropItemId;       /// 掉落物品库ID
    public int itemType;         /// 模型ID
    public DropType dropType;    
    public string itemId;        /// 几何路径
    public int weight;
    public int mf;
    public float earnings;
}
    
public enum DropType
{
    None,
    Soul,//吸魂
    Cash,//钱
    Blood,//血球
    SkillStone,//技能石
    Equip,//装备
    Ring,//首饰
    Weapon,//武器
    AddHealth,//回血
    AddDps,//增加攻击力
    AddFangyu//增加防御
}

[System.Serializable]
public class DropItemTable : DataCollection<int, DropItemInfo>
{
}
