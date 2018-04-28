using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	
	public Rigidbody projectile;
	public float fireRate;
	public float speed;
	public float spawnDistance;

	private float nextFire;
	private GameObject playerObject;
	private Transform player;
	private Vector3 spawnPosition;
	private Rigidbody fireball;

	void Start () {
		player = GetComponent<Transform>();
		playerObject = GameObject.Find("Bowser Jr.");
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
			Vector3 pos = player.position;
			string direction = ((Hero)playerObject.GetComponent<Hero>()).getDirection();

			// TODO: Fix up/down AND left/right to shoot left/right
			// TODO: Add code to collide with and damage enemy
			// TODO: Destroy fireball objects once they leave the game area
			// TODO: Refactor similar code below to a method
			if (direction.Contains("up")) {
				spawnPosition = pos + Vector3.up * spawnDistance;
				fireball = Instantiate(projectile, spawnPosition, player.rotation) as Rigidbody;
				fireball.velocity = transform.TransformDirection(Vector3.up * speed);
			} else if (direction.Contains("down")) {
				spawnPosition = pos + Vector3.down * spawnDistance;
				fireball = Instantiate(projectile, spawnPosition, player.rotation) as Rigidbody;
				fireball.velocity = transform.TransformDirection(Vector3.down * speed);
			} else if (direction.Contains("left")) {
				spawnPosition = pos + Vector3.left * spawnDistance;
				fireball = Instantiate(projectile, spawnPosition, player.rotation) as Rigidbody;
				fireball.velocity = transform.TransformDirection(Vector3.left * speed);
			} else if (direction.Equals("right")) {
				spawnPosition = pos + Vector3.right * spawnDistance;
				fireball = Instantiate(projectile, spawnPosition, player.rotation) as Rigidbody;
				fireball.velocity = transform.TransformDirection(Vector3.right * speed);
			}
			nextFire = Time.time + fireRate;
		}
	}
}
