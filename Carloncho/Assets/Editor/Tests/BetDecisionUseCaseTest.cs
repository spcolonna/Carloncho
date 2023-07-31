using System;
using System.Collections.Generic;
using NUnit.Framework;

public class BetDecisionUseCaseTest
{
	private List<string> cardValues = new() { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    [Test]
	[TestCase("2", "3", "4")]
    [TestCase("2", "3", "A")]
    [TestCase("3", "5", "8")]
    [TestCase("4", "7", "2")]
    [TestCase("10", "J", "J")]
    [TestCase("K", "A", "A")]
    public void Lose(string firstCardValue, string secondCardValue, string betCardValue)
	{
		var useCase = new BetDecisionUseCase(cardValues);

		var result = useCase.Execute(firstCardValue, secondCardValue, betCardValue);

		Assert.IsFalse(result);
	}

    [Test]
    [TestCase("3", "2")]
    [TestCase("2", "A")]
    [TestCase("Q", "J")]
    [TestCase("J", "8")]
    [TestCase("A", "K")]
    public void Win(string firstCardValue, string secondCardValue)
    {
        var useCase = new BetDecisionUseCase(cardValues);

        var result = useCase.Execute(firstCardValue, secondCardValue, "");

        Assert.IsTrue(result);
    }
}

