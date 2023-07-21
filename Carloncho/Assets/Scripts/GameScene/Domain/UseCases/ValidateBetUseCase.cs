using System;

public class ValidateBetUseCase
{
    private IUserAccountRepository userAccountRepository;

    public ValidateBetUseCase(IUserAccountRepository userAccountRepository) =>
        this.userAccountRepository = userAccountRepository;

    public bool Execute(Player player, Bet bet)
    {
        var playerAccount = userAccountRepository.GetUserAccount(player.userId);
        return playerAccount != null && playerAccount.money >= bet.amount;
    }
}