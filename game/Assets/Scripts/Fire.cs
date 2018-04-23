using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, IItem {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator Hit () {
		animator.Play("fire_hit");
		yield return new WaitForSeconds(0.1f);
		Destroy (this.gameObject);
	}

	public float TTL {
		get {
			return 15f;
		}
	}
}
