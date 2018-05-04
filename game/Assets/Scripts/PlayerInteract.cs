using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
     
    public GameObject current = null;
    public InteractionObject currentScript = null;
    public Inventory inventory;
    int bt_id = 0, rt_id = 0, goomba_id = 0;
    int bt_clone_id = -1, rt_clone_id = -1, goomba_clone_id = -1;
    public GameObject bt_clone, goomba_clone, rt_clone;
    public IMonster bt_script, goomba_script, rt_script;

    public int numberOfBombs = 0;
    public int numberOfFireBalls = 0;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
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
        

        if (Input.GetButtonDown("interact") && current)
        {
            string item = current.name;
            if (item.Contains("bomb"))
            {
                numberOfBombs += 1;
            }
            else if (item.Contains("fire"))
            {
                numberOfFireBalls += 5;
            }
            Destroy(current.gameObject);
        }
        try
        {
            if (Input.GetButtonDown("UseBomb"))
            {
                if (numberOfBombs > 0)
                {
                    numberOfBombs--;
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
                    pos.z = -1;
                    Instantiate(Resources.Load("bomb_activated"), pos, Quaternion.identity);

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
            //currentScript = current.GetComponent<InteractionObject>();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("iterObj"))
        {
            if (other.gameObject == current)
            {
                current = null;
                //currentScript = null;
            }
        }
    }

    public void UpdateState()
    {
        this.gameObject.SetActive(false);
    }
}
