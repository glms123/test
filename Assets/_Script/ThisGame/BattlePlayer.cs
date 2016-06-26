using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Camp
{
    PlayerOne = 0,
    PlayerTwo = 1,
    PlayerThree = 2,
}

public class BattlePlayer : MonoBehaviour {
    /// <summary>
    /// 魔法槽相关
    /// </summary>
    public const float MagicMaxNum = 10;
    public float m_fMagic = 0f;
    public float m_fMagicGrow = 1f / (3f*Application.targetFrameRate);
    public float m_fMagicPercent { get { return m_fMagic/ MagicMaxNum; } }
    /// <summary>
    /// 是否自动操作 AI
    /// </summary>
    public bool m_bAuto = false;
    /// <summary>
    /// 玩家所属阵营
    /// </summary>
    public Camp m_Camp;

    public Deck m_Deck;

    public List<GameObject> m_unitList = new List<GameObject>();

    void Awake()
    {
        Framework.RegisterEvent(ThisGameEvent.CreateUnit, EventCreateUnit);
    }
    void OnDestroy()
    {
        Framework.UnregisterEvent(ThisGameEvent.CreateUnit, EventCreateUnit);
    }
        // Use this for initialization
        void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_fMagic < MagicMaxNum)
        {
            m_fMagic += m_fMagicGrow;
        }
        else
        {
            m_fMagic = MagicMaxNum;
        }
    }
    void EventCreateUnit(object obj)
    {
        GenerateUnitInfo info = obj as GenerateUnitInfo;
        if (info == null) return;

        if (info.camp == m_Camp)
        {
            UnitInfo unitInfo =  ResManager.Instance.unitTable.GetById(info.unitId);
            ResManager.Instance.LoadObject<GameObject>(unitInfo.modelPath, true, (go) => {
                go.transform.position = info.pos;

                BaseUnit bu = ComponentTools.AddComponent<BaseUnit>(go);
                bu.Init(unitInfo, m_Camp);
                if (unitInfo.unitType != (int)UnitType.Crystal && unitInfo.unitType != (int)UnitType.GuardTower)
                {
                    ComponentTools.AddComponent<UnitPathFollower>(go);
                }

                m_unitList.Add(go);
            });
        }
    }
}
