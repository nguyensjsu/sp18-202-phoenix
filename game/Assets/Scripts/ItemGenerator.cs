using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

	private static int INTERVAL = 3;

	private float rate;
	private float vertExtent;
	private float horzExtent;

	public ItemGenerator(float rate) {
		this.rate = rate;
		vertExtent = (Camera.main.orthographicSize); 
		horzExtent = (Camera.main.orthographicSize * Screen.width / Screen.height);
	}

	public IEnumerator Generate() {
		while (true) {
			if(UnityEngine.Random.value < rate){
				float x = UnityEngine.Random.Range (-horzExtent, horzExtent);
				float y = UnityEngine.Random.Range (-vertExtent, vertExtent);
				Vector3 vector = new Vector3 (x, y, -1.0f);
				ItemFactory.getItem (randomizeItem (), vector);
			}
			yield return new WaitForSeconds (INTERVAL);
		}
	}

	private Items randomizeItem() {
		return Items.pow;
		float value = UnityEngine.Random.value;
		if (value > 0.40f) {
			return Items.bomb;
		} else if (value > 0.30f && value < 0.40f) {
			return Items.bullet;
		} else if (value > 0.20f && value < 0.30f) {
			return Items.fire;
		} else if (value > 0.05f && value < 0.20f) {
			
		}
		return Items.pow;
	}
		

}
	


