using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveRockets : MonoBehaviour
{

    public GameObject othergesture;
    [SerializeField] float m_Speed = 100f;

   public bool moving = false;
    RaycastHit hit;
    public float detectionRange = 10f;
    public bool colliding;
    bool push;
    float distance;
    Vector3 initialPos;
    gameManager gm;
    public bool moveEffect = false;
    rocketManager rm;
    bool handleInput = true;
    // Start is called before the first frame update

    private void Awake()
    {
        rm = GameObject.FindGameObjectWithTag("manager").GetComponent<rocketManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving )
        {
            transform.position += transform.up * Time.deltaTime * m_Speed;
           /* if (Vector3.Distance(initialPos, transform.position) > 15)
            {
                // gameObject.transform.parent = null;


                if (parent.transform.childCount == 0 && !gm.levelCompleted.activeSelf)
                {
                    gm.levelCompleted.SetActive(true);
                    int l = PlayerPrefs.GetInt("level");
                    PlayerPrefs.SetInt("level", l + 1);
                }
                Destroy(this.gameObject);

            }*/
        }
    }

    public void Shoot()
    {   
        if(handleInput)
        {
            // GetComponent<CapsuleCollider>().isTrigger = false;
            moving = true;
            moveEffect = true;
            if (othergesture != null)
            {
                
                transform.GetChild(1).gameObject.SetActive(false);
                othergesture.SetActive(true);
                Debug.Log("Gesture");
            }
            //GetComponent<AudioSource>().Play();
            handleInput = false;
        }

    }

    private bool ApproximatelyEqual(float a, float b)
    {
        float epsilon = 0.001f; // Set a very small value for epsilon
        return Mathf.Abs(a - b) < epsilon;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="rocket" && moving && !other.transform.GetComponent<moveRockets>().moving)
        {
            // rm.beep.Play();
            StartCoroutine(StartHandlingInput());
            //Rocket wobble effect :
            //Debug.Log("Wobble "+ other.name +" rocket");
            WobbleRocketWhenCollided wobbleScript = other.gameObject.GetComponent<WobbleRocketWhenCollided>();
            if(wobbleScript != null)
            {
                wobbleScript.WobbleInDirection(transform.TransformDirection(transform.forward));
            }
                moving = false;
           
            
           // moveEffect = false;
            Vector3 pos1 = other.transform.position;
            Vector3 pos2 = transform.position;

            Debug.Log("Pos1" + pos1);
            Debug.Log("Pos2" + pos2);
            //   if(pos1.x ==pos2.x)
            if (ApproximatelyEqual(pos1.x, pos2.x))
            {
                if(pos2.z<pos1.z)
                {
                    transform.position = new Vector3(pos1.x, pos1.y, pos1.z - 0.650f);
                   
                }
                else
                {
                    transform.position = new Vector3(pos1.x, pos1.y, pos1.z + 0.650f);
                    
                }    
                
            }
            else
            {
                if(pos2.x< pos1.x)
                {
                    //transform.position = new Vector3(pos1.x - 0.650f, pos1.y, pos1.z);
                    transform.position = new Vector3(Mathf.Round((pos1.x - 0.65f )* 100.0f) / 100.0f , pos1.y, pos1.z);
                   
                }
                else
                {
                    transform.position = new Vector3(
                        Mathf.Round((pos1.x + 0.65f )* 100.0f) / 100.0f

                        , pos1.y, pos1.z);
                   
                }
            }
          //  moveEffect = false;

        }
  /*  else if(other.transform.tag == "rocket" && !moving && other.transform.GetComponent<moveRockets>().moveEffect )
        {

            if(other.transform.GetComponent<moveRockets>().moveEffect)
            {
                other.transform.GetComponent<moveRockets>().moveEffect = false;
            }
            
            moveEffect = true;
            Vector3 pos2 = other.transform.position;
            Vector3 pos1 = transform.position;
            
            

            //   if(pos1.x ==pos2.x)
            if (ApproximatelyEqual(pos1.x, pos2.x))
            {
                float z = transform.localPosition.z;
                if (pos2.z < pos1.z )
                {
                   
                    transform.DOLocalMoveZ(z +0.15f, 0.05f).
                        OnComplete(() => {
                            GetComponent<BoxCollider>().enabled = false;
                            transform.DOLocalMoveZ(z, 0.05f).OnComplete(() => {
                                GetComponent<BoxCollider>().enabled = true;
                              //  moveEffect = false; 

                            });

                        });
                }
                else if(pos2.z > pos1.z )
                {
                    Debug.Log(gameObject.name);
                   
                   
                }

            }
            else
            {
                float x = transform.localPosition.x;

                if (pos2.x < pos1.x)
                {
                    transform.DOLocalMoveX(x + 0.15f, 0.05f).
             OnComplete(() => {
                 GetComponent<BoxCollider>().enabled = false;
                 transform.DOLocalMoveX(x, 0.05f).OnComplete(() => {
                     GetComponent<BoxCollider>().enabled = true;
                   
                 });

             });
                }
                else
                {

         
                }
            }
        }*/
    }


    private Vector3 DeterminePushDirection(Collision collision, GameObject balloon)
    {
        Vector3 pushDirection = transform.position - balloon.transform.position;
        pushDirection = pushDirection.normalized;
        // Since we want to push Object B strictly in up, down, left, or right directions,
        // we zero out the smaller component of the vector (either x or z) to ensure movement
        // is constrained to one axis.
        if (Mathf.Abs(pushDirection.x) > Mathf.Abs(pushDirection.z))
        {
            pushDirection.z = 0;
            //pushDirection.x = 0.1f;

        }
        else
        {
            pushDirection.x = 0;
            // pushDirection.z = 0.1f;

        }
        pushDirection.y = 0;
        return pushDirection;
    }


    IEnumerator StartHandlingInput()
    {
        yield return new WaitForSeconds(0.2f);
        handleInput = true;
    }
}
