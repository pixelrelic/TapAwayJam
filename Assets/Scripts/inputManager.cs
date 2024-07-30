using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    public rocketManager gm;
    GameObject rockets;
    private void Awake()
    {
        rockets = GameObject.FindGameObjectWithTag("rockets");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
              //  if (gm.moves > 0)
             //   {//Select stage    
                    if (hit.transform.gameObject.CompareTag("rocket"))
                    {

                        hit.transform.gameObject.GetComponent<moveRockets>().Shoot();
                        hit.transform.GetChild(0).GetComponent<AudioSource>().Play();
                       //gm.tap.Play();
                      /*  hit.transform.parent = null;

                        gm.moves -= 1;
                        gm.moves_UI.text = gm.moves.ToString() + " " + "Moves";

                        if(gm.moves ==0 && rockets.transform.childCount >0)
                        {

                            gm.levelRestarted.SetActive(true);
                        }*/


                    }
               // }
            }
        }
    }
}
