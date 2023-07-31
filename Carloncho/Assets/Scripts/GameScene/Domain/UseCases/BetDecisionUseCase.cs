using System;
using System.Collections.Generic;

public class BetDecisionUseCase
{
    private List<string> cardValues;

    public BetDecisionUseCase(List<string> cardValues)
    {
        this.cardValues = cardValues;
    }

    public bool Execute(string firstCardValue, string secondCardValue, string betCardValue)
    {
        var firsCardIndex = cardValues.IndexOf(firstCardValue);
        var secondCardIndex = cardValues.IndexOf(secondCardValue);
        var betCardIndex = cardValues.IndexOf(betCardValue);
        return firsCardIndex < betCardIndex && betCardIndex < secondCardIndex;
    }
}