using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIEffects : MonoBehaviour
{
    [SerializeField] public List<GameObject> items;
    public List<Vector3> scalableItems;
    public float initialDelay = 1f;
    public float delayeTime = 0.5f;
    //AudioManager audiomanager;
    WaitForSeconds delay;
    [SerializeField] GameObject moneyAnimationGO;

    [SerializeField] bool autoEffect = true;
    [SerializeField] bool audioRequired = true;


 
    private void Start()
    {
       /* //Debug.Log(items.Count);
        scalableItems = new List<Vector3>(items.Count);

        
        int i = 0;
        for(i = 0; i < items.Count; i++)
        {
            scalableItems.Add(items[i].transform.localScale);
            Debug.Log("local scale : " + items[i].transform.localScale);
        }

        delay = new WaitForSeconds(delayeTime);
        //audiomanager = AudioManager.instance;
        StartEffects();
       */
    }


    public void AnimateObjectsInList()
    {
        StartCoroutine("AnimateObjects");
    }

    IEnumerator AnimateObjects()
    {
        yield return new WaitForSeconds(initialDelay);
        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
        }

        int i = 0;
        foreach (GameObject item in items)
        {
            item.SetActive(true);
            item.transform.DOScale(scalableItems[i], delayeTime).SetEase(Ease.OutBounce);
            i++;
            yield return delay;
            if (audioRequired)
            {
                //audiomanager.PlayUISound();
            }
        }

        //yield return delay;
        if (moneyAnimationGO != null)
        {
            moneyAnimationGO.SetActive(true);
        }
    }


    void StartEffects()
    {
        if (autoEffect)
        {
            StartCoroutine("AnimateObjects");
        }
    }


    private void OnEnable()
    {
        //Debug.Log(items.Count);
        scalableItems = new List<Vector3>(items.Count);


        int i = 0;
        for (i = 0; i < items.Count; i++)
        {
            scalableItems.Add(items[i].transform.localScale);
            //Debug.Log("local scale : " + items[i].transform.localScale);
        }

        delay = new WaitForSeconds(delayeTime);
        StartEffects();
    }
}
