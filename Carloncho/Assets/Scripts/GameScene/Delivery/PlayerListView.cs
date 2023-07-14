using System.Collections.Generic;
using UnityEngine;

public class PlayerListView : MonoBehaviour
{
    [SerializeField] List<PlayerView> players;
    PlayerController playerController;

    public void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        GetNextPlayerTurn();
    }

    private void GetNextPlayerTurn() => playerController.SetNextPlayerTurn(SetPlayerTurn);

    private void SetPlayerTurn(int playerIndex)
    {
        var player = players[playerIndex];
    }

}
