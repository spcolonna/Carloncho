using System;
using System.Collections.Generic;

public class PlayerController
{
    private List<Player> players = new List<Player>();

    public void AddPlayer(Player player) => players.Add(player);

    public void GetNextPlayerTurn(Action<int> setPlayerTurn)
    {
        throw new NotImplementedException();
    }

    public List<Player> GetPlayers() => players;
}