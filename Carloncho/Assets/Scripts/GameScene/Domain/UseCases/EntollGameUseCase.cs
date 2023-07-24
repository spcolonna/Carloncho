using System;

public class EntollGameUseCase
{
    private Game game;

    public EntollGameUseCase(Game game)
    {
        this.game = game;
    }

    public void Execute(Player player)
    {
        throw new NotImplementedException();
    }

    internal void Execute()
    {
        throw new NotImplementedException();
    }
}