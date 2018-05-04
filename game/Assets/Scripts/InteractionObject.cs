using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventoried;
    public string type;
    int bt_id = 0, rt_id = 0, goomba_id = 0;
    int bt_clone_id = -1, rt_clone_id = -1, goomba_clone_id = -1;
    public GameObject bt_clone, goomba_clone, rt_clone;
    public IMonster bt_script, goomba_script, rt_script;

    public void Update()
    {
        try
        {
            bt_clone = GameObject.FindGameObjectWithTag("enemy");
            bt_clone_id = bt_clone.GetInstanceID();
            if (bt_id != bt_clone_id)
            {
                bt_script = bt_clone.GetComponent<IMonster>();
                bt_script.AddObserver(this);
                bt_id = bt_clone_id;
            }
        }
        catch { }
        try
        {
            goomba_clone = GameObject.FindGameObjectWithTag("enemy_goomba");
            goomba_clone_id = goomba_clone.GetInstanceID();
            if (goomba_id != goomba_clone_id)
            {
                goomba_script = goomba_clone.GetComponent<IMonster>();
                goomba_script.AddObserver(this);
                goomba_id = goomba_clone_id;
            }
        }
        catch { }
        try
        {
            rt_clone = GameObject.FindGameObjectWithTag("enemy_rt");
            rt_clone_id = rt_clone.GetInstanceID();
            if (rt_id != rt_clone_id)
            {
                rt_script = rt_clone.GetComponent<IMonster>();
                rt_script.AddObserver(this);
                rt_id = rt_clone_id;
            }
        }
        catch { }
    }

    public void DoAction()
    {
        //gameObject.GetComponent<Renderer>().enabled = false;
    }

	public void DoAnotherAction(Vector3 position)
    {
		//gameObject.transform.position = position;
        //gameObject.GetComponent<Renderer>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            if (collision.CompareTag("enemy") || collision.CompareTag("enemy_rt") ||
                collision.CompareTag("enemy_goomba") || collision.CompareTag("boss"))
            {
                IMonster monster = collision.gameObject.GetComponent<IMonster>();
                monster.TakeDamage();
                monster.TakeDamage();
                monster.ObserveHP();
            }
        }
    }

    public void UpdateState()
    {
        this.gameObject.SetActive(false);
    }
}
