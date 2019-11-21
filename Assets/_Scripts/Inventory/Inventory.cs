using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update


    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    void Start()
    {
        allSlots = 12;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            inventoryEnabled = !inventoryEnabled;

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
