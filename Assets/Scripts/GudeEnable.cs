using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GudeEnable : MonoBehaviour
{
    public GameObject inputManager;

    private void Awake()
    {
        inputManager.SetActive(false);

        if (PlayerPrefs.GetInt("Level") == 10)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        if (PlayerPrefs.GetInt("Level") == 15)
        {
            transform.GetChild(1).gameObject.SetActive(true);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closethisPanel()
    {
        gameObject.SetActive(false);
        inputManager.SetActive(true);

    }
}
