using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Spawner : MonoBehaviour
{
    public GameObject[] rockets;
    public List<GameObject> rocketsList;   
    public TextMeshPro rocketsRem;
    public GameObject brokenParts;
    public float rayLength = 0.2f;
    public int c = 0;
    int totalRockets;
    public int tempRockets;
    bool rocketPos = false;
   public Vector3 spawnPos;
   public Quaternion spawnRot;
    bool spawnNew = true;
     void Awake()
    {
        /* totalRockets = rockets.Length ;
         tempRockets = totalRockets;
         rocketsRem.text = tempRockets.ToString();*/
        rocketsList = new List<GameObject>(rockets);
        totalRockets = rockets.Length;
        tempRockets = totalRockets;
        rocketsRem.text = tempRockets.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);

        // Perform the raycast
        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
        {
            if(!rocketPos)
            {
                spawnPos = hitInfo.transform.localPosition;
              //  spawnRot = hitInfo.transform.rotation;
                rocketPos = true;
            }
        }
        else
        {
            if(c <totalRockets && rocketPos && spawnNew)
            {
                spawnNew = false;
               // dummyTile.SetActive(true); //Test
                GameObject rock = Instantiate(rocketsList[0], new Vector3(transform.position.x,transform.position.y-0.5f,transform.position.z), spawnRot,transform.parent.transform.parent.transform);
                rock.transform.DOLocalMove(spawnPos, 0.5f)
                    .OnComplete(() =>
                    {
                        
                        spawnNew = true;
                    })
                    ;

                postSpawnCode(0);
               


            }
            
        }
    }

    public void postSpawnCode(int c)
    {
        // c++;
        rocketsList.RemoveAt(c);
        tempRockets -= 1;
        rocketsRem.text = tempRockets.ToString();
        if (tempRockets == 0)
        {
            GameObject bP = Instantiate(brokenParts, transform.position, Quaternion.identity);
            Destroy(bP, 0.8f);
            Destroy(transform.parent.gameObject);
        }
    }
}
