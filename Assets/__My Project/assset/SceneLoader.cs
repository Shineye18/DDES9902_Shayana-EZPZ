using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Optional. The black fade screen. Leave EMPTY for now - we add it in Task 2.")]
    public CanvasGroup fadeScreen;

    [Tooltip("How many seconds the fade to black takes before the new scene loads.")]
    public float fadeTime = 0.5f;

    bool isLoading;

    // Buttons call this. Type the exact scene name in the button's event box.
    public void LoadScene(string sceneName)
    {
        if (isLoading) return;   // stops double-clicks loading twice
        isLoading = true;
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        if (fadeScreen != null)
        {
            fadeScreen.gameObject.SetActive(true);
            fadeScreen.blocksRaycasts = true;
            float t = 0f;
            while (t < fadeTime)
            {
                t += Time.unscaledDeltaTime;
                fadeScreen.alpha = Mathf.Clamp01(t / fadeTime);
                yield return null;
            }
            fadeScreen.alpha = 1f;
        }
        SceneManager.LoadScene(sceneName);
    }
}