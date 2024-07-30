using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enableContinue : MonoBehaviour
{
     rocketManager rm;

    private void Awake()
    {
        rm = GameObject.FindGameObjectWithTag("manager").GetComponent<rocketManager>();
    }

    private void OnEnable()
    {

        if( rm.newSlots < 5)
        {
            if (PlayerPrefs.GetInt("coins") > 199)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {

                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
