using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
    public string type;
    public int damage;
    public GameObject bt;
    int bt_id = 0;
    int bt_clone_id = -1;
    public GameObject bt_clone;
    public BlueTurtle bt_script;

    public void Update()
    {
        try
        {
            bt_clone = GameObject.FindGameObjectWithTag("enemy");
        }
        catch { }
        bt_clone_id = bt_clone.GetInstanceID();
        if (bt_id != bt_clone_id)
        {
            bt_script = bt_clone.GetComponent<BlueTurtle>();
            bt_script.SendMessage("AddObserver", this);
            bt_id = bt_clone_id;
        }
    }

        public void DoAction()
    {
        gameObject.SetActive(false);
    }

	public void DoAnotherAction(Vector3 position)
    {
		gameObject.transform.position = position;
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("enemy"))
            {
                EnemyInteraction currentScript = collision.GetComponent<EnemyInteraction>();
                currentScript.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                //Bomb currentBombScript = gameObject.GetComponent<Bomb>();
                //currentBombScript.SendMessage("Boom",SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }
        }
    }

    public void UpdateState()
    {
        this.gameObject.SetActive(false);
    }
}
