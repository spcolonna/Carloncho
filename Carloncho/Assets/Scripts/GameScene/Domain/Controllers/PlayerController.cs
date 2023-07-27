using System;
using System.Collections.Generic;
using System.Linq;

public class PlayerController
{
    private readonly List<Player> players = new();
    private Player currentPlayer;
    private int currentPlayerIndex = -1;
    private Action readyCallback;
    private bool gameReady = false;

    public List<Player> GetPlayers() => players;

    public Player GetCurrentPlayer() => currentPlayer;

    public void ReadySubscribe(Action readyCallback) => this.readyCallback = readyCallback;

    public void AddPlayer(Player player)
    {
        players.Add(player);
        CheckGameReady();
    }

    private void CheckGameReady()
    {
        if (!gameReady && players.Count > 1)
        {
            readyCallback();
            gameReady = true;
        }
    }

    public void SetNextPlayerTurn(Action<int> setPlayerViewTurn)
    {
        IncreasePlayerIndex();
        setPlayerViewTurn(currentPlayerIndex);
        currentPlayer = players[currentPlayerIndex];
    }
    
    private void IncreasePlayerIndex()
    {
        currentPlayerIndex++;
        if (currentPlayerIndex == players.Count)
            currentPlayerIndex = 0;
    }

    public void RemovePlayer(int userId)
    {
        var playerToRemove = players.Where(player => player.userId == userId).First();
        players.Remove(playerToRemove);
    }
}