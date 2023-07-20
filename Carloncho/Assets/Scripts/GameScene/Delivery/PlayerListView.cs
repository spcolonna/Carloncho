using System.Collections.Generic;
using UnityEngine;

public class PlayerListView : MonoBehaviour
{
    [SerializeField] List<PlayerView> playersView;
    PlayerController playerController;

    public void Initialize(PlayerController playerController)
    {
        this.playerController = playerController;
        this.playerController.ReadySubscribe(StartGame);
    }

    private void StartGame() => playerController.SetNextPlayerTurn(SetPlayerTurn);

    private void SetPlayerTurn(int playerIndex)
    {
        playersView.ForEach(player => player.Unselect());
        var player = playersView[playerIndex];
        player.Select();
    }

}
