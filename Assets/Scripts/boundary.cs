using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "rocket" && other.GetComponent<moveRockets>().moving)
        {
            GameObject parObj = other.transform.gameObject;
            GameObject obj = parObj.transform.GetChild(0).gameObject;
       
            obj.transform.SetParent(null);
            Destroy(parObj);
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<shootRocket>().enabled = true;
            
        }

    }
}
