using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WhoType
{
    Left = 1,  //左边说
    Ritht = 2
}
public enum BehaviorType
{
    Say = 1,  //说话
    OpenWindow = 2, //打开界面
}

public class UIDialogue : BaseUI
{
    DialogueInfo m_info;
    List<DialogueInfo> m_DialogueInfoLsit;
    UITexture m_tex_leftRole, m_tex_rightRole;
    UILabel m_lbl_name, m_lbl_dialogue;
    void Awake()
    {
        AudioManager.Instance.PlayBGM((int)BGMType.BGM01);

        m_tex_leftRole = ComponentTools.FindComponent<UITexture>(gameObject, "leftRole");
        m_tex_rightRole = ComponentTools.FindComponent<UITexture>(gameObject, "rightRole");
        m_lbl_name = ComponentTools.FindComponent<UILabel>(gameObject, "name");
        m_lbl_dialogue = ComponentTools.FindComponent<UILabel>(gameObject, "dialogue");

        ComponentTools.SetUIEventListener(gameObject, "mask", OnNext);
    }
    // Use this for initialization
    void Start ()
    {
        m_info = ResManager.Instance.dialogueTable.GetById(1);
        UpdateUI(m_info);

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void UpdateUI(DialogueInfo info)
    {
        UITexture tex = null;
        UITexture texTwo = null;
        switch (info.Who)
        {
            case WhoType.Left:
                tex = m_tex_leftRole;
                texTwo = m_tex_rightRole;
                break;
            case WhoType.Ritht:
                tex = m_tex_rightRole;
                texTwo = m_tex_leftRole;
                break;
            default:
                break;
        }
        tex.color = Color.white;
        tex.mainTexture = Resources.Load<Texture2D>(info.roleImage);
        tex.MakePixelPerfect();

        texTwo.color = Color.gray;

        m_lbl_name.text = info.name;
        m_lbl_dialogue.text = info.desc;
    }

    void OnNext(GameObject btn)
    { 
        if (m_info == null) return;

        switch (m_info.BehaviorType)
        {
            case BehaviorType.Say:
                m_info = ResManager.Instance.dialogueTable.GetById(m_info.nextId);
                if (m_info != null)
                {
                    UpdateUI(m_info);
                }
                break;
            case BehaviorType.OpenWindow:
                WindowManager.ManageWinwodOpen(WindowAction.Open_UICombatReadiness);
                WindowManager.ManageWinwodClose(gameObject);
                break;
            default:
                break;
        }
    }
    
}
