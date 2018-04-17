using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTurtle : MonoBehaviour, IMonster {

	private int health = 1;
	private int speed = 1;
	private int step = 0;
	private MovePattern m;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Move();
	}

	public int Health {
		get {
			return health;
		}
		set {
			this.health = value;
		}
	}

	public int Speed {
		get {
			return speed;
		}
		set {
			this.speed = value;
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
}
