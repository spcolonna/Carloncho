public class GameRepositoryDouble : IGameRepository
{
    private readonly int gameLight;

    public GameRepositoryDouble(int gameLight)
    {
        this.gameLight = gameLight;
    }

    public float GetLight(int gameId)
    {
        return gameLight;
    }
}