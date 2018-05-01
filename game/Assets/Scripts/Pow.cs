using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pow : MonoBehaviour, IItem {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Activated () {
		GetComponent<Animator> ().Play ("pow");
		yield return new WaitForSeconds (2);
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player"))
		{
			Vector3 vector = new Vector3 (this.transform.position.x, this.transform.position.y, 0f);
			Instantiate(Resources.Load("pow_activated"), vector, Quaternion.identity);
			StartCoroutine (Activated ());
		}
	}

	public float TTL {
		get {
			return 5f;
		}
	}
}
