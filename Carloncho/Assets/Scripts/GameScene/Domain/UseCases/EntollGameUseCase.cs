using System;

public class EntollGameUseCase
{
    private Game game;

    public EntollGameUseCase(Game game) => this.game = game;

    public void Execute(Player player)
    {
        var gameId = game.GetId();
        game.EnrollPlayer(player.userId);
    }
}