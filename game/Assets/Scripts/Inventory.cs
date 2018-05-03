using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    
    public List<GameObject> inventory = new List<GameObject>();
    int count = 0;
    GameObject canvasObj;
    Transform textTr;
    public Text bomb_count;

    public void Additem(GameObject item)
    {
        inventory.Add(item);
        count += 1;
        item.SendMessage("DoAction");
    }

    private void Awake()
    {
        canvasObj = GameObject.FindGameObjectWithTag("MainCanvas");
        textTr = canvasObj.transform.Find("Bomb Count");
        bomb_count = textTr.GetComponent<Text>();
    }

    public void Update()
    {
        bomb_count.text = "Bomb Count : " + count;
    }

    public GameObject FindItem(string type)
    {
        try
        {
            for (int i = 0; i < inventory.Capacity; i++)
            {
                if (inventory[i] != null)
                {
                    if (inventory[i].GetComponent<InteractionObject>().type == type)
                    {
                        return inventory[i];
                    }
                }
            }
        }
        catch { }
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        count -= 1;
        inventory.Remove(item);
    }
}
