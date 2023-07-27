using System;
using System.Collections.Generic;
using NUnit.Framework;

public class PlayerControllerTests
{
	[Test]
	public void AddPlayerToRoom()
	{
        var player = new Player(1);
        var expected = new List<Player>() { player };
		var playerController = new PlayerController();

		playerController.AddPlayer(player);
        var result = playerController.GetPlayers();

        Assert.AreEqual(expected, result);
	}

    [Test]
    public void AddAnotherPlayerToRoom()
    {
        var player = new Player(1);
        var anotherPlayer = new Player(2);
        var expected = new List<Player>() { player, anotherPlayer };
        var playerController = new PlayerController();

        playerController.ReadySubscribe(() => { });
        playerController.AddPlayer(player);
        playerController.AddPlayer(anotherPlayer);
        var result = playerController.GetPlayers();

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void GetFirstPlayerTurn()
    {
        var spy = new DomainActionSpy();
        var firstPlayer = new Player(1);
        var secondPlayer = new Player(2);
        var playerController = new PlayerController();

        playerController.ReadySubscribe(() => { });
        playerController.AddPlayer(firstPlayer);
        playerController.AddPlayer(secondPlayer);
        playerController.SetNextPlayerTurn(spy.GenericCallback);

        Assert.IsTrue(spy.WasCalled);
        Assert.AreEqual(firstPlayer, playerController.GetCurrentPlayer());
    }

    [Test]
    public void GetSecondPlayerTurn()
    {
        var spy = new DomainActionSpy();
        var firstPlayer = new Player(1);
        var secondPlayer = new Player(2);
        var playerController = new PlayerController();

        playerController.ReadySubscribe(() => { });
        playerController.AddPlayer(firstPlayer);
        playerController.AddPlayer(secondPlayer);
        playerController.SetNextPlayerTurn(spy.GenericCallback);
        playerController.SetNextPlayerTurn(spy.GenericCallback);

        Assert.AreEqual(1, spy.CalledElement);
        Assert.AreEqual(secondPlayer, playerController.GetCurrentPlayer());
    }

    [Test]
    public void NotCallbackPlayTurnWhenOnlyOnePlayer()
    {
        var spy = new DomainActionSpy();
        var playerController = new PlayerController();

        playerController.ReadySubscribe(spy.BasicCallback);
        playerController.AddPlayer(new Player(1));

        Assert.IsFalse(spy.WasCalled);
    }

    [Test]
    public void CallbackPlayTurnWhenHaveMoreThanOnePlayer()
    {
        var spy = new DomainActionSpy();
        var playerController = new PlayerController();

        playerController.ReadySubscribe(spy.BasicCallback);
        playerController.AddPlayer(new Player(1));
        playerController.AddPlayer(new Player(2));

        Assert.IsTrue(spy.WasCalled);
    }

    [Test]
    public void CallbackOneTimePlayTurnWhenHaveMoreThanTwoPlayer()
    {
        var spy = new DomainActionSpy();
        var playerController = new PlayerController();

        playerController.ReadySubscribe(spy.BasicCallback);
        playerController.AddPlayer(new Player(1));
        playerController.AddPlayer(new Player(2));
        playerController.AddPlayer(new Player(3));

        Assert.AreEqual(1, spy.CalledTimes);
    }


    [Test]
    public void GetTurnAfterOneLap()
    {
        var spy = new DomainActionSpy();
        var playerController = new PlayerController();
        var expected = new Player(1);

        playerController.ReadySubscribe(spy.BasicCallback);
        playerController.AddPlayer(expected);
        playerController.AddPlayer(new Player(2));
        playerController.AddPlayer(new Player(3));
        playerController.SetNextPlayerTurn(_ => { });
        playerController.SetNextPlayerTurn(_ => { });
        playerController.SetNextPlayerTurn(_ => { });
        playerController.SetNextPlayerTurn(_ => { });

        Assert.AreEqual(expected, playerController.GetCurrentPlayer());
    }

    [Test]
    public void RemovePlayer()
    {
        var playerOne = new Player(1);
        var playerThree = new Player(3);
        var expected = new List<Player> { playerOne, playerThree };
        var spy = new DomainActionSpy();
        var playerController = new PlayerController();

        playerController.ReadySubscribe(spy.BasicCallback);
        playerController.AddPlayer(playerOne);
        playerController.AddPlayer(new Player(2));
        playerController.AddPlayer(playerThree);
        playerController.RemovePlayer(2);

        Assert.AreEqual(expected, playerController.GetPlayers());
    }
}

