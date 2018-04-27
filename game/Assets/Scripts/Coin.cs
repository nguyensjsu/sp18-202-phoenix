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

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("Player"))
		{
			Hero hero = coll.gameObject.GetComponent<Hero>();
			hero.step += 0.005f;
			Destroy (this.gameObject);
		}
	}
}
