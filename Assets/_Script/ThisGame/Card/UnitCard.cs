using UnityEngine;
using System.Collections;

public class UnitCard : MonoBehaviour {
    public Card m_Card;
    public bool m_bIsInit = false;

    UILabel m_lbl_cost;
    UITexture m_tex_head;
    UISprite m_spr_tag;
    void Awake()
    {
        m_lbl_cost = ComponentTools.FindComponent<UILabel>(gameObject, "cost");
        m_tex_head = ComponentTools.FindComponent<UITexture>(gameObject, "head");
        m_spr_tag = ComponentTools.FindComponent<UISprite>(gameObject, "tag");
    }
        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init(Card card)
    {
        m_Card = card;

        m_lbl_cost.text = card.cardInfo.cost.ToString();
        ComponentTools.SetTextuer(m_tex_head, card.cardInfo.roleImage);
        ComponentTools.SetUISprite(m_spr_tag, card.cardInfo.iconPath, card.cardInfo.iconName);
    }
}
