using System.Collections.Generic;
using System.Linq;

public class LoginRepositoryDouble : IRepository
{
    private List<UserLogin> users;
    public LoginRepositoryDouble(List<UserLogin> users = null)
    {
        this.users = users ?? new List<UserLogin>();
    }

    public bool Exist(UserLogin user) => users.Any(u => u == user);
}