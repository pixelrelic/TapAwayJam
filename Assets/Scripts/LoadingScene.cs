using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
//using LionStudios.Suite.Core;


public class LoadingScene : MonoBehaviour
{

    [SerializeField] Slider progressSlider;
    [SerializeField] TextMeshProUGUI loadingpercentText;

    private void Awake()
    {
      //  LionCore.OnInitialized += OnLionCoreInitialized;
    }

    private void Start()
    {
        
    }


    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            //Debug.Log(Mathf.Clamp01(asyncLoad.progress * 100));
            //float val = (Mathf.Clamp01(asyncLoad.progress) * 100) + 10;
            progressSlider.value = 0;
            loadingpercentText.text = "" + Mathf.Round(progressSlider.value) + "%";
            //progressSlider.DOValue(val, 1, false);
            progressSlider.value = (Mathf.Clamp01(asyncLoad.progress) * 100);            
            loadingpercentText.text = "" + Mathf.Round(progressSlider.value) + "%";
            yield return null;
        }
    }


    private void OnLionCoreInitialized()
    {
        progressSlider.minValue = 0;
        progressSlider.maxValue = 100;
        progressSlider.value = 0;
        loadingpercentText.text = "" + Mathf.Round(progressSlider.value) + "%";
        StartCoroutine(LoadYourAsyncScene());
       // LionCore.OnInitialized -= OnLionCoreInitialized;
    }
}
