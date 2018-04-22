using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
     
    public GameObject current = null;
    public InteractionObject currentScript = null;
    public Inventory inventory;

    public void Update()
    {
		if (Input.GetButtonDown("interact") && current)
        {
            if (currentScript.inventoried)
            {
                inventory.Additem(current);
            }
        }
        if (Input.GetButtonDown("UseBomb"))
        {
            GameObject bomb = inventory.FindItem("Bomb");
            if (bomb != null)
            {
                Transform pos = GameObject.FindGameObjectWithTag("Player").transform;
                float x = pos.position.x;
                float y = pos.position.y;
                float z = pos.position.z;
                currentScript = bomb.GetComponent<InteractionObject>();
                currentScript.DoAnotherAction(x,y,z);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("iterObj"))
        {
            current = other.gameObject;
            currentScript = current.GetComponent<InteractionObject>();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("iterObj"))
        {
            if (other.gameObject == current)
            {
                current = null;
            }
        }
    }
}
