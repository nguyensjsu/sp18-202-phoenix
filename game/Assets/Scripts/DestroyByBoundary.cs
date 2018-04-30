using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("fireball")) {
			Destroy(other.transform.parent.gameObject);
		} else {
			Destroy(other.gameObject);
		}
	}
}
