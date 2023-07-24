using System;
using System.Collections.Generic;
using NUnit.Framework;

public class EnrollGameUseCaseTest
{
	[Test]
	public void EnrollPlayer()
	{
        var player = new Player(1);
		var expected = new List<Player>() { player };
		var idGame = 1;
		var idGenerator = new IdGeneratorDouble(idGame);
		var gameRepository = new GameRepositoryDouble();
		var gamePlayerRepository = new GamePlayerRepositoryDouble();
        var game = new Game(gameRepository, gamePlayerRepository,idGenerator);
        var useCase = new EntollGameUseCase(game);

        useCase.Execute(player);

		Assert.AreEqual(expected, gamePlayerRepository.GetPlayers(idGame));
	}
}

