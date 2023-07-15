using System;

public class LoginUseCase
{
    private IRepository loginRepository;

    public LoginUseCase(IRepository loginRepository)
    {
        this.loginRepository = loginRepository;
    }

    public bool Login(UserLogin user)
    {
        return loginRepository.Exist(user);
    }
}