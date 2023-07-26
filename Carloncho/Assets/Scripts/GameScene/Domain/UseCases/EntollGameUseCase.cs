using System;

public class EntollGameUseCase
{
    private readonly Game game;
    private readonly IUserAccountRepository userAccountRepository;

    public EntollGameUseCase(Game game, IUserAccountRepository userAccountRepository)
    {
        this.game = game;
        this.userAccountRepository = userAccountRepository;
    }

    public void Execute(Player player)
    {
        var gameLight = game.GetLight();
        var userAccount = userAccountRepository.GetUserAccount(player.userId);
        if(userAccount.money > gameLight)
            game.EnrollPlayer(player.userId);
    }
}