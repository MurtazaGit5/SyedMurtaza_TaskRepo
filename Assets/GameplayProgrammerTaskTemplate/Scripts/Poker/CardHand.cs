using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Data Struct for storing the cards contained with in a players hand. 
/// </summary>
public struct CardHand
{
    public Card[] Cards;
    private List<Card> specialCards;

    public CardHand(int cardsInHand)
    {
        Cards = new Card[cardsInHand];
        specialCards = new List<Card>();
    }

    public CardHand(int cardsInHand, ulong bitMap)
    {
        Cards = new Card[cardsInHand];
        specialCards = new List<Card>();
        Cards = BitMapToHand(bitMap, cardsInHand);
    }

    public ulong GetBitmap()
    {
        return HandToBitmap();
    }

    private Card[] BitMapToHand(ulong bitmap, int cardNumber)
    {
        Card[] cards = new Card[cardNumber];

        int id = 0;
        for (int r = 0; r < Card.s_ranks.Length; r++)
        {
            for (int s = 0; s < Card.s_suits.Length; s++)
            {
                var shift = r * 4 + s;
                if (((1ul << shift) & bitmap) != 0)
                {
                    cards[id] = Card.StringToCard(Card.s_ranks[r].ToString() + Card.s_suits[s].ToString());
                    id++;
                }
            }
        }

        return cards;
    }

    private ulong HandToBitmap()
    {
        ulong bitmap = 0;
        for (int i = 0; i < Cards.Length; i++)
        {
            bitmap |= Cards[i].GetId();
        }

        return bitmap;
    }

    public void AddCard(Card card)
    {
        Array.Resize(ref Cards, Cards.Length + 1);
        Cards[Cards.Length - 1] = card;
    }

    public void RemoveCard(Card card)
    {
        Cards = Cards.Where(c => c != card).ToArray();
    }

    public void AddSpecialCard(Card card)
    {
        specialCards.Add(card);
    }

    public void RemoveSpecialCard(Card card)
    {
        specialCards.Remove(card);
    }

    public List<Card> GetSpecialCards()
    {
        return specialCards;
    }
}
