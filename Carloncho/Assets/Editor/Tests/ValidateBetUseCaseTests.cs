using System.Collections.Generic;
using NUnit.Framework;


public class ValidateBetUseCaseTests
{
    [Test]
    public void NotBet_PlayerNotExist()
    {
        var player = new Player(0);
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble(new List<UserAccount>());
        var useCase = new ValidateBetUseCase(repository);

        var result = useCase.Execute(player, bet);

        Assert.IsFalse(result);
    }

    [Test]
    public void CanBet_PlayerExist()
    {
        var player = new Player(0);
        var userAccount = new UserAccount(0, 100);
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble(new List<UserAccount>() { userAccount });
        var useCase = new ValidateBetUseCase(repository);

        var result = useCase.Execute(player, bet);

        Assert.IsTrue(result);
    }

    [Test]
    public void NotBet_PlayerNotMoney()
    {
        var player = new Player(0);
        var userAccount = new UserAccount(0, 0);
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble(new List<UserAccount>() { userAccount });
        var useCase = new ValidateBetUseCase(repository);

        var result = useCase.Execute(player, bet);

        Assert.IsFalse(result);
    }

    [Test]
    public void NotBet_PlayerMoneyBeEqualsOrBiggerThanBet()
    {
        var player = new Player(0);
        var userAccount = new UserAccount(0, 101);
        var bet = new Bet(100, 0);
        var repository = new UserAccountRepositoryDouble(new List<UserAccount>() { userAccount });
        var useCase = new ValidateBetUseCase(repository);

        var result = useCase.Execute(player, bet);

        Assert.IsTrue(result);
    }

    //private UserAccountRepositoryDouble GivenAUserAccountRepository()
}

