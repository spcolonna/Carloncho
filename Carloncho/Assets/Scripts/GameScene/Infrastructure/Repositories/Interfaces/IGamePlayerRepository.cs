using System.Collections.Generic;

public interface IGamePlayerRepository
{
    List<int> GetPlayers(int idGame);
    void Store(int gameId, int userId);
}