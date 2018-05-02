using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour {

	private Animator animator;
	private GameObject player;
	private float moveSpeed;
	private bool win;

	void Awake() {
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		moveSpeed = 1;
		win = false;
	}

	void Update () {
		if (!win) {
			Move(player.transform.position);
		}
	}

	void Move(Vector3 playerPosition) {
		if (playerPosition.x < transform.position.x && transform.rotation.eulerAngles.y != 180f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		} else if (playerPosition.x > transform.position.x && transform.rotation.eulerAngles.y != 0f) {
			transform.RotateAround(transform.position, transform.up, 180f);
		}

		transform.position = Vector2.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
	}

	// TODO: Have bowser jr. sprite show that he dies by getting on the ground
	// TODO: Have all bosses show their celebration when player loses
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player")) {
			win = true;
			animator.Play("boss_win");
		} else if (coll.gameObject.CompareTag("fireball")) {
			// TODO: take damage
		}
	}
}
