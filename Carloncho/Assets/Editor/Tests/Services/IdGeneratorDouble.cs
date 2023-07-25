public class IdGeneratorDouble : IIdGenerator
{
    private int idGame;

    public IdGeneratorDouble(int idGame)
    {
        this.idGame = idGame;
    }

    public int Generate()
    {
        return idGame;
    }
}