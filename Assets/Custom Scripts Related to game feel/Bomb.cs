using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 100.0F;
    public GameObject[] cubeParts;
    void Start()
    {
        Vector3 explosionPos = transform.position;
      
        foreach(GameObject part in cubeParts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 0F);

            part.transform.DOScale(Vector3.zero, 2f);
        }
    }
}
