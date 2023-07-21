using System;
using System.Collections.Generic;
using NUnit.Framework;

public class BetDecisionUseCaseTest
{
	private List<string> cardValues = new() { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    [Test]
	[TestCase("2", "3")]
    [TestCase("3", "4")]
    [TestCase("4", "7")]
    [TestCase("10", "10")]
    [TestCase("K", "A")]
    public void Lose_DecisionMinor(string firstCardValue, string secondCardValue)
	{
		var decision = 0;
		var useCase = new BetDecisionUseCase(cardValues);

		var result = useCase.Execute(firstCardValue, secondCardValue, decision);

		Assert.IsFalse(result);
	}

    [Test]
    [TestCase("3", "2")]
    [TestCase("2", "A")]
    [TestCase("Q", "J")]
    [TestCase("J", "8")]
    [TestCase("A", "K")]
    public void Win_DecisionMinor(string firstCardValue, string secondCardValue)
    {
        var decision = 0;
        var useCase = new BetDecisionUseCase(cardValues);

        var result = useCase.Execute(firstCardValue, secondCardValue, decision);

        Assert.IsTrue(result);
    }
}

