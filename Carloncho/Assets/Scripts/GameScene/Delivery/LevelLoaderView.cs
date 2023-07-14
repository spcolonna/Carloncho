using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderView : MonoBehaviour
{
    [SerializeField] Animator loadLevelAnimator;

    public void EnterTransition()
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
