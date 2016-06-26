using UnityEngine;
using System.Collections;

[System.Serializable]
public class DialogueInfo
{
    public int id;
    public int nextId;
    public int who;
    public string roleImage;
    public string name;
    public string desc;
    public int behaviorType;
    public int behavior;

    public WhoType Who
    {
        get
        {
            return (WhoType)who;
        }
    }
    public BehaviorType BehaviorType
    {
        get
        {
            return (BehaviorType)behaviorType;
        }
    }
}

[System.Serializable]
public class DialogueTable : DataCollection<int, DialogueInfo>
{

}