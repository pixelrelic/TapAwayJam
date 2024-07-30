using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadLevelRocketEffect : MonoBehaviour
{
    public List<GameObject> rocketsInThisLevel;

    void Start()
    {
        //init rockets : 

        GameObject[] rockets;
        //get all rockets in this level
        rockets = GameObject.FindGameObjectsWithTag("rockets");

        foreach(GameObject rocket in rockets)
        {
            rocketsInThisLevel.Add(rocket);
        }

        //effects : 
        StartEffect();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartEffect();
        }
    }


    void StartEffect()
    {
        foreach(GameObject rocket in rocketsInThisLevel)
        {
            EnableEffect(rocket);
        }
    }

    void EnableEffect(GameObject rocket)
    {
        float delay = Random.RandomRange(0, 0.2f);
        float time = 0.5f;

        //effect 1 : pop at position
        rocket.transform.DOPunchPosition(new Vector3(0, -1, 0), time+delay,5);

        //effect2 : scale from 0 to intial scale
        Vector3 initialScale = rocket.transform.localScale;
        rocket.transform.localScale = Vector3.zero;
        rocket.transform.DOScale(initialScale, time + delay);
    }

}
