using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
     
    public GameObject current = null;
    public InteractionObject currentScript = null;
    public Inventory inventory;
    public GameObject bt;
    public BlueTurtle bt_script;

    private void Awake()
    {
        bt = GameObject.FindGameObjectWithTag("enemy");
        bt_script = bt.GetComponent<BlueTurtle>();
        bt_script.SendMessage("AddObserver", this);
    }
    public void Update()
    {
		if (Input.GetButtonDown("interact") && current)
        {
            if (currentScript.inventoried)
            {
                inventory.Additem(current);
            }
        }
        try
        {
            if (Input.GetButtonDown("UseBomb"))
            {
                GameObject bomb = inventory.FindItem("Bomb");
                if (bomb != null)
                {
                    inventory.RemoveItem(bomb);
                    Transform pos = GameObject.FindGameObjectWithTag("Player").transform;
                    float x = pos.position.x;
                    float y = pos.position.y;
                    float z = pos.position.z;
                    currentScript = bomb.GetComponent<InteractionObject>();
                    currentScript.DoAnotherAction(x, y, z);
                }
            }
        }
        catch (System.NullReferenceException e)
        {

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

    public void UpdateState()
    {
        this.gameObject.SetActive(false);
    }
}
