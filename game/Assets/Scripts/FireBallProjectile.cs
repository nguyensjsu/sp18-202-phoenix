using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("enemy")) {
            Destroy(this.transform.parent.gameObject);
            IMonster bt = coll.gameObject.GetComponent<IMonster>();
            bt.TakeDamage();
            bt.ObserveHP();
		}
	}
}
