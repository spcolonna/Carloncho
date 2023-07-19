using System;
using System.Collections.Generic;

public class GamePresenter
{
    readonly List<string> cardValues = new() { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public GamePresenter(CardPileView cardPileView, PlayerListView playerListView)
    {
        var playerController = new PlayerController();
        playerListView.Initialize(playerController);
        cardPileView.Initialize(GetCards());
    }

    private List<Card> GetCards()
    {
        var result = new List<Card>();
        foreach (int suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (string cardValue in cardValues)
            {
                result.Add(new Card(suit, cardValue));
            }
        }
        return result;
    }
}