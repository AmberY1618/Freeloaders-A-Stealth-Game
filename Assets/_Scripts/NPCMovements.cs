using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    public float moveSpeed = 1;

    private bool kitchenStartToEnd = true;
    Vector3 kitchenStartPoint = new Vector3(-4, 0, -4.5f);
    Vector3 kitchenEndPoint = new Vector3(-4, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        walkInKitchen();
    }

    //the movement of NPC moving in the kitchen
    void walkInKitchen()
    {
        if (kitchenStartToEnd && transform.position != kitchenStartPoint)
        {
            Debug.Log("moving to start");
            transform.position = Vector3.MoveTowards(this.transform.position, kitchenStartPoint, moveSpeed * Time.deltaTime);
        }
        else if (!kitchenStartToEnd && transform.position != kitchenStartPoint)
        {
            Debug.Log("moving to end");
            transform.position = Vector3.MoveTowards(this.transform.position, kitchenEndPoint, moveSpeed * Time.deltaTime);
        }
        else if (kitchenStartToEnd && transform.position == kitchenEndPoint)
        {
            Debug.Log("setting false");
            kitchenStartToEnd = false;
        }
        else if (!kitchenStartToEnd && transform.position == kitchenStartPoint)
        {
            Debug.Log("setting true");
            kitchenStartToEnd = true;
        }
        Debug.Log("current position is " + transform.position);
        

    }

    //tell the program to wait for i sec
    IEnumerator waitsec(int i)
    {
        moveSpeed = 0;
        yield return new WaitForSeconds(i);
    }
}
