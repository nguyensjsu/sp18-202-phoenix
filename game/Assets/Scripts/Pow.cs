using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pow : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(Boom());
	}

	IEnumerator Boom () {
		animator.Play ("pow");
		yield return new WaitForSeconds(2);
		Destroy (this.gameObject);
	}
}
