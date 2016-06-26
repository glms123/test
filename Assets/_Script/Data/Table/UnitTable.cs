using UnityEngine;
using System.Collections;


[System.Serializable]
public class UnitInfo
{
    public int id;
    public string unitName;
    public string modelPath;
    public int unitType;
    public float baseHp;
    public int baseAtk;
    public int atkType;
    public int atkRangeMin;
    public int atkRangeMax;
    public int atkAmount;
    public int atkTarget;
    public float atkPeriod;
    public float speed;
    public int moveType;
    public int duration;
    public int abilityId;

}

[System.Serializable]
public class UnitTable : DataCollection<int, UnitInfo>
{

}