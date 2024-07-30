using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genSlots : MonoBehaviour
{
    rocketManager rm;
     GameObject slots;
     GameObject lockedSlot10;
     GameObject lockedSlot40;
    float x = -1.95f;

     void Awake()
    {
        rm = GameObject.FindGameObjectWithTag("manager").GetComponent<rocketManager>();
        slots = rm.slotItem;
        lockedSlot10 = rm.lockedSlot10;
        lockedSlot40 = rm.lockedSlot40;
        int level = PlayerPrefs.GetInt("Level")+1;

        // Test Code //
       /* int c = 7;
        for (int i = 0; i < c; i++)
        {
            GameObject slot = Instantiate(slots, new Vector3(x, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
            slot.transform.localPosition = new Vector3(x, 0, 2.5f);
            slot.name = "Slot" + i.ToString();
            x += 0.65f;
        }*/
        // End//
      //  rm.curnewSlot = 7;
      if (level > 9 && level <40)
         {
             int c = 6;
             for(int i =0;i<c;i++)
             {
                 GameObject slot = Instantiate(slots, new Vector3(x, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
                 slot.transform.localPosition = new Vector3(x, 0, 2.5f);
                 slot.name = "Slot" + i.ToString();
                 x += 0.65f;
             }
             GameObject lockedSlot = Instantiate(lockedSlot40, new Vector3(1.95f, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
            lockedSlot.transform.localPosition = new Vector3(1.95f, 0, 2.5f);
            lockedSlot.transform.SetParent(null);
            rm.curnewSlot = 6;
        }
         else if(level>39)
         {
             int c = 7;
             for (int i = 0; i < c; i++)
             {
                 GameObject slot = Instantiate(slots, new Vector3(x, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
                 slot.transform.localPosition = new Vector3(x, 0, 2.5f);
                 slot.name = "Slot" + i.ToString();
                 x += 0.65f;
             }
            rm.curnewSlot = 7;

        }
        else
         {
             int c = 5;
             x = -1.3f;
             for (int i = 0; i < c; i++)
             {
                 GameObject slot = Instantiate(slots, new Vector3(x, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
                 slot.transform.localPosition = new Vector3(x, 0, 2.5f);
                 slot.name = "Slot" + i.ToString();
                 x += 0.65f;
             }
           /*  GameObject lockedSlot1 = Instantiate(lockedSlot10, new Vector3(-1.95f, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
            lockedSlot1.transform.localPosition = new Vector3(-1.95f, 0, 2.5f);
             lockedSlot1.transform.SetParent(null);
             GameObject lockedSlot2 = Instantiate(lockedSlot40, new Vector3(1.95f, 0, 2.5f), Quaternion.Euler(90, 0, 0), transform);
            lockedSlot2.transform.localPosition = new Vector3(1.95f, 0, 2.5f);
            lockedSlot2.transform.SetParent(null);*/
            rm.curnewSlot = 5;

        }

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
