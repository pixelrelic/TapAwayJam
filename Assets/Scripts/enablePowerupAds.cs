using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePowerupAds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Level") >4)
        {
            enableChildAds();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableChildAds()
    {
        if(PlayerPrefs.GetInt("coins")<30)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
