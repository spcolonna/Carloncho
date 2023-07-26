using System;

public class Game
{
    private readonly int gameId;
    private readonly IGameRepository gameRepository;
    private readonly IGamePlayerRepository gamePlayerRepository;

    public Game(IGameRepository gameRepository, IGamePlayerRepository gamePlayerRepository, IIdGenerator idGenerator)
    {
        gameId = idGenerator.Generate();
        this.gameRepository = gameRepository;
        this.gamePlayerRepository = gamePlayerRepository;
    }

    public int GetId() => gameId;

    public void EnrollPlayer(int userId) => gamePlayerRepository.Store(gameId, userId);

    public float GetLight()
    {
        return gameRepository.GetLight(gameId);
    }
}