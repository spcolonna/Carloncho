using System;

public class Game
{
    private readonly int gameId;
    private readonly IGamePlayerRepository gamePlayerRepository;

    public Game(IGameRepository gameRepository, IGamePlayerRepository gamePlayerRepository, IIdGenerator idGenerator)
    {
        gameId = idGenerator.Generate();
        this.gamePlayerRepository = gamePlayerRepository;
    }

    public int GetId() => gameId;

    internal void EnrollPlayer(int userId)
    {
        gamePlayerRepository.Store(gameId, userId);
    }
}