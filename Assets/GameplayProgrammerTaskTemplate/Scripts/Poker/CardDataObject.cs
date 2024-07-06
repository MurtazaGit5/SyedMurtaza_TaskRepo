using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/CardData")]
public class CardDataObject : ScriptableObject
{
    public Card[] Cards;
    public Card[] JokerCards;
    public Card[] TarotCards;
    public Card[] PlanetCards;

    public Card GetRandomCard()
    {
        return Cards[Random.Range(0, Cards.Length)];
    }

    public Card GetRandomJokerCard()
    {
        return JokerCards[Random.Range(0, JokerCards.Length)];
    }

    public Card GetRandomTarotCard()
    {
        return TarotCards[Random.Range(0, TarotCards.Length)];
    }

    public Card GetRandomPlanetCard()
    {
        return PlanetCards[Random.Range(0, PlanetCards.Length)];
    }
}
