using System.Collections.Generic;
using NUnit.Framework;

public class EnrollGameUseCaseTest
{
	[Test]
	public void EnrollPlayer()
	{
		var userId = 1;
        var player = new Player(userId);
		var expected = new List<int> { userId };
        var idGame = 1;
        var idGenerator = new IdGeneratorDouble(idGame);
		var gameRepository = new GameRepositoryDouble(0);
		var gamePlayerRepository = new GamePlayerRepositoryDouble();
        var userAccount = new UserAccount(userId, 1);
        var userAccountRepository = new UserAccountRepositoryDouble(new List<UserAccount> { userAccount });
        var game = new Game(gameRepository, gamePlayerRepository,idGenerator);
        var useCase = GivenAEnrollGameUseCase(game, userAccountRepository);

        useCase.Execute(player);

		Assert.AreEqual(expected, gamePlayerRepository.GetPlayers(idGame));
	}

    [Test]
    public void EnrollAnotherPlayer()
    {
        var playerOne = new Player(1);
        var playerTwo = new Player(2);
        var expected = new List<int> { 1,2 };
        var idGame = 1;
        var idGenerator = new IdGeneratorDouble(idGame);
        var gameRepository = new GameRepositoryDouble(0);
        var gamePlayerRepository = new GamePlayerRepositoryDouble();
        var userAccountOne = new UserAccount(1, 1);
        var userAccountTwo = new UserAccount(2, 1);
        var userAccountRepository = new UserAccountRepositoryDouble(new List<UserAccount> { userAccountOne, userAccountTwo });
        var game = new Game(gameRepository, gamePlayerRepository, idGenerator);
        var useCase = GivenAEnrollGameUseCase(game, userAccountRepository);

        useCase.Execute(playerOne);
        useCase.Execute(playerTwo);

        Assert.AreEqual(expected, gamePlayerRepository.GetPlayers(idGame));
    }

    [Test]
    public void NotEnrollPlayer_NotEnoughMoney()
    {
        var userId = 1;
        var player = new Player(userId);
        var expected = new List<int>();
        var idGame = 1;
        var idGenerator = new IdGeneratorDouble(idGame);
        var gameRepository = new GameRepositoryDouble(10);
        var gamePlayerRepository = new GamePlayerRepositoryDouble();
        var userAccount = new UserAccount(userId, 0);
        var userAccountRepository = new UserAccountRepositoryDouble(new List<UserAccount> { userAccount});
        var game = new Game(gameRepository, gamePlayerRepository, idGenerator);
        var useCase = GivenAEnrollGameUseCase(game, userAccountRepository);

        useCase.Execute(player);

        Assert.AreEqual(expected, gamePlayerRepository.GetPlayers(idGame));
    }

    private EntollGameUseCase GivenAEnrollGameUseCase(Game game, IUserAccountRepository userAccountRepository = null) =>
        new(game, userAccountRepository ?? new UserAccountRepositoryDouble(new List<UserAccount>()));
}

