using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SupersonicWisdomSDK;
using UnityEngine.SceneManagement;

public class activateSS : MonoBehaviour
{
    // public GameObject gameManager;
    // public GameObject eventsystem;
    // public static bool gameLoad = false;

    private void Awake()
    {


        SupersonicWisdom.Api.AddOnReadyListener(OnSupersonicWisdomReady);
        // Then initialize
        SupersonicWisdom.Api.Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSupersonicWisdomReady()
    {
        SceneManager.LoadScene(1);
        // Start your game from this point
    }
}
