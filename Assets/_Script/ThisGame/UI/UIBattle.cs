using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIBattle : BaseUI
{
    public BattlePlayer m_BattlePlayer;
    List<UnitCard> m_UnitCardList = new List<UnitCard>();
    UIGrid m_grid_card;
    UISlider m_sli_MagicBar;
    void Awake()
    {
        Framework.RegisterEvent(ThisGameEvent.SetBattlePlayer, EventSetBattlePlayer);

        AudioManager.Instance.PlayBGM((int)BGMType.BGM03);
        m_grid_card = ComponentTools.FindComponent<UIGrid>(gameObject, "cardGrid");
        m_sli_MagicBar = ComponentTools.FindComponent<UISlider>(gameObject, "MagicBar");
    }
    void OnDestroy()
    {
        Framework.UnregisterEvent(ThisGameEvent.SetBattlePlayer, EventSetBattlePlayer);
    }
    // Use this for initialization
    void Start ()
    {
        GameObject go = null;
        UnitCard uc = null;
      for (int i=0;i<4;i++)
      {
            go = ComponentTools.LoadUIObject(UIPartFilePath.UnitCard, m_grid_card.transform);
            uc = ComponentTools.AddComponent<UnitCard>(go);
            m_UnitCardList.Add(uc);
            m_grid_card.repositionNow = true;
      }

        Framework.SendEvent(ThisGameEvent.HideUI);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_BattlePlayer == null)
        {
            Framework.SendEvent(ThisGameEvent.GetBattlePlayer, 0);
        }
        else
        {
            m_sli_MagicBar.value = m_BattlePlayer.m_fMagicPercent;
            for (int i=0;i< m_UnitCardList.Count;i++)
            {
                UnitCard uc = m_UnitCardList[i];
                if (uc.m_Card == null)
                {
                    uc.Init(m_BattlePlayer.m_Deck.cards[i]);
                }
            }
        }
        

    }


    void EventSetBattlePlayer(object obj)
    {
        m_BattlePlayer = (BattlePlayer)obj;
    }
    void OnBattle(GameObject btn)
    {
        base.OnBack(btn);

    }
    
}
