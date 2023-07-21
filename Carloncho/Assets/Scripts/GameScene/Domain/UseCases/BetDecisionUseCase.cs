using System;
using System.Collections.Generic;

public class BetDecisionUseCase
{
    private List<string> cardValues;

    public BetDecisionUseCase(List<string> cardValues)
    {
        this.cardValues = cardValues;
    }

    public bool Execute(string firstCardValue, string secondCardValue, int decision)
    {
        var firsCardIndex = cardValues.IndexOf(firstCardValue);
        var secondCardIndex = cardValues.IndexOf(secondCardValue);
        if (isBigger(decision))
            return false;

        if (firstCardValue.Equals("K") && secondCardValue.Equals("A"))
            return false;
        if (firstCardValue.Equals("A") && secondCardValue.Equals("K"))
            return true;
        return firsCardIndex > secondCardIndex;
    }

    private static bool isBigger(int decision) => decision == 1;
}