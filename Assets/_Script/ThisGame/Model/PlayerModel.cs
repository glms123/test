using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerModel  {

    public const int MaxNum = 1;
    public List<Deck> decks = new List<Deck>();
    /// <summary>
    /// 当前使用卡组索引
    /// </summary>
    public int m_nCurCardIndex  {    get; private set;   }

    public PlayerModel()
    {
        for (int i = 0; i < MaxNum; i++)
        {
            Deck deck = new Deck();
            decks.Add(deck);
        }
    }
    public Deck GetDeck
    {
        get
        {
            Deck deck = decks[m_nCurCardIndex];
            if (deck == null)
            {
                deck = new Deck();
                decks.Add(deck);
            }
            return deck;
        }
    }

}
/// <summary>
/// 卡组类
/// </summary>
public class Deck
{
    public const int MaxNum = 4;
    public List<Card> cards = new List<Card>();

    public Deck()
    {
        for (int i = 0; i < MaxNum; i++)
        {
            Card card = new Card();
            card.ID = i + 1;
            cards.Add(card);
        }
    }
}
/// <summary>
/// 卡牌
/// </summary>
public class Card
{
    /// <summary>
    /// 卡组Id
    /// </summary>
   int id;
   public int level;
   public  int exp;
    public CardInfo cardInfo;

    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;

            cardInfo = ResManager.Instance.cardTable.GetById(id);
        }
    }

}