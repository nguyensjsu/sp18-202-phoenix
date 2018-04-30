using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour, IItem {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//StartCoroutine (Boom ());
	}

	IEnumerator Boom () {
		animator.Play ("bomb");
		yield return new WaitForSeconds(0.8f);
		Destroy (this.gameObject);
	}

	public float TTL {
		get {
			return 20f;
		}
	}
}
