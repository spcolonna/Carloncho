public interface IUserAccountRepository
{
    bool Exist(int userId);
    UserAccount? GetUserAccount(int userId);
}