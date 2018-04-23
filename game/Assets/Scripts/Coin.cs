using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IItem {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.Play ("coin");
	}

	// Update is called once per frame
	void Update () {
		
	}

	public float TTL {
		get {
			return 10f;
		}
	}
}
