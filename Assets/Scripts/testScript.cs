using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveZ(5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
