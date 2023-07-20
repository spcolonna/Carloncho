using System;

public class BetUseCase
{
    private IRepository userAccountRepository;

    public BetUseCase(IRepository userAccountRepository)
    {
        this.userAccountRepository = userAccountRepository;
    }

    public bool ValidateBet(Player player, Bet bet)
    {
        var playerHaveAnAccount = userAccountRepository.Exist(
        return false;
    }
}