using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack
{
    private Sprite m_cardBack;
    public List<Sprite> cardBackOptions;
    public Sprite CardBackSprite => m_cardBack;

    public void SetCardBack(Sprite cardBack)
    {
        m_cardBack = cardBack;
    }

    public void SetRandomCardBack()
    {
        if (cardBackOptions != null && cardBackOptions.Count > 0)
        {
            m_cardBack = cardBackOptions[Random.Range(0, cardBackOptions.Count)];
        }
    }

    public void UnlockCardBack(Sprite newCardBack)
    {
        if (cardBackOptions == null)
        {
            cardBackOptions = new List<Sprite>();
        }

        if (!cardBackOptions.Contains(newCardBack))
        {
            cardBackOptions.Add(newCardBack);
        }
    }
}
