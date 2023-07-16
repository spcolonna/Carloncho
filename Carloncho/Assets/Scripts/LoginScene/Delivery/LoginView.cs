using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    [SerializeField] Button enterButton;

    private string userName = "";
    private string password = "";
    private LoginController loginController;

    public void Initialize(LoginController loginController)
    {
        this.loginController = loginController;
        enterButton.onClick.AddListener(Login);
    }

    public void SetName(string userName) => this.userName = userName;

    public void SetPassword(string password) => this.password = password;

    private void Login() => loginController.Login(userName, password);
}
