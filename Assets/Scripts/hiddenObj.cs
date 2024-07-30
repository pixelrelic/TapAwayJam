using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenObj : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask detectionLayer;
    public List<GameObject> detectedObjects = new List<GameObject>();
    public GameObject newRocket;
    public Vector3 eulerAngles;
    Quaternion rotation;
    public float rayLength = 0.2f;
   

    private void Awake()
    {
        rotation = Quaternion.Euler(eulerAngles);
    }
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.up);

        // Perform the raycast
        if (!Physics.Raycast(ray, out RaycastHit hitInfo, rayLength, detectionLayer))
        {
            InstatiateHiddenRocket();
            
        }
      
    }

    public GameObject InstatiateHiddenRocket()
    {
        Transform parent = transform.parent.transform.parent;
        GetComponent<AudioSource>().Play();
        GameObject rocket =Instantiate(newRocket, transform.position, transform.rotation, parent);
        this.enabled = false;

        Destroy(gameObject.transform.parent.gameObject, 0.1f);
        return rocket;
    }
}
