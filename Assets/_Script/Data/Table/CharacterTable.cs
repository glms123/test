using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum CharacterType
{
    Player = 0,
    Monster = 1,
    Boss = 2,
    Hero,
    Npc
}


[System.Serializable]
public class CharacterData
{
    public int id;
    public int attackStep;
    public int avatarType;
    public List<string> animator;


    public string defaultModelPath;
    public string weaponBindPoints;
    public string shadowPath;
    public float shadowSize;
    public float rigidBodyMass;
    public float rigidBodyDrag;
    public bool useGravity;
    public bool isKanematic;
    public float height;
    public float H;
    public float radius;
    public float damping;
    public float rigidBodyAngularDrag;
    public bool beBlowUp;
    public bool beKnockDown;
    public bool bePushBack;
    public bool beCatch;
    public bool overWhilming;
    public int soundMaterial;
    public float moveSpeed;
    public float rollSpeed;
    public float rotateSpeed;
    public bool hasSpawnAnim;
    public int spawnFX;
    public int deadType;
    public string deadModel;
    public float scale;
    public int chainSoundId;
    public int enterId;
    public int outSceneSoundId;
    public int wingId;
    public string sfxIds;
    public float embattleScale;
}

[System.Serializable]
public class CharacterTable : DataCollection<int, CharacterData>
{
}