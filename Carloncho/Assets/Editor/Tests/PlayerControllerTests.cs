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

    /*[Test]

    public void GetFirstPlayerTurn()
    {
        var expectedIndex = 0;

        var players = new List<Player>() { new Player() };
        var playerController = new PlayerController();

        var result = playerController.GetNextPlayerTurn();

        Assert.AreEqual(expectedIndex, result)

    }*/
}

