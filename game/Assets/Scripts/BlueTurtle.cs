using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTurtle : MonoBehaviour, IMonster {

	public static float DEFAULT_SPEED = 1;

	private int health = 5;
	private float speed = DEFAULT_SPEED;
	private int step = 0;
	private MovePattern m;
    public List<MonoBehaviour> observers = new List<MonoBehaviour>();

    public void AddObserver(MonoBehaviour observer)
    {
        Debug.Log("In AddObserver");
        observers.Add(observer);
    }
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Move();
		ObserveHP ();
	}

	public int Health {
		get {
			return health;
		}
		set {
			this.health = value;
		}
	}

	public float Speed {
		get {
			return speed;
		}
		set {
			if (value == DEFAULT_SPEED / 2 || value == DEFAULT_SPEED) {
				this.speed = value;
			}
		}
	}

	public int Step {
		get {
			return step;
		}
		set {
			this.step = value;
		}
	}

	public void Move() {
		if (m == null) {
			m = MovePattern.getInstance();
		} else {
			m.Move (this);
		}
	}

	public void ObserveHP() {
		if (this.Health == 0) {
			Destroy (this.gameObject);
		}
	}

    public void Attack()
    {

    }

    public void NotifyAll()
    {
        Debug.Log("In NotifyAll");
        foreach (MonoBehaviour observer in observers)
        {
            observer.SendMessage("UpdateState");
        }
    }
}
