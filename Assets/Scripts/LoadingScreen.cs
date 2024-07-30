using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    public TextMeshProUGUI loadingText;

    void Start()
    {
        loadingText.text = "Loading...";

        // Load scene 1 synchronously

        StartCoroutine(loadingDelay(1f));
        // Once scene is loaded, activate it
       // SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    IEnumerator loadingDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

    IEnumerator UpdateProgress(AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
        {
            // Update loading progress text
            loadingText.text = "Loading... " + (asyncOperation.progress * 100) + "%";

            // Wait for the next frame
            yield return null;
        }

        // Scene has finished loading, activate it
        asyncOperation.allowSceneActivation = true;
    }
}