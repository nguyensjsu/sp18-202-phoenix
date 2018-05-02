using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luigi : Boss {

	private Animator animator;
	private Vector3 playerPosition;
	private GameObject player;

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

	// TODO: Fix sporadic fast movement
	public override void Move() {
		if (playerPosition.x < transform.position.x && transform.rotation.eulerAngles.y != 180f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		} else if (playerPosition.x > transform.position.x && transform.rotation.eulerAngles.y != 0f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		}

		transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("fireball")) {
			gameObject.SetActive(false);
		} else if (coll.gameObject.CompareTag("Player")) {
			BossWin();
			GameObject mario = GameObject.Find("Mario(Clone)");
			mario.GetComponent<Mario>().BossWin();
		}
	}

	public void BossWin() {
		win = true;
		animator.Play("luigi_win");
	}
}
