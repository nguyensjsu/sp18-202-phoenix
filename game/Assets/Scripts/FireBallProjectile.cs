using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("enemy")) {
            Destroy(this.transform.parent.gameObject);
            BlueTurtle bt = coll.gameObject.GetComponent<BlueTurtle>();
            bt.TakeDamage();
            bt.ObserveHP();
		}
	}
}
