using UnityEngine;
using System.Collections;

[System.Serializable]
public class CopyInfo
{
    public int id;
    public int nameId;
    public int levelNumber;
    public int openLv;
    public int preCopyId;
    public int nextCopyId;
    public int lastLevelId;
    public string titleAtlasPath;
    public string titleIconName;
    //public string chapterName;
    public int chapterNameId;
    public string mapPathName;
    public string levelIds;
    public string levelPosition;
    public string altasPathName;
    public string levelIconName;
    public int copyType;
    public string week;
    public int mapIndex;
}

[System.Serializable]
public class CopyTable : DataCollection<int, CopyInfo>
{

}