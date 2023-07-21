using System;

public class LoginUseCase
{
    private ILoginRepository loginRepository;

    public LoginUseCase(ILoginRepository loginRepository)
    {
        this.loginRepository = loginRepository;
    }

    public bool Login(UserLogin user) => loginRepository.Exist(user);
}