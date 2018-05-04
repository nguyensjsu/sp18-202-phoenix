using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowActivator : MonoBehaviour {

	private bool isActivated = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (!isActivated) {
			StartCoroutine (Boom ());
			isActivated = true;
		}
	}

	IEnumerator Boom () {
		float vertExtent = (Camera.main.orthographicSize); 
		float horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height);
		for (int i = 0; i < 5; i++) {
			float x = UnityEngine.Random.Range (-horzExtent, horzExtent);
			float y = UnityEngine.Random.Range (-vertExtent, vertExtent);
			Vector3 vector = new Vector3 (x, y, -1.0f);
			Instantiate (Resources.Load ("Boom"), vector, Quaternion.identity);
		}

		GameObject go = GameObject.FindGameObjectWithTag ("GameController");
		IGameSystem gs = go.GetComponent<IGameSystem> ();
		ArrayList monsters = gs.MonsterList;
		foreach (IMonster monster in monsters) {
			monster.TakeDamage();
			monster.Speed /= 2;
		}

		yield return new WaitForSeconds (2);

		foreach (IMonster monster in monsters) {
			monster.Speed *= 2;
		}
		Destroy (this.gameObject);
	}

}
