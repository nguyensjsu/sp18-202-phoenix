using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (Kaboom ());
	}

	IEnumerator Kaboom () {
		yield return new WaitForSeconds(0.4f);
		Destroy (this.gameObject);
	}

}
