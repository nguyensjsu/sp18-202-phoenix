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

	void Start () {
		playerObject = GameObject.Find("Bowser Jr.");
		player = GetComponent<Transform>();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
			Vector3 position = player.position;
			Quaternion rotation = player.rotation;
			string direction = ((Hero)playerObject.GetComponent<Hero>()).getDirection();
			nextFire = Time.time + fireRate;

			// TODO: Add code to damage enemy
			if (direction.Equals("up")) {
				shoot(position, Vector3.up, rotation);
			} else if (direction.Equals("down")) {
				shoot(position, Vector3.down, rotation);
			} else if (direction.Equals("left")) {
				shoot(position, Vector3.left, rotation);
			} else if (direction.Equals("right")) {
				shoot(position, Vector3.right, rotation);
			}
		}
	}

	private void shoot(Vector3 pos, Vector3 direction, Quaternion rotation) {
		Vector3 spawnPosition = pos + direction * spawnDistance;
		Rigidbody fireball = Instantiate(projectile, spawnPosition, rotation) as Rigidbody;
		fireball.velocity = transform.TransformDirection(direction * speed);
	}
}
