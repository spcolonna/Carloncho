using System.Collections.Generic;
using System.Linq;

public class UserAccountRepositoryDouble : IUserAccountRepository
{
    private List<UserAccount> userAccounts;

    public UserAccountRepositoryDouble(List<UserAccount> userAccounts)
    {
        this.userAccounts = userAccounts;
    }

    public bool Exist(int userId) => userAccounts.Exists(account => account.userId == userId);

    public UserAccount? GetUserAccount(int userId) => userAccounts.FirstOrDefault(account => account.userId == userId);
}