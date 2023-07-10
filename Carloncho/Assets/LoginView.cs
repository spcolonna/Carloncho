using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    [SerializeField] Button enterButton;
    [SerializeField] LevelLoaderView levelLoaderView;

    void Start() => enterButton.onClick.AddListener(levelLoaderView.EnterTransition);
}
