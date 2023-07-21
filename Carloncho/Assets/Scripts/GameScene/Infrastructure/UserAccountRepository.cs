using System;

public class UserAccountRepository : IUserAccountRepository
{
	public UserAccountRepository()
	{
	}

    public bool Exist(int userId)
    {
        throw new NotImplementedException();
    }

    public UserAccount? GetUserAccount(int userId)
    {
        throw new NotImplementedException();
    }
}

