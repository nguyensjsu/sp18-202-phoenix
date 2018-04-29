using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("enemy")) {
			// TODO: Send message to enemy with damage amount...
			Destroy(coll.gameObject);
			Destroy(this.transform.parent.gameObject);
		}
	}
}
