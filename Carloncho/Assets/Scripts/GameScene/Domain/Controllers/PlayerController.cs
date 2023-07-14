using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerController
{
    private List<Player> players = new List<Player>();
    private Player currentPlayer;

    public List<Player> GetPlayers() => players;

    public Player GetCurrentPlayer() => currentPlayer;

    public void AddPlayer(Player player) => players.Add(player);

    public void SetNextPlayerTurn(Action<int> setPlayerViewTurn)
    {
        if(currentPlayer == null)
        {
            currentPlayer = players.First();
            setPlayerViewTurn(0);
        }
        else {
            var currentPlayerIndex = players.IndexOf(currentPlayer);
            setPlayerViewTurn(currentPlayerIndex + 1);
            currentPlayer = players[currentPlayerIndex + 1];
        }
    }
}