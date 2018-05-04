using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("enemy") || coll.gameObject.CompareTag("enemy_rt") || coll.gameObject.CompareTag("enemy_goomba")) {
            Destroy(this.transform.parent.gameObject);
            IMonster bt = coll.gameObject.GetComponent<IMonster>();
            bt.TakeDamage();
            bt.ObserveHP();
            Hit(coll.transform.position);
		}
        else if (coll.gameObject.CompareTag("rock"))
        {
            Destroy(this.transform.parent.gameObject);
            Hit(coll.transform.position);
        }

    }

    void Hit(Vector3 position) {
        position.z = -1.0f;
        Instantiate(Resources.Load("hit"), position, Quaternion.identity);
    }

}
