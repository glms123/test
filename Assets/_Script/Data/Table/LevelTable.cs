using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class LevelInfo
{
    public int id;
    public int indexId;
    public int nameId;
    public string prevLevelId;
    public int copyId;
    public int openLv;
    public int battleId;
    public int playMode;
    public int levelMode;
    public int sceneMode;
    public string nameForProgram;
    public string bornPosition;
    public float cameraRotSide;
    public float cameraRotUp;
    public float rotDistance;
    public string music;
    public int numPerDay;
    public int exhaustion;
    public int levelTime;
    public int hitNumber;
    public int displayRecommendId;
    public int sceneId;
    //public string displayEnemeyType;
    //public string displayEnemeyIds;
    //public string displayAwardType;
    public string displayAwardIds;
    public string displayAwardNum;
    public int recommendPower;
    public int descId;
    public string enemyArray;
    public string enemyRanks;
    public string enemyStars;
    public string enemyLevels;
    public string enemyIsBoss;
    public string teamMaxBossHp;
    public string destructibleIds;
    public string destructiblePosition;
    public string destructibleRotation;
    public string levelTarget;
    public int TitleID;
}

[System.Serializable]
public class LevelTable : DataCollection<int, LevelInfo>
{
}