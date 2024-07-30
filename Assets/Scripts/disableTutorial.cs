using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTutorial : MonoBehaviour
{
    public GameObject tutObj;
    public GameObject powerUpicon;


    private void Awake()
    {
        powerUpicon.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<moveRockets>().moving && tutObj.activeSelf)
        {
            tutObj.SetActive(false);
            powerUpicon.SetActive(true);
        }
    }
}
