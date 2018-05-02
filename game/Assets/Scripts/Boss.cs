using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IMonster {

	public static float DEFAULT_SPEED = 1;
	private Animator animator;
	private GameObject player;
	private Vector3 playerPosition;
	private float speed;
	private int step = 0;
	private int route = 0;
	private bool win;

	void Awake() {
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		speed = DEFAULT_SPEED;
		win = false;
	}

	void Update () {
		if (!win) {
			playerPosition = player.transform.position;
			Move();
		}
	}

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

	public void Move() {
		//Vector3 playerPosition = player.transform.position;
		if (playerPosition.x < transform.position.x && transform.rotation.eulerAngles.y != 180f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		} else if (playerPosition.x > transform.position.x && transform.rotation.eulerAngles.y != 0f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		}

		transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
	}

	public void TakeDamage() {

	}

	// TODO: Have all bosses show their celebration when player loses
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("fireball")) {
			gameObject.SetActive(false);

		} else if (coll.gameObject.CompareTag("Player")) {
			win = true;
			animator.Play("boss_win");
		} else if (coll.gameObject.CompareTag("fireball")) {
			// TODO: take damage
		}
	}
}
