using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    [SerializeField] Button enterButton;

    private string name = "";
    private string password = "";
    private LoginController loginController;

    public void Initialize(LoginController loginController)
    {
        this.loginController = loginController;
        enterButton.onClick.AddListener(Login);
    }

    public void SetName(string name) => this.name = name;

    public void SetPassword(string password) => this.password = password;

    private void Login() => loginController.login(name, password);
}
