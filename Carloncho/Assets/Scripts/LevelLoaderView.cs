using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaderView : MonoBehaviour
{
    [SerializeField] Animator loadLevelAnimator;
    [SerializeField] Button enterButton;

    void Start()
    {
        enterButton.onClick.AddListener(EnterTransition);
    }

    private void EnterTransition()
    {
        StartCoroutine(LevelLoaderCoroutine());
    }

    private IEnumerator LevelLoaderCoroutine()
    {
        loadLevelAnimator.SetTrigger("Enter");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
