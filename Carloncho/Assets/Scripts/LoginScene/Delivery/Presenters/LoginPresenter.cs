internal class LoginPresenter
{
    private LevelLoaderView levelLoaderView;

    public LoginPresenter(LevelLoaderView levelLoaderView, LoginView loginView, LoginRepository loginRepository)
    {
        this.levelLoaderView = levelLoaderView;
        var loginUseCase = new LoginUseCase(loginRepository);
        var loginController = new LoginController(loginUseCase, levelLoaderView);
        loginView.Initialize(loginController);
    }
}