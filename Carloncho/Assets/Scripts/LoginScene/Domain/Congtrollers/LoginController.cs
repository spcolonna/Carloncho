using System;

public class LoginController
{
    private LoginUseCase loginUseCase;
    private LevelLoaderView levelLoaderView;

    public LoginController(LoginUseCase loginUseCase, LevelLoaderView levelLoaderView)
    {
        this.loginUseCase = loginUseCase;
        this.levelLoaderView = levelLoaderView;
    }

    public void login(string name, string password)
    {
        var userExist = loginUseCase.Login(new UserLogin(name, password));
        if (userExist)
            levelLoaderView.EnterTransition();
    }
}