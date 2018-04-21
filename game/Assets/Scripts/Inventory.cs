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

    public GameObject FindItem(string type)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].GetComponent<InteractionObject>().type == type)
                {
                    return inventory[i];
                }
            }
        }
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i] == item)
                {
                    inventory[i] = null;
                    break;
                }
            }
        }
    }
}
