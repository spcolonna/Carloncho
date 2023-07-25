using System;
using System.Collections.Generic;
using System.Linq;

public class GamePlayerRepositoryDouble : IGamePlayerRepository
{
    public Dictionary<int, int> gamePlayers = new Dictionary<int, int>();
    public GamePlayerRepositoryDouble()
    {
    }

    public List<int> GetPlayers(int idGame) =>
        gamePlayers.Where(player => player.Value == idGame).Select(player => player.Key).ToList();

    public void Store(int gameId, int userId)
    {
        gamePlayers.Add(userId, gameId);
    }
}