using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WobbleRocketWhenCollided : MonoBehaviour
{
    [SerializeField] Material redMaterial;

    public void WobbleInDirection(Vector3 direction)
    {   
        if(CustomEffectsManager.instance != null)
        {
            CustomEffectsManager.instance.PlayRocketHitEffect();
        }
        
        Transform rocketChild = transform.GetChild(0).GetChild(0);

        //Debug.Log("move direction : " + direction);
        Vector3 punchvector = direction * -1 * 0.1f;
        //GetComponent<BoxCollider>().enabled = false;
        Material original = GetComponent<MeshRenderer>().material;
        Material rocketMaterial = rocketChild.gameObject.GetComponent<MeshRenderer>().material;            
        GetComponent<MeshRenderer>().material = redMaterial;
        rocketChild.gameObject.GetComponent<MeshRenderer>().material = redMaterial;
        transform.DOPunchPosition(punchvector, 0.2f, 1).OnComplete(()=>
        {
            GetComponent<MeshRenderer>().material = original;
            rocketChild.gameObject.GetComponent<MeshRenderer>().material = rocketMaterial;
          //  GetComponent<BoxCollider>().enabled = true;
        });

    }
}
