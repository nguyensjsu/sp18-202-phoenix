using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour, IMonster {

	public static float DEFAULT_SPEED = 1;
	protected float speed;
	protected int step = 0;
	protected int route = 0;
	protected bool win;

	public float Speed { 
		get { return speed; }
		set { this.speed = value; }
	}

	public int Step {
		get { return step; }
		set { this.step = value; }
	}

	public int Route {
		get { return route; }
		set { this.route = value; }
	}

	public abstract void Move();

    public void ObserveHP()
    {

    }


    public void TakeDamage() {

	}
}
