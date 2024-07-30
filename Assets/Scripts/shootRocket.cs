using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class shootRocket : MonoBehaviour
{
    public rocketManager rm;
    public Transform target; // The target that the missile will follow
    public float speed = 5f; // The speed of the missile
    public float rotateSpeed = 200f; // The rotation speed of the missile
    public string color;
    public  bool move =true;
    int mySlot = 0;
    bool newTarget=false;
    private Rigidbody rb;
    bool closeToTarget = false;
    GameObject block;


    private void Awake()
    {
        
        rm = GameObject.FindGameObjectWithTag("manager").GetComponent<rocketManager>();
        rb = GetComponent<Rigidbody>();
        //
    }
    void Start()
    {   
        if(CustomEffectsManager.instance != null)
        {
            CustomEffectsManager.instance.PlayRocketMovingEffect();
        }
        

        if(rm.currentPupilLook != null)
        {
            rm.currentPupilLook.SetTarget(this.gameObject.transform);
        }
        

        rm.tappedRocket.Add(this.gameObject);
        block = rm.currentBlock;
        //  if (rm.calOpenSlot() == -1)
        // {
        //    move = false;
        //}

        //else
        //{

        if (rm.calOpenSlot() == -1)
        {
            move = false;

            GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            setTarget();
           /* if (rm.currentBlock.name == color)
            {
                target = rm.currentBlock.transform;
            }
            else
            {
                int slotInt = rm.calOpenSlot();
                if (slotInt != -1)
                {
                    target = rm.slots.transform.GetChild(slotInt).gameObject.transform;
                    transform.SetParent(target);
                    mySlot = slotInt;
                }


            }*/
        }
        
       // target = GameObject.Find(color).transform;
        // Calculate the initial direction towards the target and apply force
        if(target!=null)
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            rb.velocity = directionToTarget * speed;
        }

     

       // }
        // GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
       /* if(Vector3.Distance(target.position,transform.position)<1f)
        {
            closeToTarget = true;
            rb.isKinematic = true;
            Vector3 direction = target.position - transform.position;
            Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
            transform.position += moveVector;

            // Rotate the object to face the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }*/
    }


    void FixedUpdate()
    {
       /* if (Vector3.Distance(target.position, transform.position) < 1.5f && move)
        {
            closeToTarget = true;
            Vector3 direction = target.position - transform.position;
            Vector3 moveVector = direction.normalized * 5f;
            rb.MovePosition(rb.position + moveVector * Time.fixedDeltaTime);

            // Rotate the object to face the target using Rigidbody
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
        }*/

        if (!closeToTarget)

        {

            if (target != null && move && newTarget != true)
            {
                // Calculate the new direction towards the target each frame
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                // Calculate the rotation to the target direction
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

                // Rotate the missile towards the target direction
                rb.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

                // Move the missile forward along its new forward vector
                rb.velocity = transform.forward * speed;
            }
            else if (target == null )
            {

                int slotInt = rm.calOpenSlot();
                if(slotInt!=-1)
                {
                    target = rm.slots.transform.GetChild(slotInt).gameObject.transform;
                    transform.SetParent(target);
                    rotateSpeed = 280;
                    mySlot = slotInt;
                    newTarget = true;
                }
      
            }
            if (target != null && newTarget )
            {
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                // Calculate the rotation to the target direction
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                rb.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
                rb.velocity = transform.forward * 5;
            }
        }
    }


    public void setTarget()
    {
        if (rm.currentBlock != null && rm.currentBlock.name == color  )
        {
           
            target = rm.currentBlock.transform;
        }
        else
        {
            int slotInt = rm.calOpenSlot();
            if (slotInt != -1)
            {
                target = rm.slots.transform.GetChild(slotInt).gameObject.transform;
                transform.SetParent(target);
                mySlot = slotInt;
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name ==color)
        {   
            GetComponent<CapsuleCollider>().enabled = false;
            rm.tappedRocket.Remove(this.gameObject);
            rm.tap.Play();

            if(other.transform.GetComponent<goals>().count>1)
            {

               BlockHit hitScript = other.GetComponent<BlockHit>();
                if(hitScript != null)
                {
                    hitScript.PlayHitEffect();
                }
                if (rm.currentPupilLook != null)
                {
                    rm.currentPupilLook.SetTarget(Camera.main.transform);
                }

                Vector3 currentScale = other.transform.localScale;

     

            }
 
            
       
            other.transform.GetComponent<goals>().count--;
            
          other.transform.GetChild(0).GetComponent<TextMeshPro>().text = other.transform.GetComponent<goals>().count.ToString();
            if(other.transform.GetComponent<goals>().count==0)
            {
                //TODO : add Block destory effect here
                if(CustomEffectsManager.instance!=null)
                {
                    CustomEffectsManager.instance.PlayBlockDestroyEffect();
                }
                
                GameObject brokenParts = other.transform.GetChild(1).gameObject;
                brokenParts.gameObject.SetActive(true);
                brokenParts.transform.SetParent(null);
                Destroy(brokenParts, 2f);
                Destroy(other.gameObject);
                rm.blockDestroy.Play();

             
                    rm.OnCurBlockDestroy();
               
               
            }
            else
            {
                //rocket collided with block
                //TODO : add screenshake here
                if (CustomEffectsManager.instance != null)
                {
                    CustomEffectsManager.instance.PlayBlockHitEffect();
                }
            }
            Destroy(this.gameObject);

            

        }
        if(other.gameObject.name  =="Slot"+mySlot.ToString() && target !=null && target == rm.slots.transform.GetChild(mySlot).gameObject.transform)
        {   
            if(CustomEffectsManager.instance != null)
            {
                CustomEffectsManager.instance.PlayRocketLandedInSlotEffect();
            }
            


            rm.tappedRocket.Remove(this.gameObject);
            // if (transform.parent == null)
            transform.parent = rm.slots.transform.GetChild(mySlot).gameObject.transform;
            //rm.curSlot++;
            rb.isKinematic = true;
            move = false;


            transform.DOLocalMove(new Vector3(0, -0.58f, -0.5f), 0.2f)
                
              ;
            transform.DORotate(Vector3.zero, 0.2f).OnComplete(() => {


              

                 if(mySlot == rm.slots.transform.childCount-1 )
                {
                    
                    //rm.pause = true;
                    rm.levelFailed();
                }
               /* int val = rm.calOpenSlot();
                if (val == -1)
                {
                    
                }*/
            });


            if (newTarget)
                newTarget = false;

           
        }
    }
}
