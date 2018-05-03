using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
    public string type;
    public int damage;
    int bt_id = 0;
    int bt_clone_id = -1;
    public GameObject bt_clone;
    public BlueTurtle bt_script;

    public void Update()
    {
        try
        {
            bt_clone = GameObject.FindGameObjectWithTag("enemy");
            bt_clone_id = bt_clone.GetInstanceID();
        }
        catch { }
        if (bt_id != bt_clone_id)
        {
            bt_script = bt_clone.GetComponent<BlueTurtle>();
            bt_script.SendMessage("AddObserver", this);
            bt_id = bt_clone_id;
        }
    }

    public void DoAction()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

	public void DoAnotherAction(Vector3 position)
    {
		gameObject.transform.position = position;
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("enemy"))
            {
                collision.GetComponent<BlueTurtle>().SendMessage("TakeDamage");
                Destroy(gameObject);
            }
        }
    }

    public void UpdateState()
    {
        this.gameObject.SetActive(false);
    }
}
