using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class releaseRockets : MonoBehaviour
{
    [SerializeField] float m_Speed = 100f;
    bool moving = false;
    RaycastHit hit;
    public float detectionRange = 10f;
   public bool colliding;
    bool push;
    float distance;
    Vector3 initialPos;
    gameManager gm;

    GameObject parent;
    private void Awake()
    {
        parent = transform.parent.gameObject;
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        initialPos = transform.position;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        if (moving && !colliding)
        {
            transform.position += transform.up * Time.deltaTime * m_Speed;
            if(Vector3.Distance(initialPos, transform.position) >15)
            {
               // gameObject.transform.parent = null;

               
                 if(parent.transform.childCount==0 && !gm.levelCompleted.activeSelf )
                {
                    gm.levelCompleted.SetActive(true);
                    int l= PlayerPrefs.GetInt("level");
                    PlayerPrefs.SetInt("level", l + 1);
                }
                Destroy(this.gameObject);

            }
        }
        // Vector3 rayEndPoint = transform.position + transform.up * 10;
        //Debug.DrawLine(transform.position, rayEndPoint, Color.green);
    }


  /*  private void FixedUpdate()
    {
        if (Physics.Raycast(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), transform.up, out hit, detectionRange))
        {

            if(hit.collider.gameObject!=gameObject)
            {
                if (hit.collider.CompareTag("rocket"))
                {
                    colliding = true;
                    moving = false;
                    GameObject rocket = hit.collider.gameObject;
                    Vector3 pushDirection = DeterminePushDirection(hit.collider.gameObject);
                    // Debug.Log(pushDirection);
                    Vector3 defaultPos = rocket.transform.position;
                    Vector3 pos = rocket.transform.position + pushDirection * 0.05f;

                    rocket.transform.DOMove(pos, 0.2f).OnComplete(() =>
                    {
                        rocket.transform.DOMove(defaultPos, 0.2f);


                        // Add your logic here for when another rocket is detected
                    });
                }
                else
                {
                    colliding = false;
                }


            }
            

            // Check if the hit object has the tag "Rocket"

        }
      

        //Debug.DrawLine(new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y, transform.localPosition.z), hit.point, Color.red);
    }*/
    

    public void Shoot()
    {
        GetComponent<CapsuleCollider>().isTrigger = false;
        moving = true;
    }

    public void Stop()
    {
        gm.rocketLaunch.Stop();
        gm.rocketCollide.Play();
        moving = false;

        transform.SetParent(parent.transform);
        GetComponent<CapsuleCollider>().isTrigger = true;
        Vector3 pos = transform.position - transform.up * 0.3f;
        transform.position = pos;
      //  GetComponent<Rigidbody>().isKinematic = false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
    GameObject rocket = collision.gameObject;
        if (rocket.CompareTag("rocket") && moving)
        {
            Stop();
           
           // GetComponent<Rigidbody>().isKinematic = true;
            
          Vector3 pushDirection = DeterminePushDirection( gameObject);
                // Debug.Log(pushDirection);
                Vector3 defaultPos = rocket.transform.position;
          
        /*    rocket.transform.DOMove(pos, 0.2f).OnComplete(() => {
                rocket.transform.DOMove(defaultPos, 0.2f)
.OnComplete(() => {  });
                ;

                
            });*/

               
           
        }
        
       /* else if (balloon.CompareTag("dart"))
        {
            Stop();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject rocket = other.gameObject;
        if (rocket.CompareTag("rocket") && moving)
        {
            Stop();

            // GetComponent<Rigidbody>().isKinematic = true;
            if(!push)
            {
                Vector3 pushDirection = DeterminePushDirection(rocket);
                // Debug.Log(pushDirection);
                Vector3 defaultPos = rocket.transform.position;
                Vector3 pos = rocket.transform.position + pushDirection * 0.05f;

                rocket.transform.DOMove(pos, 0.1f).OnComplete(() => {
                    rocket.transform.DOMove(defaultPos, 0.1f)
                    .OnComplete(() => { push = false; });
                    ;
                    
                });
            }
        



        }
    }

    private Vector3 DeterminePushDirection(GameObject balloon)
    {
        Vector3 pushDirection = transform.position - balloon.transform.position;
        pushDirection = pushDirection.normalized;
        // Since we want to push Object B strictly in up, down, left, or right directions,
        // we zero out the smaller component of the vector (either x or z) to ensure movement
        // is constrained to one axis.
        if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.y))
        {
            pushDirection.y = 0;
            //pushDirection.x = 0.1f;

        }
        else
        {
            pushDirection.x = 0;
            // pushDirection.z = 0.1f;

        }
        pushDirection.z = 0;
        return pushDirection;
    }
}
