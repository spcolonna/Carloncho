using System;
using System.Collections.Generic;
using NUnit.Framework;


public class BetUseCaseTests
{
    [Test]
    public void NotBetWithoutMoney()
    {
        var player = new Player();
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble();
        var useCase = new BetUseCase(repository);

        var result = useCase.ValidateBet(player, bet);

        Assert.IsFalse(result);
    }

    [Test]
    public void CanBet()
    {
        var player = new Player();
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble();
        var useCase = new BetUseCase(repository);

        var result = useCase.ValidateBet(player, bet);

        Assert.IsTrue(result);
    }
}

