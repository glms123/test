using UnityEngine;
using System.Collections;

public enum UnitType
{
    Crystal = 0, //剑士 0中枢水晶,1 防御塔,2召唤单位,3召唤建筑,4工程单位,5传奇单位
    GuardTower = 1,     //防御塔
    SummonUnit = 2, //2召唤单位
    SummonBuild = 3, //3召唤建筑
    ProjectUnit = 4, //4工程单位
    TaleUnit = 5, //5传奇单位
}
public enum UnitState
{
    Birth,  //出生
    Normal,  //正常
    Die    //死亡
}

public class BaseUnit : OriginalStateMachine<UnitState>
{
    float m_nHP;
    public float HP
    {
        get
        {
            return m_nHP;
        }
        set
        {
            m_nHP = value;
            SetXueTiao();
        }
    }
    float m_nMaxHP;
    public float MaxHP
    {
        get
        {
            return m_nMaxHP;
        }
        set
        {
            m_nMaxHP = value;
        }
    }
    float m_nMoveSpeed;
    public float MoveSpeed
    {
        get
        {
            return m_nMoveSpeed;
        }
        set
        {
            m_nMoveSpeed = value;
        }
    }
    public Camp m_Camp;
    public Camp m_EnemyCamp; //敌人阵营
    public UnitInfo m_UnitInfo;

    GameObject m_go_xuetiao;

    public bool isDied
    {
        get { return HP <= 0; }
    }
    void Awake()
    {
        m_go_xuetiao = gameObject.FindChild("xuetiao");
    }
        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public virtual void Init(UnitInfo info, Camp camp)
    {
        m_UnitInfo = info;
        m_Camp = camp;
        switch (camp)
        {
            case Camp.PlayerOne:
                m_EnemyCamp = Camp.PlayerTwo;
                break;
            case Camp.PlayerTwo:
                m_EnemyCamp = Camp.PlayerOne;
                break;
        }

        MaxHP = info.baseHp;
        HP = MaxHP;

        currentState = UnitState.Birth;

    }
    void SetXueTiao()
    {
        if (m_go_xuetiao != null)
        {
            m_go_xuetiao.transform.localScale = new Vector2(HP / MaxHP,1f);
        }
    }

    protected override void EnterState(UnitState state)
    {
        switch (state)
        {
            case UnitState.Birth:
                StartCoroutine(ComponentTools.SetWaitTime(1f, () => { currentState = UnitState.Normal; }));
                break;
            case UnitState.Normal:
                break;
            case UnitState.Die:
                break;
            default:
                break;
        }
    }
    protected override void ExitState(UnitState state)
    {
        switch (state)
        {
            case UnitState.Birth:
                break;
            case UnitState.Normal:
                break;
            case UnitState.Die:
                break;
            default:
                break;
        }
    }
}
