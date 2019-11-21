using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRetrieval : MonoBehaviour
{
    private Transform playerPosition;
    public float distance = 2;
    public float points = 5;

  
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("FPSController").transform;
        //distance = 2;
        //points = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerPosition.position, this.transform.position);
        if(dist <= distance)
        {
            Debug.Log("Distance is" + dist);

            //TODO: show an indication like "press e to fetch"
            
                this.gameObject.SetActive(false);
            //PlayerStats.Hunger += points;
                print("Hunger value +" + points);
            }
        }
    }

