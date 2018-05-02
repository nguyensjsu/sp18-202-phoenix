using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
     
    public GameObject current = null;
    public InteractionObject currentScript = null;
    public Inventory inventory;
    public GameObject bt;
    int bt_id = 0;
    int bt_clone_id;
    public GameObject bt_clone;
    public BlueTurtle bt_script;

    private void Awake()
    {
        bt = GameObject.FindGameObjectWithTag("enemy");
        bt_id = bt.GetInstanceID();
        bt_script = bt.GetComponent<BlueTurtle>();
        bt_script.SendMessage("AddObserver", this);        
    }
    public void Update()
    {
        bt_clone = GameObject.FindGameObjectWithTag("enemy");
        bt_clone_id = bt_clone.GetInstanceID();
        if (bt_id != bt_clone_id)
        {
            bt_script = bt_clone.GetComponent<BlueTurtle>();
            bt_script.SendMessage("AddObserver", this);
            bt_id = bt_clone_id;
        }
        

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
					GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
					Vector3 pos = playerObject.transform.position;

					string direction = ((Hero)playerObject.GetComponent<Hero>()).getDirection();

					switch(direction) {
					case "up":
						pos += Vector3.up;
						break;
					case "down":
						pos += Vector3.down;
						break;
					case "left":
						pos += Vector3.left;
						break;
					case "right":
						pos += Vector3.right;
						break;
					}

                    currentScript = bomb.GetComponent<InteractionObject>();
					currentScript.DoAnotherAction(pos);
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
