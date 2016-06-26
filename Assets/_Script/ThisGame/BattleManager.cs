using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    Prepare, //准备阶段
    Begin,
    Playing,
    Overtime,
    Victory,
    Failure
}
public class GenerateUnitInfo
{
    public int unitId;
    public Camp camp;
    public Vector3 pos;

    public GenerateUnitInfo(int unitId, Camp camp, Vector3 pos)
    {
        this.unitId = unitId;
        this.camp = camp;
        this.pos = pos;
    }
}

public class BattleManager : SingletonBehaviour<BattleManager>
{
    public GameState m_GameState;
    public GameState Game_State
    {
        get
        {
            return m_GameState;
        }
        set
        {
            ExitState(m_GameState);
            m_GameState = value;
            EnterState(m_GameState);

        }
    }
    public const int MaxNum = 2;
    public List<BattlePlayer> m_BattlePlayerList = new List<BattlePlayer>();
    void Awake()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("wall"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("walk"));

        Framework.RegisterEvent(ThisGameEvent.GetBattlePlayer, EventGetBattlePlayer);
        BattlePlayer bp = null;
        for (int i = 0; i < MaxNum; i++)
        {
            bp = gameObject.AddComponent<BattlePlayer>();
            bp.m_Camp = (Camp)i;

            m_BattlePlayerList.Add(bp);
        }
    }
    void OnDestroy()
    {
        Framework.UnregisterEvent(ThisGameEvent.GetBattlePlayer, EventGetBattlePlayer);
    }
    // Use this for initialization
    void Start ()
    {
        Game_State = GameState.Prepare;
        InitBattlePlayerList();

        Application.LoadLevelAdditiveAsync("battle");
        //ResManager.Instance.LoadObject<GameObject>("Prefabs/Scene/BattleGround", true, (obj) => { });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void EventGetBattlePlayer(object obj)
    {
        int index = (int)obj;
        BattlePlayer bp = null;
        for (int i = 0; i < m_BattlePlayerList.Count; i++)
        {
            if (i == index)
            {
                bp = m_BattlePlayerList[i];
                break;
            }
        }
        Framework.SendEvent(ThisGameEvent.SetBattlePlayer, bp);
    }
    void InitBattlePlayerList()
    {
        BattlePlayer bp = null;
        for (int i = 0; i < m_BattlePlayerList.Count; i++)
        {
            bp = m_BattlePlayerList[i];
            bp.m_Camp = (Camp)i;
            bp.m_fMagic = 0f;

            PlayerModel pm = new PlayerModel();
            bp.m_Deck = pm.GetDeck;

        }
    }

    void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.Prepare:
                StartCoroutine(ComponentTools.SetWaitTime(1f, () => { Game_State = GameState.Begin; }));
                break;
            case GameState.Begin:
                GameObject go = GameObject.Find("jidiposwofang");
                Framework.SendEvent(ThisGameEvent.CreateUnit, new GenerateUnitInfo(5,Camp.PlayerOne, go.transform.position));

                go = GameObject.Find("birthpos1");
                Framework.SendEvent(ThisGameEvent.CreateUnit, new GenerateUnitInfo(1, Camp.PlayerOne, go.transform.position));
                //
                go = GameObject.Find("jidiposdifang");
                Framework.SendEvent(ThisGameEvent.CreateUnit, new GenerateUnitInfo(6, Camp.PlayerTwo, go.transform.position));

                go = GameObject.Find("birthpos2");
                Framework.SendEvent(ThisGameEvent.CreateUnit, new GenerateUnitInfo(1, Camp.PlayerTwo, go.transform.position));

                m_GameState = GameState.Playing;
                break;
        }
    }
    void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.Prepare:
                break;
        }
    }

    public GameObject GetPathingTarget(Camp camp,UnitInfo info)
    {
        GameObject go = null;
        BattlePlayer bp = null;
        for (int i = 0; i < m_BattlePlayerList.Count; i++)
        {
            if (m_BattlePlayerList[i].m_Camp == camp)
            {
                bp = m_BattlePlayerList[i];
                break;
            }
        }
        if (bp != null)
        {
            for (int i = 0; i < bp.m_unitList.Count; i++)
            {
                BaseUnit bu = bp.m_unitList[i].GetComponent<BaseUnit>();
                if ((UnitType)bu.m_UnitInfo.unitType == UnitType.Crystal)
                {
                    go = bp.m_unitList[i];
                    break;
                }
                
            }
        }

        return go;
    }
}
