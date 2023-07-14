using System;
using System.Collections.Generic;
using NUnit.Framework;

public class PlayerControllerTests
{
	[Test]

	public void AddPlayerToRoom()
	{
        var player = new Player();
        var expected = new List<Player>() { player };
		var playerController = new PlayerController();

		playerController.AddPlayer(player);
        var result = playerController.GetPlayers();

        Assert.AreEqual(expected, result);
	}

    [Test]

    public void AddAnotherPlayerToRoom()
    {
        var player = new Player();
        var anotherPlayer = new Player();
        var expected = new List<Player>() { player, anotherPlayer };
        var playerController = new PlayerController();

        playerController.AddPlayer(player);
        playerController.AddPlayer(anotherPlayer);
        var result = playerController.GetPlayers();

        Assert.AreEqual(expected, result);
    }

    [Test]

    public void GetFirstPlayerTurn()
    {
        var spy = new DomainActionSpy();
        var firstPlayer = new Player();
        var secondPlayer = new Player();
        var playerController = new PlayerController();

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
        var firstPlayer = new Player();
        var secondPlayer = new Player();
        var playerController = new PlayerController();

        playerController.AddPlayer(firstPlayer);
        playerController.AddPlayer(secondPlayer);
        playerController.SetNextPlayerTurn(spy.GenericCallback);
        playerController.SetNextPlayerTurn(spy.GenericCallback);

        Assert.AreEqual(1, spy.CalledElement);
        Assert.AreEqual(secondPlayer, playerController.GetCurrentPlayer());
    }
}

