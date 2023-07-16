using System;
using UnityEngine;

public class LoginContext : MonoBehaviour
{
    [SerializeField] LevelLoaderView levelLoaderView;
    [SerializeField] LoginView loginView;

    void Start()
    {
        var loginRepository = new LoginRepository();
        var login = new LoginPresenter(levelLoaderView, loginView, loginRepository);
    }

}

