using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];

    public void Additem(GameObject item)
    {
        bool itemAdded = false;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                itemAdded = true;
                item.SendMessage("DoAction");
                break;
            }
        }
        if (!itemAdded)
        {
            Debug.Log("Item not added");
        }
    }
}
