using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
    public string type;
    public int damage;
    public GameObject bt;
    public BlueTurtle bt_script;

    void Awake()
    {
        bt = GameObject.FindGameObjectWithTag("enemy");
        bt_script = bt.GetComponent<BlueTurtle>();
        bt_script.SendMessage("AddObserver", this);
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
