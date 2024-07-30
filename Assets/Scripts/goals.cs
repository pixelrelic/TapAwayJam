using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class goals : MonoBehaviour
{
    public int count;


    private void Awake()
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = count.ToString();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
