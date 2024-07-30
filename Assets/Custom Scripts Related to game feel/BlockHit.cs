using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockHit : MonoBehaviour
{
    public Material hitMaterial;
    public GameObject mesh;
    Material mat;
    Quaternion initialRotation;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        initialRotation = transform.rotation;
    }

    public void PlayHitEffect()
    {
        StartCoroutine(HitEffect());
    }

    IEnumerator HitEffect()
    {
        transform.DOScale(1.2f, 0.1f).OnComplete(() => {

            if (transform != null)
            {
               transform.DOScale(1.1f, 0.1f);
            }
        });


        if (mesh == null)
        {
           
            GetComponent<MeshRenderer>().material = hitMaterial;
            transform.DOShakeRotation(0.1f, new Vector3(5f, 5f, 5f)).OnComplete(()=>
            {
                transform.rotation = initialRotation;
            });
            yield return new WaitForSeconds(0.1f);
            GetComponent<MeshRenderer>().material = mat;
            
        }
        else
        {

            mesh.GetComponent<MeshRenderer>().material = hitMaterial;
            transform.DOShakeRotation(0.15f, new Vector3(8f, 8f, 8f)).OnComplete(() =>
            {
               
                transform.rotation = initialRotation;
            });
            yield return new WaitForSeconds(0.1f);
            mesh.GetComponent<MeshRenderer>().material = mat;
        }

        
    }
}
